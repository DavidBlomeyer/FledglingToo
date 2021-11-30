using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class IdeaEdit
    {
        public int IdeaID { get; set; }

        public int ProjectID { get; set; }

        public string IdeaName { get; set; }
        public string IdeaAuthor { get; set; }
        public string IdeaThesis { get; set; }
    }
}
