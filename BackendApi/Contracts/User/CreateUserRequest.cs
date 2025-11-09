namespace BackendApi.Contracts.User
{
    /// <summary>
    /// Запрос на создание пользователя
    /// </summary>
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Role { get; set; }
        public int? PersonId { get; set; }
    }
}