using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.Helpers;
using System.Linq;

namespace MatchManagementApiDemo.Helpers
{
    public class EntityHelper : IEntityHelper
    { 
        private readonly ApplicationDbContext _applicationDbContext;

        public EntityHelper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool EntityExists<TEntity>(int id) where TEntity : class
        {
            return _applicationDbContext.Set<TEntity>().Any(c => GetPropertyValue(c, "ID").Equals(id));
        }

        private object GetPropertyValue(object entity, string propertyName)
        {
            return entity.GetType().GetProperty(propertyName)?.GetValue(entity, null);
        }
    }
}
