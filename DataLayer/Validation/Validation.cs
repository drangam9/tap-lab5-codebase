namespace DataLayer.Validation
{
    public class Validation : IValidation
    {
        public string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email is required";
            }
            return null;
        }

        public string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return "Password is required";
            }
            return null;
        }

        public string ValidateName(string name)
        {
            if (name.Length < 3)
            {
                return "Name too short";
            }
            return null;
        }


    }
}
