using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Data
{
    public class Visitor
    {
        // Key
        [Key]
        public int VisitorID { get; set; }
        public Guid OwnerID { get; set; }

        // Foreign Keys

        // Virtual Lists

        public virtual List<Project> _projects { get; set; }
        public virtual List<Requirement> _requirements { get; set; }
        public virtual List<Idea> _ideas { get; set; }

        // Variables

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Password { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
