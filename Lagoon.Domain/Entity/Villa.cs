namespace Lagoon.Domain.Entity;
public class Villa 
{
  public int ID {get; set;}
  public required string Name {get; set;}
  public string? Desc {get; set;}
  public double Price {get; set;}
  public int Sqft {get; set;}
  public string? ImageUrl {get; set;}
  public DateTime? CreatedDate {get; set;}
  public DateTime? UpdatedDate {get; set;}
}