using Knowit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected internal async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                _context.Set<T>().Add(entity);
                await Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await GetByIdAsync(entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                    return false;

                _context.Set<T>().Remove(result);
                await Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
