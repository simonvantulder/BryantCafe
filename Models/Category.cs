using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BryantCornerCafe.Models
{
    public class Category
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display]
        public string Name { get; set; }


        [Required(ErrorMessage = "is required.")]
        public string Info { get; set; }

        //=========================================================================
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //=========================================================================

        //One Category to Many SubCategories 
        public List<CSubRel> MySubCats { get; set; }

    }


}
