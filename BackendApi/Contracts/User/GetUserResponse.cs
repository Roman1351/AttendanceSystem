namespace BackendApi.Contracts.User
{
    /// <summary>
    /// Ответ с данными пользователя
    /// </summary>
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? Role { get; set; }
        public int? PersonId { get; set; }
    }
}