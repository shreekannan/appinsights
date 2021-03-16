﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;


namespace AppInsights.SharedKernel.Interfaces
{
    public interface IRepository
    {

        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        IQueryable<T> Queryable<T>() where T : BaseEntity, IAggregateRoot;
    }
}