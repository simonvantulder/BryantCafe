using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace BryantCornerCafe.Models
{
    public class Dish
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int DishId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "is required.")]
        public int Price { get; set; }


        //=========================================================================
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //=========================================================================

//One User/Chef to Many Dishes
        public int ChefId { get; set; }
        public User Chef { get; set; } 

        //One Category to Many Dishes

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }


}
