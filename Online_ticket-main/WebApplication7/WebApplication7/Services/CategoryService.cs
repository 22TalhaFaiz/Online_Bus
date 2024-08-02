using WebApplication7.Models;
using WebApplication7.Data; // Ensure this is the namespace where ApplicationDbContext is defined
using System.Collections.Generic;
using System.Linq;
using static WebApplication7.Data.Application;

namespace WebApplication7.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all categories
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        // Method to get a specific category by ID
        public Category GetCategoryById(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Cat_id == id);
        }
    }
}
