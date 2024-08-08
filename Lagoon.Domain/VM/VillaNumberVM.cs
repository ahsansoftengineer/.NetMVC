using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lagoon.Domain.VM;
public class VillaNumberVM : BaseVM<VillaNumber>
{
  [ValidateNever]
  public IEnumerable<SelectListItem> VillaList { get; set; }

}