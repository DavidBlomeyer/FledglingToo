using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class ProjectEdit
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectThesis { get; set; }
    }
}
