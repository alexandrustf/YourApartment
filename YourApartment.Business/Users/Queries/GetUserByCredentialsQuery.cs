using EnsureThat;

namespace YourApartment.Business
{
    public sealed class GetUserByCredentialsQuery
    {
        public GetUserByCredentialsQuery(string email, string password)
        {
            EnsureArg.IsNotNullOrEmpty(email);
            EnsureArg.IsNotNullOrEmpty(password);

            Email = email;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }
}