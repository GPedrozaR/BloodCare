namespace BloodCare.Domain.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; }

        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}
