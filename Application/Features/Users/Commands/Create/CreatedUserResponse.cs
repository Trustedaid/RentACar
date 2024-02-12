namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public CreatedUserResponse()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Email = String.Empty;
    }
    
    public CreatedUserResponse(int id, string firstName, string lastName, string email, bool status)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
    }
}