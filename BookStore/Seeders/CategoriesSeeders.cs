using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Seeders
{
    public class CategoriesSeeders
    {
        private readonly BookStoreContext _context;
        public CategoriesSeeders(BookStoreContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var categ1 = new Category {Name = "categ1" };
            var categ2 = new Category { Name = "categ2" };
            var sub1_categ1 = new Category {  Name = "sub1categ1"};
            var sub2_categ1 = new Category {  Name = "sub2categ1" };
            var sub1_categ2 = new Category {  Name = "sub1categ2" };
            var sub2_categ2 = new Category { Name = "sub2categ2" };
            var subcommon = new Category { Name = "subcommon" };
            var cat1=new CategoryParent { SubCategory = sub1_categ1, ParentCategory = categ1 };
            var cat2=new CategoryParent { SubCategory = sub2_categ1, ParentCategory = categ1 };
            var cat3 = new CategoryParent { SubCategory = sub1_categ2, ParentCategory = categ2 };
            var cat4 = new CategoryParent { SubCategory = sub2_categ2, ParentCategory = categ2 };
            var cat5 = new CategoryParent { SubCategory = subcommon, ParentCategory = categ1 };
            var cat6 = new CategoryParent { SubCategory = subcommon, ParentCategory = categ2 };

            AddNewCategory(cat1);
            AddNewCategory(cat2);
            AddNewCategory(cat3);
            AddNewCategory(cat4);
            AddNewCategory(cat5);
            AddNewCategory(cat6);

            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
       
        private void AddNewCategory(CategoryParent parentCategory)
        {
            var existingType = _context.CategoriesParents.FirstOrDefault(p => p.SubCategory.Name == parentCategory.SubCategory.Name && p.ParentCategory.Name== parentCategory.ParentCategory.Name);
            if (existingType == null)
            {
                _context.CategoriesParents.Add(parentCategory);
            }
        }
    }
}
