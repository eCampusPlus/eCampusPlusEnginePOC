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

        public string CandidatePhoto { get; set; }        

        public bool ContactEdition { get; set; }

        public string ContactFormAddress { get; set; }

        public string ContactFormPostal { get; set; }

        public string ContactFormArea { get; set; }

        public string ContactFormCity { get; set; }

        public string ContactFormNumberPrefix { get; set; }

        public string ContactFormNumber { get; set; }

        public bool ContactFormSubmit { get; set; }

        public bool IdJustificatoryEdition { get; set; }

        public string IdJustificatoryUploader { get; set; }

        public bool IdJustificatoryEditionDoneAction { get; set; }

        public bool ParticularCandidateEdition { get; set; }

        public bool ParticularCandidateNo { get; set; }

        public string ParticularCandidateBourse { get; set; }

        public string ParticularCandidateOtherCase { get; set; }        

        public bool ParticularCandidateEditionSave { get; set; }

        public bool StudentSkills { get; set; }

        public string StudentSkillsType { get; set; }

        public bool StudentSkillsTypeAdd { get; set; }

        public string StudentSkillsTypeSetYear { get; set; }

        public string StudentSkillsTypeSetCountry { get; set; }

        public string StudentSkillsTypeSetRegion { get; set; }

        public string StudentSkillsTypeSetCity { get; set; }

        public string StudentSkillsTypeSetSchool { get; set; }

        public string StudentSkillsTypeSetDiplome { get; set; }

        public string StudentSkillsTypeSetScore { get; set; }

        public string StudentSkillsTypeSetLevel { get; set; }

        public bool StudentSkillsTypeSubmit { get; set; }

        public bool StudentSkillsJustificatory { get; set; }

        public string StudentSkillsJustificatoryUplod { get; set; }

        public bool StudentSkillsJustificatorySubmit { get; set; }

        public bool StudentLanguages { get; set; }

        public bool StudentLanguagesLevelFrenchLink { get; set; }

        public string StudentLanguagesLevelFrenchScolarRef { get; set; }

        public string StudentLanguagesLevelFrenchStudyRef { get; set; }

        public bool StudentLanguagesLevelFrenchSubmit { get; set; }

        public bool StudentSchoolChoiceAdd { get; set; }

        public string StudentSchoolChoiceSearch { get; set; }

        public bool StudentSchoolChoiceSearchAction { get; set; }
    }
}
