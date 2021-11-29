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
        [ForeignKey(nameof(Visitor))]
        public int MemberId { get; set; }
        public Visitor Visitor { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        // Virtual Lists

        // Variables
        public string Goal { get; set; }

        public string SourceHeaderOne { get; set; }
        public string SourceBodyOne { get; set; }
        public string SourceHeaderTwo { get; set; }
        public string SourceBodyTwo { get; set; }
        public string SourceHeaderThree { get; set; }
        public string SourceBodyThree { get; set; }
        public string SourceHeaderFour { get; set; }
        public string SourceBodyFour { get; set; }
        public string SourceHeaderFive { get; set; }
        public string SourceBodyFive { get; set; }
        public string SourceHeaderSix { get; set; }
        public string SourceBodySix { get; set; }

        public string LinkHeaderOne { get; set; }
        public string LinkBodyOne { get; set; }
        public string LinkHeaderTwo { get; set; }
        public string LinkBodyTwo { get; set; }
        public string LinkHeaderThree { get; set; }
        public string LinkBodyThree { get; set; }
        public string LinkHeaderFour { get; set; }
        public string LinkBodyFour { get; set; }
        public string LinkHeaderFive { get; set; }
        public string LinkBodyFive { get; set; }
        public string LinkHeaderSix { get; set; }
        public string LinkBodySix { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
