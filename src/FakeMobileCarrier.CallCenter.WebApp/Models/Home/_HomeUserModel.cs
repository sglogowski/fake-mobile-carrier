namespace FakeMobileCarrier.CallCenter.WebApp.Models.Home
{
    public class _HomeUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string PESEL { get; set; }

        public _HomeUserModel()
        { }

        public _HomeUserModel(string firstName, string lastName, string phoneNumber, string pesel) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            PESEL = pesel;
        }
    }
}