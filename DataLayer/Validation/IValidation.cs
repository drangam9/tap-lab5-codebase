namespace DataLayer.Validation
{
    public interface IValidation
    {
        string ValidateEmail(string email);
        string ValidatePassword(string password);
        string ValidateName(string name);
    }
}
