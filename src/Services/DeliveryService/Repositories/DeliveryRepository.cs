﻿using Microsoft.EntityFrameworkCore;
using DeliveryService.Data;
using DeliveryService.Domain.Domain.Entities;

namespace DeliveryService.Repositories
{
    /// <summary>
    /// Репозиторий.
    /// </summary>
    /// <typeparam name="T"> Тип сущности. </typeparam>
    /// <typeparam name="TPrimaryKey"> Тип первичного ключа. </typeparam>
    public class DeliveryRepository 
    {
        protected readonly DeliveryDBContext Context;
        private readonly DbSet<Delivery> _entityDeliverySet;

        public DeliveryRepository(DeliveryDBContext context)
        {
            Context = context;
            _entityDeliverySet = Context.Set<Delivery>();
        }

        #region Get     

        /// <summary>
        /// Получить сущность по Id.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Cущность. </returns>
        public async Task<Delivery> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _entityDeliverySet.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить сущность по AuthenticationId.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Cущность. </returns>
        public async Task<Delivery> GetByAuthenticationIdAsync(Guid authenticationId, CancellationToken cancellationToken)
        {
            return await _entityDeliverySet.FindAsync(authenticationId, cancellationToken);
        }

        #endregion

        #region GetAll

        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> Список сущностей. </returns>
        public async Task<List<Delivery>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _entityDeliverySet.ToListAsync(cancellationToken);
        }

        #endregion

        #region Create 
        
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <returns> Добавленная сущность. </returns>
        public async Task<Delivery> AddAsync(Delivery entity, CancellationToken cancellationToken)
        {
            return (await _entityDeliverySet.AddAsync(entity, cancellationToken)).Entity;
        }

        /// <summary>
        /// Добавить в базу массив сущностей.
        /// </summary>
        /// <param name="entities"> Массив сущностей. </param>
        public virtual void AddRange(List<Delivery> entities)
        {
            var enumerable = entities as IList<Delivery> ?? entities.ToList();
            _entityDeliverySet.AddRange(enumerable);
        }

        /// <summary>
        /// Добавить в базу массив сущностей.
        /// </summary>
        /// <param name="entities"> Массив сущностей. </param>
        public virtual async Task AddRangeAsync(ICollection<Delivery> entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }
            await _entityDeliverySet.AddRangeAsync(entities);
        }

        #endregion

        #region Update

        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        public virtual void Update(Delivery entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Обновить в базе сущность.
        /// </summary>
        /// <param name="entity"> Сущность для обновления. </param>
        /// <returns> Обновленная сущность. </returns>
        public async Task<Delivery> UpdateAsync(Delivery entity, CancellationToken cancellationToken)
        {
            _entityDeliverySet.Update(entity);
            return await _entityDeliverySet.FindAsync(entity.Id, cancellationToken);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="id"> Id удаляемой сущности. </param>
        /// <returns> Была ли сущность удалена. </returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var deleteEntity = await _entityDeliverySet.FindAsync(id, cancellationToken);
            if (deleteEntity == null)
            {
                return false;
            }

            _entityDeliverySet.Remove(deleteEntity);
            return true;
        }

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity"> Сущность для удаления. </param>
        /// <returns> Была ли сущность удалена. </returns>
        public virtual bool Delete(Delivery entity)
        {
            if (entity == null)
            {
                return false;
            }
            Context.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// Удалить сущности.
        /// </summary>
        /// <param name="entities"> Коллекция сущностей для удаления. </param>
        /// <returns> Была ли операция завершена успешно. </returns>
        public virtual bool DeleteRange(ICollection<Delivery> entities)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            _entityDeliverySet.RemoveRange(entities);
            return true;
        }

        #endregion

        #region SaveChanges

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public Task<Delivery> GetByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResults> UpdateAsync(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResults> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}