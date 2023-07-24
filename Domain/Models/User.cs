using Domain.SharedKernel;

namespace Domain.Models;

public partial class User : BaseEntity<long>
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string HashedPassword { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required DateTime BirthDay { get; set; }
    public required DateTime RegistrationDate { get; set; }
    public List<Note>? Notes = new();
}