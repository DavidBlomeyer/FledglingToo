using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Data
{
    public class Audience
    {
        // Key
        [Key]
        public int AudienceID { get; set; }
        public Guid OwnerID { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Idea))]
        public int IdeaID { get; set; }
        public Idea Idea { get; set; }

        // Variables
        public string Who { get; set; }
        public string What { get; set; }
        public string Why { get; set; }
        public string When { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
