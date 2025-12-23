using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Infrastructure.Entities
{
    public class Audit
    {      
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UpdateById { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;       
    }
}
