using System.Runtime.Serialization;

namespace Entities.Abstract;

/// <summary>
/// Base class all concrete Entity classes inherit from. Defined as virtual so concrete implementations can override and define the column name implemented in the database schema.
/// </summary>
/// <typeparam name="S"></typeparam>
[DataContract]
public abstract class EntityBase<S> : IEntityBase<S>
	where S : struct
{
	[DataMember]
	public virtual S Id { get; set; }
}