using System;
using System.ComponentModel.DataAnnotations;

namespace BryantCornerCafe.Models
{
    public class CSubRel
    {
        [Key] // Primary Key
        public int CSubRelId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //******************************************************************
    // relationships: 
    //******************************************************************
        public int SubCategoryId { get; set; }
        public SubCategory MySubCat { get; set; } 
        public int CategoryId { get; set; }
        public Category ParentCat { get; set; } 
    }
}