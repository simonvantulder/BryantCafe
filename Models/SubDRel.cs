using System;
using System.ComponentModel.DataAnnotations;

namespace BryantCornerCafe.Models
{
    public class SubDRel
    {
        [Key] // Primary Key
        public int SubDRelId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //******************************************************************
    // relationships
    //******************************************************************
        public int SubCategoryId { get; set; }
        public SubCategory ParentSubCat { get; set; } 
        public int DishId { get; set; }
        public Dish MyDish { get; set; } 
    }
}