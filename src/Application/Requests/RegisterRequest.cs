namespace Application.Requests;

public record RegisterRequest
{
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string RepeatPassword { get; init; }
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required DateTime BirthDay { get; init; }
}
