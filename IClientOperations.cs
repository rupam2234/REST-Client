
namespace REST_API_FINAL
{
    interface IClientOperations
    {
        // to get details of one user
        UserDetails GetUserDetails(string userId);

        // to get details of all user
        UserDetails[] GetAllUserDetails();

        // to insert data into the databse
        ServerResponse PostToServer(UserDetails userDetails);

        // to update data into database
        ServerResponse UpdateData(UserDetails userDetails);

        // to Delete data from the database
        ServerResponse DeleteUserDetails(UserDetails userDetails);

    }
}
