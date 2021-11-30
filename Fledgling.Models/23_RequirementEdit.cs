using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class RequirementEdit
    {
        public int RequirementID { get; set; }
        //public int ProjectID { get; set; }

        public string ReqOrigin { get; set; }
        public string ReqDescription { get; set; }
        public string ReqLink { get; set; }
    }
}
