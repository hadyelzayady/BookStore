using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class CategoryParent
    {
        [JsonIgnore]

        public int Id { get; set; }

        [JsonIgnore]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category SubCategory { get; set; }
        [JsonIgnore]
        public int ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
    }
}
