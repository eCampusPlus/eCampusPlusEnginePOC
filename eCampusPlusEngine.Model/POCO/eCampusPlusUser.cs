namespace Fr.eCampusPlus.Engine.Model.POCO
{
    public class eCampusPlusUser
    {
        public string Email { get; set; }

        public string EmailConfirmation { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Sex { get; set; }
        
        public string Birthday { get; set; }

        public string Nativecountry { get; set; }

        public string BirthPlace { get; set; }

        public string Nationality { get; set; }

        public string TypeOfId { get; set; }

        public string IdValidity { get; set; }

        public string IdNumber { get; set; }

        public string IdIssuerCountry { get; set; }

        public bool RegistrationAction { get; set; }

        public bool ActionConfirm { get; set; }

        public bool ActionConnect { get; set; }

        public bool StudentPersonalInfo { get; set; }

        public bool ContactEdition { get; set; }

        public string ContactFormAddress { get; set; }

        public string ContactFormPostal { get; set; }

        public string ContactFormArea { get; set; }

        public string ContactFormCity { get; set; }

        public string ContactFormNumberPrefix { get; set; }

        public string ContactFormNumber { get; set; }

        public bool ContactFormSubmit { get; set; }
    }
}
