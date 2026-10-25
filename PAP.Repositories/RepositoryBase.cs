using PAP.DataAccess;
using PAP.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAP.Repositories
{
    /// <summary>
    /// Generic repository interface that defines the contract for data access operations.
    /// </summary>
    /// <typeparam name="T">The entity type that this repository manages</typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type T from the database.
        /// </summary>
        /// <returns>A collection of all entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve</param>
        /// <returns>The entity with the specified ID, or null if not found</returns>
        T GetById(int id);

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        void Delete(int id);

        /// <summary>
        /// Saves all pending changes to the database.
        /// </summary>
        void Save();

        /// <summary>
        /// Retrieves the first N entities (used by the Index views, N = 100).
        /// </summary>
        IEnumerable<T> GetTop(int count);

        /// <summary>
        /// Adds many entities with a single SaveChanges (used by PAP.Generators).
        /// </summary>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// True if the table has at least one row.
        /// </summary>
        bool Any();

        /// <summary>
        /// Number of rows in the table.
        /// </summary>
        int Count();
    }

    /// <summary>
    /// Generic repository base class that provides common data access operations for entities.
    /// Implements the Repository pattern to encapsulate data access logic.
    /// </summary>
    /// <typeparam name="T">The entity type that this repository manages</typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// The Entity Framework database context used for data access.
        /// </summary>
        protected readonly BookStoreDBEntities _context;

        /// <summary>
        /// The Entity Framework DbSet for the entity type T.
        /// </summary>
        protected readonly DbSet<T> _set;

        /// <summary>
        /// Initializes a new instance of the RepositoryBase class.
        /// </summary>
        public RepositoryBase()
        {
            _context = new BookStoreDBEntities();
            _set = _context.Set<T>();
        }

        /// <summary>
        /// Retrieves all entities of type T from the database.
        /// </summary>
        /// <returns>A collection of all entities</returns>
        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve</param>
        /// <returns>The entity with the specified ID, or null if not found</returns>
        public T GetById(int id)
        {
            return _set.Find(id);
        }

        /// <summary>
        /// Adds a new entity to the database and saves changes immediately.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        public void Add(T entity)
        {
            _set.Add(entity);
            Save();
        }

        /// <summary>
        /// Updates an existing entity in the database and saves changes immediately.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        public void Update(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _set.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Deletes an entity from the database by its unique identifier and saves changes immediately.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        public void Delete(int id)
        {
            T entityToDelete = _set.Find(id);
            if (entityToDelete != null)
            {
                _set.Remove(entityToDelete);
                Save();
            }
        }

        /// <summary>
        /// Saves all pending changes to the database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Base query used by GetTop. Concrete repositories override it to add
        /// Include(...) for related tables and a deterministic OrderBy.
        /// </summary>
        protected virtual IQueryable<T> Query()
        {
            return _set;
        }

        /// <summary>
        /// Retrieves the first N entities.
        /// </summary>
        public virtual IEnumerable<T> GetTop(int count)
        {
            return Query().Take(count).ToList();
        }

        /// <summary>
        /// Adds many entities with a single SaveChanges.
        /// </summary>
        public void AddRange(IEnumerable<T> entities)
        {
            var previous = _context.Configuration.AutoDetectChangesEnabled;
            _context.Configuration.AutoDetectChangesEnabled = false;
            try
            {
                _set.AddRange(entities);
                Save();
            }
            finally
            {
                _context.Configuration.AutoDetectChangesEnabled = previous;
            }
        }

        /// <summary>
        /// True if the table has at least one row.
        /// </summary>
        public bool Any()
        {
            return _set.Any();
        }

        /// <summary>
        /// Number of rows in the table.
        /// </summary>
        public int Count()
        {
            return _set.Count();
        }
    }
}
