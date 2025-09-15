using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Entities.Abstract;

namespace Entities;

/// <summary>
/// Concrete table with a Primary Key of type INT
/// </summary>
[Table("tbl_Patient")]
public class Patient : EntityBase<int>
{
	[Column("PatientID")]
	public override int Id { get => base.Id; set => base.Id = value; }

	[DataMember]
	[Required(ErrorMessage = "First name is required")]
	[StringLength(150, ErrorMessage = "First name exceeds {1} characters")]
	public required string FirstName { get; set; }

	//  Add more properties.
}