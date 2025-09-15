namespace Entities.Abstract;

/// <summary>
/// The contract that all entity class's conform to. Id translates to the table's primary key (unique identifier), hence the name Id.
/// S is to reflect the data type.
/// </summary>
/// <typeparam name="S"></typeparam>
public interface IEntityBase<S>
	where S : struct
{
	S Id { get; set; }
}