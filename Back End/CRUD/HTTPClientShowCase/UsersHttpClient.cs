namespace CRUD.HTTPClientShowCase
{
    public class UsersHttpClient : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("users");
        }

    }

    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
}
