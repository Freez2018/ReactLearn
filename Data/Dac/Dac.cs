using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Data.Entities;
using Data.Context;

namespace Data.Dac
{
    public class Dac<R, E> where R : UsersManagementContext where E : BaseEntity
    {
        protected readonly R Repository;

        public Dac(R repository)
        {
            Repository = repository;
        }

        public void Create(E entity)
        {
            if (!entity.Validate())
            {
                throw new DataException("Entity is not valid and will fail when committed to database");
            }
            Repository.Set<E>().Add(entity);
        }

        public void DeleteById(string id)
        {
            var entity = Repository.Set<E>().FirstOrDefault(p => p.Id == id && p.DateDeleted == null);
            if (entity != null)
            {
                entity.DateDeleted = DateTime.UtcNow;
            }
        }

        public E GetById(string id)
        {
            return Repository.Set<E>().FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<E> List()
        {
            return Repository.Set<E>().Where(p => p.DateDeleted == null);
        }

        public IQueryable<E> List(Expression<Func<E, bool>> predicate)
        {
            return List().Where(predicate);
        }
    }
}
