namespace Presentation.Requests
{
    public record LoginRequest
    {
        public required string UsernameOrEmail { get; init; }
        public required string Password { get; init; }
    }
}
