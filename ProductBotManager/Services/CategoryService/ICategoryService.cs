using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.CategoryService
{
    internal interface ICategoryService
    {
        void Add(Category category);
        IQueryable<Category> GetAll();
        void Update(int id,string name);
        void Delete(int id);


    }
}
