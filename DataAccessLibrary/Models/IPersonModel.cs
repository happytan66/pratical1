namespace DataAccessLibrary.Models
{
    public interface IPersonModel
    {
        string Confirmpassword { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
    }
}