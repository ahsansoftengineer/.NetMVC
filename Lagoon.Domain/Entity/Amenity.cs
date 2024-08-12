using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lagoon.Domain.Entity;
public class Amenity
{
  public int ID {get; set;}   
  public required string Name {get; set;}

  [ForeignKey("Villas")]
  [Display(Name="Villa Name")]
  public int VillaId {get; set;}
  
  [ValidateNever]
  public Villa Villa{ get; set;}
  public string? Desc { get; set;}
  
}