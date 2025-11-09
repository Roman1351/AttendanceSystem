namespace BackendApi.Contracts.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Role { get; set; }
        public int? PersonId { get; set; }
    }
}