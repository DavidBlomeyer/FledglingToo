using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class AudienceDetail
    {
        public int AudienceID { get; set; }

        public int IdeaID { get; set; }

        public string Who { get; set; }
        public string What { get; set; }
        public string Why { get; set; }
        public string When { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
