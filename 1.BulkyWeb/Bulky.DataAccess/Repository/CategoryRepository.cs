using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
    }
    


}