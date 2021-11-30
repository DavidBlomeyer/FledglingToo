using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class AudienceEdit
    {
        public int AudienceID { get; set; }

        public int IdeaID { get; set; }

        public string Who { get; set; }
        public string What { get; set; }
        public string Why { get; set; }
        public string When { get; set; }
    }
}
