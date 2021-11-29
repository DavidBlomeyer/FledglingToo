using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fledgling.WebMVC.Models
{
    public class ProjectCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ProjectName { get; set; }
        [MaxLength(8000)]
        public string Content { get; set; }
    }
}