namespace Supermercado.API.Domain.Repositories
{
    public interface ICategoriaRepository
    {
         Task<IEnumarable<Categoria>> ListAsync();
         Task AddAsync(Categoria categoria);
         Task<Categoria> FindByIdSync(int id);
         void Update(Categoria categoria);
         void Remove(Categoria categoria);
    }
}