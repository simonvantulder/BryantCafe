using System;
using System.ComponentModel.DataAnnotations;

namespace BryantCornerCafe.Models
{
    public class UDRel
    {
        [Key] // Primary Key
        public int UDRelId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //******************************************************************
    // relationships
    //******************************************************************
        public int UserId { get; set; }
        public User Chef { get; set; } 
        public int DishId { get; set; }
        public Dish ChefsDish { get; set; } 
    }
}