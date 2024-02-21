using MatchManagementApiDemo.Interfaces.Mapper;
using System;

namespace MatchManagementApiDemo.Mappings
{
    public class EntityMapper<TEntity, TDto> : IEntityMapper<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        public TDto MapToDTO(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var dto = Activator.CreateInstance<TDto>();

            foreach (var property in typeof(TEntity).GetProperties())
            {
                var value = property.GetValue(entity);
                typeof(TDto).GetProperty(property.Name)?.SetValue(dto, value);
            }

            return dto;
        }

        public TEntity MapToEntity(TDto dto)
        {
            var entity = Activator.CreateInstance<TEntity>();

            foreach (var property in typeof(TDto).GetProperties())
            {
                var value = property.GetValue(dto);

                // Check if the property is a list
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    // Handle list mapping
                    var targetType = property.PropertyType.GetGenericArguments()[0];
                    var mappedList = MapList(value, targetType);
                    typeof(TEntity).GetProperty(property.Name)?.SetValue(entity, mappedList);
                }
                else
                {
                    // Regular property mapping
                    typeof(TEntity).GetProperty(property.Name)?.SetValue(entity, value);
                }
            }

            return entity;
        }

        public void MapToEntity(TDto dto, TEntity existingEntity)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity));
            }

            foreach (var property in typeof(TDto).GetProperties())
            {
                var value = property.GetValue(dto);
                typeof(TEntity).GetProperty(property.Name)?.SetValue(existingEntity, value);
            }
        }
    }
}
