using System.Runtime.Serialization;


namespace REST_API_FINAL
{
    [DataContract]
    public class UserDetails // userdetails contains the type of data that the database is accepting 
    {
        [DataMember]  
        public string age { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
