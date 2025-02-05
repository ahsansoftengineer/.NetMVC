using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lagoon.Domain.Entity;
public class VillaNumber
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
  [Display(Name="Villa No")]
  public int Villa_Number {get; set;}   
  [ForeignKey("Villas")]
  [Display(Name="Villa Name")]
  public int VillaId {get; set;}
  [ValidateNever]
  public Villa Villa{ get; set;}
  [Display(Name="Special Details")]
  public string? SpecialDetails { get; set;}
  
}