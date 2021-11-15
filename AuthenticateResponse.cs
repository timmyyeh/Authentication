namespace authentication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Token = token;
            Username = user.Username;
        }
    }
}