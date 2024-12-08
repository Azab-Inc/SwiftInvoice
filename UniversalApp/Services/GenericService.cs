using System.Diagnostics;

namespace UniversalApp.Services
{
    public class GenericService<T, TDTO> where T : class, IHasUserId, new()
    {
        public readonly DbService dbService = new DbService();

        public GenericService() { }

        public virtual int dbGetCount(int userId)
        {
            using (var connection = dbService.GetConnection())
            {
                return connection.Table<T>().Count(t => t.UserId == userId);
            }
        }

        public virtual void dbCreate(int userId, T entity)
        {
            try
            {
                using (var connection = dbService.GetConnection())
                {
                    entity.UserId = userId;
                    connection.Insert(entity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public virtual List<T> dbGetMany(int userId, int pageSize, int pageIndex)
        {
            using (var connection = dbService.GetConnection())
            {
                return connection.Table<T>()
                    .Where(t => t.UserId == userId)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .ToList();
            }
        }

        public virtual List<TDTO> dbGetManyDTO(int userId, int pageSize, int pageIndex, Func<T, TDTO> mapToDto)
        {
            using (var connection = dbService.GetConnection())
            {
                var entities = connection.Table<T>()
                    .Where(t => t.UserId == userId)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .ToList();

                return entities.Select(mapToDto).ToList();
            }
        }

        public virtual T dbGetSingle(int userId, int entityId)
        {
            using (var connection = dbService.GetConnection())
            {
                return connection.Table<T>()
                    .FirstOrDefault(t => t.UserId == userId && t.Id == entityId);
            }
        }

        public virtual void dbEdit(int userId, T entity)
        {
            using (var connection = dbService.GetConnection())
            {
                var existingEntity = connection.Table<T>()
                    .FirstOrDefault(t => t.UserId == userId && t.Id == entity.Id);

                if (existingEntity != null)
                {
                    connection.Update(entity);
                }
                else
                {
                    throw new InvalidOperationException("Entity not found or access denied.");
                }
            }
        }

        public virtual void dbDelete(int userId, T entity)
        {
            using (var connection = dbService.GetConnection())
            {
                var existingEntity = connection.Table<T>()
                    .FirstOrDefault(t => t.UserId == userId && t.Id == entity.Id);

                if (existingEntity != null)
                {
                    connection.Delete(existingEntity);
                }
                else
                {
                    throw new InvalidOperationException("Entity not found or access denied.");
                }
            }
        }

        private bool EntityMatchesSearchTerm(T entity, string searchTerm)
        {
            
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
            
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(entity) as string;

            
                    if (!string.IsNullOrEmpty(value) && value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            
            return false;
        }

    }
}
