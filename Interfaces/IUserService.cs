namespace authentication.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        User GetById(int id);
    }
}