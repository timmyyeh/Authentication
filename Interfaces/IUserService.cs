namespace authentication.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        User GetById(int id);
    }
}