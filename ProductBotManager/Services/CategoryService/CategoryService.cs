using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;

namespace ProductBotManager.Services.CategoryService
{
    internal class CategoryService : ICategoryService
    {
        private readonly AppDbContext appDbContext;
        public CategoryService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async void Add(Category category)
        {
            await appDbContext.Categories.AddAsync(category);
            await appDbContext.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return appDbContext.Categories;
        }

        public async void Update(int id, string name)
        {
            var update = await appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (update == null)
            {
                return;
            }
            update.Name = name;
            await appDbContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var delete = await appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (delete == null)
            {
                return;
            }
            appDbContext.Categories.Remove(delete);
            await appDbContext.SaveChangesAsync();
        }
    }
}
