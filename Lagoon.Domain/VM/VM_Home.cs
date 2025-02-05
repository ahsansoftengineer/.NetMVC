using Lagoon.Domain.Entity;

namespace Lagoon.Domain.VM;
public class VM_Home
{
     public IEnumerable<Villa> VillaList { get; set; }
     public DateOnly CheckInDate { get; set; }
     public DateOnly CheckOutDate { get; set; }
     public int Night { get; set; }
}