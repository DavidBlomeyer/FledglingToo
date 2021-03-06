using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Data
{
    public class Idea
    {
        // Key
        [Key]
        public int IdeaID { get; set; }
        public Guid OwnerID { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Project))]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        // Virtual Lists
        public virtual List<Audience> _Audiences { get; set; }

        // Variables
        public string IdeaName { get; set; }
        public string IdeaAuthor { get; set; }
        public string IdeaThesis { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
