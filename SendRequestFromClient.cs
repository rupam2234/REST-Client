using System;
using System.Net.Http;
using System.Text;

namespace REST_API_FINAL
{
    class SendRequestFromClient : IClientOperations
    {
        public string url = "http://localhost:8080/users";

        public UserDetails GetUserDetails(string userId)
        {
            UserDetails tempIDHolder = null;

            // using a HttpClient object
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult())
                {
                    using (HttpContent httpContent = httpResponse.Content)
                    {
                        // storing the HttpResponse in a string
                        string myContent = httpContent.ReadAsStringAsync().GetAwaiter().GetResult();
                        // Deserialize myContent
                        tempIDHolder = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDetails>(myContent);
                    }
                }
            }

            return tempIDHolder;

        }

        // to get data for all available users
        public UserDetails[] GetAllUserDetails()
        {
            UserDetails[] tempDataHolder = null;
            // using a HttpClient Object
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult())
                {
                    using (HttpContent httpContent = httpResponse.Content)
                    {
                        // storing the response as a string
                        string myContent = httpContent.ReadAsStringAsync().GetAwaiter().GetResult();
                        // deserializing the string object
                        tempDataHolder = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDetails[]>(myContent);
                    }
                }
            }

            return tempDataHolder;
        }

        // to send request for data insertion
        public ServerResponse PostToServer(UserDetails userDetails)
        {
            ServerResponse tempDataHolder = null;

            //Serialize the inserted data
            string SerializedData = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails); 
            //Convert & store the serialized data inform of HTTP content  
            HttpContent ConvertedContent = new StringContent(SerializedData, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult())
                {
                    using(HttpContent httpContent = httpResponse.Content)
                    {
                        // storing the response into as a string
                        string myContent = httpContent.ReadAsStringAsync().GetAwaiter().GetResult();
                        // deserializing the string object
                        tempDataHolder = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerResponse>(myContent);
                    }
                }
            }
            return tempDataHolder;
        }

        // to send request for data updation
        public ServerResponse UpdateData(UserDetails userDetails)
        {
            ServerResponse idHolder = null; // to hold the input value of userId
            // Serialize the Data
            string SerializedData = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails);
            //convert the Serialized data into string content
            HttpContent ConvertedContent = new StringContent(SerializedData, Encoding.UTF8, "application/json");
            // creating a new HttpClient
            using (HttpClient hTTPClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponse = hTTPClient.PutAsync(url, ConvertedContent).GetAwaiter().GetResult())
                {
                    using (HttpContent httpContent = httpResponse.Content)
                    {
                        // storing the HttpResponse in a string
                        string myContent = httpContent.ReadAsStringAsync().GetAwaiter().GetResult();
                        // Deserialize myContent
                        idHolder = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerResponse>(myContent); 
                    }

                }

            }

            return idHolder;
        }

        // to delete spacific userdetails 
        public ServerResponse DeleteUserDetails(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
