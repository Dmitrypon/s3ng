﻿using DeliveryService.Domain.External.Entities;

namespace DeliveryService.Domain.Domain.Entities
{
   /// <summary>
/// Интерфейс сущности с идентификатором.
/// </summary>
/// <typeparam name="TId"> Тип идентификатора. </typeparam>
public interface IEntity<TId>
    {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    TId Id { get; set; }
        Order? Order { get; set; }
    }

}
