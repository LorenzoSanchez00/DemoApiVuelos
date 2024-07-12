using ApiVuelos.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiVuelos.Services
{
    public interface ICommonService<T,TInsert,TUpdate>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TInsert crearVueloDto);
        Task<T> Update(int id, TUpdate modVueloDto);
        Task<T> Delete(int id);

    }
}
