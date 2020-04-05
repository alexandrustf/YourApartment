namespace YourApartment.Business
{
    public class CreateLocationCommand
    {
        public CreateLocationCommand(string name, string preciseAdress)
        {
            Name = name;
            PreciseAdress = preciseAdress;
        }
        public string Name { get; set; }

        public string PreciseAdress { get; set; }
    }
}