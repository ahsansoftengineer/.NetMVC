using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lagoon.Domain.VM;
public class VM_Amenity : BaseVM<Amenity>
{
  [ValidateNever]
  public IEnumerable<SelectListItem> VillaList { get; set; }
}