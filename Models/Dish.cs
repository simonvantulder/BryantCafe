using System.ComponentModel.DataAnnotations;
using System;
namespace BryantCornerCafe.Models
{
    public class Dish
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int DishId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Name { get; set; }

        // [Required(ErrorMessage = "is required.")]
        // [MinLength(2, ErrorMessage = "must be at least 2 characters")]     
        public string Description { get; set; }

        [Required(ErrorMessage = "is required.")]
        public double Price { get; set; }
        // public string PriceInfo { get; set; }
        // public string AddItem { get; set; }


        //=========================================================================
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //=========================================================================

// //One User/Chef to Many Dishes

        //One SubCategory to Many Dishes

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory ParentSubCat { get; set; }

    }


}
