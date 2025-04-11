namespace Core.Abstracts
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
