using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Data
{
    public class Project
    {
        // Key
        [Key]
        public int ProjectID { get; set; }
        public Guid OwnerID { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Visitor))]
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }

        // Virtual Lists
        public virtual List<Requirement> _requirements { get; set; }
        public virtual List<Idea> _ideas { get; set; }

        // Variables
        public string ProjectName { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectThesis { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
