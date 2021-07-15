using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace BryantCornerCafe.Models
{
    public class SubCategory
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display]
        public string Name { get; set; }

        public string Info { get; set; }


        //=========================================================================
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //=========================================================================

        //One SubCategory to Many Dishes
        public List<Dish> MyDishes { get; set; }

        //One Category to many SubCategories

        [Display(Name = "Meal Category")]
        public int CategoryId  { get; set; }
        public Category ParentCat { get; set; }
    }


}
