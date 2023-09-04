using Domain.Enums;
using Domain.SharedKernel;

namespace Domain.Models
{
    public partial class User : BaseEntity<long>
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public List<Note>? Notes = new();
        public Roles Role { get; set; } = Roles.User;

    }
}