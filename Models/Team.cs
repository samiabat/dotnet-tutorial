using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postgressdb.Models;
public class Team: BaseEntity
{
    public Team() {
        var Drivers = new HashSet<Driver>();
    }
    public string Name { get; set; }="";
    public int year { get; set; } = 2023;
    
    public virtual ICollection<Driver> ?Drivers{ get; set; }

}