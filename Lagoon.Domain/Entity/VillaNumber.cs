using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagoon.Domain.Entity;
public class VillaNumber
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int Villa_Number {get; set;}   
  [ForeignKey("Villas")]
  public int VillaId {get; set;}
  public Villa Villa{ get; set;}
  public string? SpecialDetails { get; set;}
  
}