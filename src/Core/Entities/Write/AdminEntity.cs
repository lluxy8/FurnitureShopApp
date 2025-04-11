using Core.Abstracts;

namespace Core.Entities.Write
{
    public class AdminEntity : BaseEntity
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
    }
}
