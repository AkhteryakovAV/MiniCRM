﻿using Microsoft.EntityFrameworkCore;
using MiniCRM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MiniCRM.EFDataAccess
{
    public class EFRepository<TModel> : IRepository<TModel> where TModel : NotifyPropertyObject
    {
        private readonly MainContext _context;
        private readonly DbSet<TModel> entities;

        public EFRepository(MainContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            entities = context.Set<TModel>();
        }

        public void Add(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!entities.Contains(entity))
                _ = entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _ = entities.Remove(GetById(id));
            _ = _context.SaveChanges();
        }

        public TModel[] GetAll()
        {
            return entities.ToArray();
        }

        public TModel GetById(int id)
        {
            TModel entity = entities.Find(id) ?? throw new KeyNotFoundException($"Клиент с Id '{id}' не найден.");
            return entity;
        }

        public void Update(TModel entity)
        {
            _ = _context.Update(entity);
            _ = _context.SaveChanges();
        }
    }
}