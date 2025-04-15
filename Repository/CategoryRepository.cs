using BlazorYum.Data;
using BlazorYum.Repository.IRepository;

namespace BlazorYum.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Category Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var item = _db.Category.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _db.Category.Remove(item);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Category Get(int id)
        {
            var item = _db.Category.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                item = new Category();
            }

            return item;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }

        public Category Update(Category obj)
        {
            var item = _db.Category.FirstOrDefault(x => x.Id == obj.Id);
            if (item != null)
            {
                item.Name = obj.Name;
                _db.Category.Update(item);
                _db.SaveChanges();
                return item;
            }

            return obj;
        }
    }
}
