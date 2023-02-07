using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ErrorDTO
    {
        public int status { get; set; }
        public string msg { get; set; }
        public DateTime date { get; set; }
    }
}
