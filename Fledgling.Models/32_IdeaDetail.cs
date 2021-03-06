using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class IdeaDetail
    {
        public int IdeaID { get; set; }

        public int ProjectID { get; set; }

        public string IdeaName { get; set; }
        public string IdeaAuthor { get; set; }
        public string IdeaThesis { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
