using Domain.SharedKernel;

namespace Domain.Models;

public class Note : BaseEntity<long>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public User? Owner { get; set; }
    public long OwnerId { get; set; } 
}