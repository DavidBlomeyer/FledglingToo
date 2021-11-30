using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fledgling.Models
{
    public class IdeaListItem
    {
        public int IdeaID { get; set; }

        public int ProjectID { get; set; }

        public string IdeaName { get; set; }
        public string IdeaAuthor { get; set; }
        public string IdeaThesis { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}