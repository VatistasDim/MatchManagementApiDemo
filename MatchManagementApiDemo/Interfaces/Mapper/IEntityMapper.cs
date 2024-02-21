namespace MatchManagementApiDemo.Interfaces.Mapper
{
    public interface IEntityMapper<TEntity, TDto>
    {
        TDto MapToDTO(TEntity entity);

        //MatchOddsDto MapToDTO(MatchOdds entity);

        TEntity MapToEntity(TDto dto);

        void MapToEntity(TDto dto, TEntity existingEntity);

        //MatchOdds MapToEntity(MatchOddsDto dto);
    }
}
