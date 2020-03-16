using System;

namespace REST_API_FINAL
{
    class MainClass
    {
        static void Main(string[] args)
        {
            SendRequestFromClient response = new SendRequestFromClient();
            UserDetails readDetails = response.GetUserDetails("Rupam");

            UserDetails[] userDetails = response.GetAllUserDetails();
            Console.WriteLine(userDetails); // just checking...

            Console.ReadKey();
        }
    }
}
