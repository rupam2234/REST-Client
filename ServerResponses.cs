using System.Runtime.Serialization;

namespace REST_API_FINAL
{
    [DataContract]
    class ServerResponse // response that the client will display upon succesfull execution
    {
        [DataMember]
        string error_message { get; set; }

        [DataMember]
        string error_code { get; set; }
    }
}
