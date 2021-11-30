using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Data
{
    public class Requirement
    {
        // Key
        [Key]
        public int RequirementID { get; set; }
        public Guid OwnerID { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Project))]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        // Variables
        public string ReqOrigin { get; set; }
        public string ReqDescription { get; set; }
        public string ReqLink { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
