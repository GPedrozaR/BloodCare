
namespace BloodCare.Domain.Base
{
    public abstract class BaseEntity
    {
        public string Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public void SetId(string id)
        {
            Id = id;
        }

        public void SetCreatedAt(DateTime date)
        {
            CreatedAt = date;
        }
    }
}
