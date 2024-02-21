namespace MatchManagementApiDemo.Interfaces.Helpers
{
    public interface IEntityHelper
    {
        bool EntityExists<TEntity>(int id) where TEntity : class;
    }
}
