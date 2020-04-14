namespace YourApartment.Business
{
    public sealed class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public CreateUserCommand(string name, string email, string phoneNumber,string password)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}