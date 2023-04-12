using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postgressdb.Models;
public class Driver: BaseEntity
{
    public Driver() {
        var MediaDriver = new HashSet<DriverMedia>();
    }
    public int TeamId { get; set; }
    public string Name { get; set; } = "";
    public int RacingNumber { get; set; }
    // public virtual ICollection<DriverMedia> Me

    public virtual Team ?Team { get; set; }
    public virtual DriverMedia ?DriverMedia { get; set; }
}