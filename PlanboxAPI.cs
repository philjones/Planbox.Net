namespace Planbox.Net
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class PlanboxAPI : IPlanboxAPI
    {
        private CookieContainer _cookieContainer { get; set; }

        private string AccessToken { get; set; }

        public PlanboxAPI(CookieContainer cookieContainer)
        {
            _cookieContainer = new CookieContainer();
        }

        public async Task<string> Login(string email, string password)
        {
            using (var client = new HttpClient(new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                client.BaseAddress = new Uri("https://www.planbox.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var kvps = new List<KeyValuePair<string, string>>();
                kvps.Add(new KeyValuePair<string, string>("email",email));
                kvps.Add(new KeyValuePair<string, string>("password",password));

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/login", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<dynamic>();
                    if (result.code == "ok")
                    {
                        this.AccessToken = result.content.access_token.ToString();
                        return this.AccessToken;
                    }
                    else
                    {
                        throw new LoginFailureException(result.content.ToString());
                    }
                }
                else
                {

                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }

            }
        }

        public async Task<Resource> GetLoggedIn()
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>();

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_logged_resource", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ResourceResult>();
                    if (result.code == "ok")
                    {
                        return result.content;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return null;
                }

            }
        }

        public async Task<bool> GetProducts()
        {
            using (var client = new PlanboxClient(this.AccessToken, new LoggingHandler(new HttpClientHandler() { CookieContainer = _cookieContainer })))
            {
                var kvps = new List<KeyValuePair<string, string>>();

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_products", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<dynamic>();
                    if (result.code == "ok")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return false;
                }

            }
        }

        public async Task<bool> GetProjects(string product_id)
        {
            using (var client = new PlanboxClient(this.AccessToken, new LoggingHandler(new HttpClientHandler() { CookieContainer = _cookieContainer })))
            {
                var kvps = new List<KeyValuePair<string, string>>();
                kvps.Add(new KeyValuePair<string, string>("product_id", product_id));

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_projects", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<dynamic>();
                    if (result.code == "ok")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    return false;
                }

            }
        }

        public async Task<IEnumerable<Story>> GetStories(string product_id, string project_id)
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("product_id", product_id),
                    new KeyValuePair<string, string>("project_id", project_id)
                };

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_stories", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<StoriesResult>();
                    if (result.code == "ok")
                    {
                        var stories = result.content;
                        return stories;
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Story>();
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }

            }
        }

        public async Task<bool> UpdateTask(string task_id, string story_id, string name = null, string description = null, string tags = null,
            string resource_id = null, string role_id = null, string estimate = null, decimal? duration = null,
            DateTime? timer_start = null, int? timer_sum_in_seconds = null, string status = null)
        {

            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>();

                kvps.Add(new KeyValuePair<string, string>("task_id", task_id));
                kvps.Add(new KeyValuePair<string, string>("story_id", story_id));

                AddIfNotNull(kvps, "name", name);
                AddIfNotNull(kvps, "description", description);
                AddIfNotNull(kvps, "tags", tags);
                AddIfNotNull(kvps, "resource_id", resource_id);
                AddIfNotNull(kvps, "role_id", role_id);
                AddIfNotNull(kvps, "estimate", estimate);
                AddIfNotNull(kvps, "duration", duration);
                AddIfNotNull(kvps, "timer_start", timer_start);
                AddIfNotNull(kvps, "timer_sum_in_seconds", timer_sum_in_seconds);
                AddIfNotNull(kvps, "status", status);

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/update_task", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<dynamic>();
                    if (result.code == "ok")
                    {
                        return true;
                    }                   
                    
                    return false;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return false;
                }
            }
        }

        public void AddIfNotNull(List<KeyValuePair<string,string>> list, string key, object value)
        {
            if (value == null)
            {
                return;
            }

            list.Add(new KeyValuePair<string,string>(key, value.ToString()));
        }


        public async Task<PlanboxTask> AddTask(string story_id, string name = null, string description = null, string tags = null, string resource_id = null, string role_id = null, string estimate = null, decimal? duration = null, DateTime? timer_start = null, int? timer_sum_in_seconds = null, string status = null)
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>();

                kvps.Add(new KeyValuePair<string, string>("story_id", story_id));

                AddIfNotNull(kvps, "name", name);
                AddIfNotNull(kvps, "description", description);
                AddIfNotNull(kvps, "tags", tags);
                AddIfNotNull(kvps, "resource_id", resource_id);
                AddIfNotNull(kvps, "role_id", role_id);
                AddIfNotNull(kvps, "estimate", estimate);
                AddIfNotNull(kvps, "duration", duration);
                AddIfNotNull(kvps, "timer_start", timer_start);
                AddIfNotNull(kvps, "timer_sum_in_seconds", timer_sum_in_seconds);
                AddIfNotNull(kvps, "status", status);

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/add_task", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<TaskResult>();
                    if (result.code == "ok")
                    {
                        return result.content;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return null;
                }

            }
        }


        public async Task<IEnumerable<Event>> GetEvents(string product_id, string start, string end)
        {

            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {

                var kvps = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("product_ids[]", product_id),
                    new KeyValuePair<string, string>("start", start),
                    new KeyValuePair<string, string>("end", end)
                };

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_events", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<EventsResult>();
                    if (result.code == "ok")
                    {
                        var stories = result.content;
                        return stories;
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Event>();
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }

            }
       } 


        public async Task<IEnumerable<Story>> GetStories(string product_id, IEnumerable<string> iteration_ids = null, IEnumerable<string> resource_ids = null)
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("product_id", product_id),
                };

                if (iteration_ids != null)
                {
                    kvps.AddRange(iteration_ids.Select(id => new KeyValuePair<string, string>("iteration_id[]", id)));
                }

                if (resource_ids != null)
                {
                    kvps.AddRange(resource_ids.Select(id => new KeyValuePair<string, string>("resource_id[]", id)));
                }
                

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_stories", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<StoriesResult>();
                    if (result.code == "ok")
                    {
                        var stories = result.content;
                        return stories;
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Story>();
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }

            }
        }

        public async Task<IEnumerable<Resource>> GetContacts()
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>();

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_contacts", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ResourcesResult>();
                    if (result.code == "ok")
                    {
                        var resources = result.content;
                        return resources;
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Resource>();
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }

            }
        }

        public async Task<IEnumerable<Resource>> GetResources(string product_id)
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var kvps = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("product_id", product_id),
                };

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_resources", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ResourcesResult>();
                    if (result.code == "ok")
                    {
                        var resources = result.content;
                        return resources;
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Resource>();
                    }


                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }

            }
        }


        public async Task<IEnumerable<Timesheet>> GetTimesheet(DateTime start, DateTime end)
        {
            using (var client = new PlanboxClient(this.AccessToken, new HttpClientHandler() { CookieContainer = _cookieContainer }))
            {
                var since = start.ToString("yyyy-MM-dd");
                var until = end.ToString("yyyy-MM-dd");

                var kvps = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("since", since),
                    new KeyValuePair<string, string>("until", until)
                };

                var formContent = new FormUrlEncodedContent(kvps);
                HttpResponseMessage response = await client.PostAsync("api/get_timesheet", formContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<TimesheetResult>();
                    if (result.code == "ok")
                    {
                        var timesheet = result.content;

                        // Get your contacts
                        var resources = await this.GetContacts();

                        // Translate that collection into Timesheet objects
                        return timesheet.AsTimesheets(resources);
                    }
                    else
                    {
                        // TODO: result was not OK
                        return new List<Timesheet>();
                    }
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
            }
        }
    }
    
}
