using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TravelAgencyContext _context;

        public BaseRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var response = _context.Set<TEntity>().Add(entity);
            await SaveAsync();
            return response;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool response = false;
            var entity = await GetByIdAsync(id);
            if (entity is null)
            {
                throw new Exception("Sorry id == null. You mistake");
                return response;
            }
            _context.Set<TEntity>().Remove(entity);
            await SaveAsync();
            var result = await GetByIdAsync(entity.Id);

            if (result is null)
            {
                response = true;
            }

            return response;

        }

        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            bool response = true;

            return response;
        }

        private async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
