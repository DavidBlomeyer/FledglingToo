using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class RequirementDetail
    {
        public int RequirementID { get; set; }
        //public int ProjectID { get; set; }

        public string ReqOrigin { get; set; }
        public string ReqDescription { get; set; }
        public string ReqLink { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
