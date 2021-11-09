using StationayShop.DbContexts;
using StationayShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationayShop.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly StationaryDbContext _stationaryDbContext;
        public CategoryRepo(StationaryDbContext stationaryDbContext)
        {
            _stationaryDbContext = stationaryDbContext;
        }
        public void DeleteCategory(int categoryId)
        {
            var category = _stationaryDbContext.Categories.Find(categoryId);
            _stationaryDbContext.Categories.Remove(category);
            Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _stationaryDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var category = _stationaryDbContext.Categories.Find(id);
            // _dbContext.Entry(category).Reference(s => s.StationaryCategory).Load();
            return category;
        }

        public void InsertCategory(Category category)
        {
            _stationaryDbContext.Add(category);
            Save();
        }

        public void UpdateCategory(Category category)
        {
            _stationaryDbContext.Entry(category).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _stationaryDbContext.SaveChanges();
        }
    }
}
