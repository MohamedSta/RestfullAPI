using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StoneChallenge.Models
{
public class Product
{
    [Key]
    public int Id { get; set; }

        [Required]
        //list
        private List<UInt32> list = new List<UInt32>();
        public List<UInt32> List
        {
            get { return list; }
            set { list = value; }
        }

      
        
    
}
}