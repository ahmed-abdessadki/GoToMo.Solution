using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GoToMo.Domain.Infrastructure
{
	public abstract class Entity : IEntity
	{
		private List<INotification> _domainEvents;

		/// <summary>
		/// Gets or sets the time when the item was created.
		/// </summary>
		/// <value>The created date.</value>
		public DateTimeOffset Created { get; set; }
		/// <summary>
		/// Gets or sets the time when the item was last modified.
		/// </summary>
		/// <value>The modified date.</value>
		public DateTimeOffset Modified { get; set; }


		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }

		public IReadOnlyCollection<INotification> DomainEvents
		{
			get
			{
				List<INotification> domainEvents = _domainEvents;
				return domainEvents == null ? null : domainEvents.AsReadOnly();
			}
		}

		public void AddDomainEvent(INotification eventItem)
		{
			_domainEvents = _domainEvents ?? new List<INotification>();
			_domainEvents.Add(eventItem);
		}

		public void RemoveDomainEvent(INotification eventItem)
		{
			_domainEvents?.Remove(eventItem);
		}

		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

		public override bool Equals(object obj)
		{
			Entity entity = obj as Entity;
			if ((object)entity == null)
				return false;
			if (this == (object)entity)
				return true;
			return !(GetRealType() != entity.GetRealType()) && Id != 0 && entity.Id != 0 && Id == entity.Id;
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if ((object)a == null && (object)b == null)
				return true;
			return (object)a != null && (object)b != null && a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetRealType().ToString() + Id.ToString()).GetHashCode();
		}

		private Type GetRealType()
		{
			return GetType();
		}

		public bool IsTransient()
		{
			return Id == 0;
		}
	}
}
