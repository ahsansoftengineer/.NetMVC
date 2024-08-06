using System.ComponentModel.DataAnnotations;

namespace Lagoon.Domain.Entity;
public class Villa 
{
  public int ID {get; set;}
  [MaxLength(50)]
  public required string Name {get; set;}
  public string? Desc {get; set;}
  [Display(Name="Price per Night")]
  [Range(10, 10000)]
  public double Price {get; set;}
  public int Sqft {get; set;}
  [Range(1,10)]
  public int Occupancy {get; set;}
  [Display(Name="Image Url")]
  public string? ImageUrl {get; set;}
  public DateTime? CreatedDate {get; set;}
  public DateTime? UpdatedDate {get; set;}
}