﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    // TODO: Create your ChangeTracker class here.
    internal class ChangeTracker<T>
        where T:class,new()
    {
        private readonly List<T> allentities;
        private readonly List<T> removed;
        private readonly List<T> added;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.removed = new List<T>();
            this.added = new List<T>();

            this.allentities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> Added
            => this.added.AsReadOnly();

        public IReadOnlyCollection<T> Removed
            => this.removed.AsReadOnly();

        public IReadOnlyCollection<T> AllEntities
            => this.allentities.AsReadOnly();


        public void Add(T item)
            => this.added.Add(item);

        public void Remove(T item)
            => this.removed.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));
                var isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
                return modifiedEntities;
            }


            return null;
        }

        private bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowdSqlTypes.Contains(pi.PropertyType))
                .ToArray();
            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(proxyEntity), pi.GetValue(entity)))
                .ToArray();

            var IsModified = modifiedProperties.Any();
            return IsModified;

        }

        private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowdSqlTypes.Contains(pi.PropertyType))
                .ToArray();
            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity,value);

                    clonedEntities.Add(clonedEntity);
                    
                }

            }
            return clonedEntities;
        }
    }

}