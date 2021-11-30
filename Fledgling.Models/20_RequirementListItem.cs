using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fledgling.Models
{
    public class RequirementListItem
    {
        public int RequirementID { get; set; }

        public int ProjectID { get; set; }

        public string ReqOrigin { get; set; }
        public string ReqDescription { get; set; }
        public string ReqLink { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}