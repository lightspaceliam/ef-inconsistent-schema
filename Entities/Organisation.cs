using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Entities.Abstract;

namespace Entities;

/// <summary>
/// Concrete table with a Primary Key of type Guid / UNIQUEIDENTIFIER
/// </summary>
[Table("Organisation")]
public class Organisation : EntityBase<Guid>
{
	[Column("OrganisationId")]
	public override Guid Id { get => base.Id; set => base.Id = value; }

	[Column("OrganisationName")]
	[DataMember]
	[Required(ErrorMessage = "Name is required")]
	[StringLength(150, ErrorMessage = "Name exceeds {1} characters")]
	public required string Name { get; set; }
	
	//  Add more properties.
}