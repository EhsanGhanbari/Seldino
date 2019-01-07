using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.NotificationAggregation
{
    public class Newsletter : EntityBase, IAggregateRoot
    {
        public string Email { get; set; }
        public bool NotIncluded { get; set; }
        
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
