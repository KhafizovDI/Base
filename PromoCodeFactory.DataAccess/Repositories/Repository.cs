using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected List<TEntity> Data { get; set; }

        public Repository(IEnumerable<TEntity> data)
        {
            Data = data.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            await Task.CompletedTask;
            return Data;
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public async Task AddAsync(TEntity entity)
        {
            Data.Add(entity);          
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var index = Data.FindIndex(x => x.Id == entity.Id);
            Data[index] = entity;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            Data.Remove(Data.FirstOrDefault(x => x.Id == id));
            await Task.CompletedTask;
        }
    }
}