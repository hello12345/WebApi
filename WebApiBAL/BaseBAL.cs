using System.Threading.Tasks;
using WebApiModel;

/// <summary>
/// Summary description for BaseDAL
/// </summary>
namespace WebApiBAL
{
    public interface IBaseBAL<T>
        where T : class
    {
        Task<ResultPT> InsertAsync(T obj);

        Task<ResultPT> UpdateAsync(T obj);

        Task<ResultPT> DeleteAsync(long ID);
        Task<ResultPT> GetAllAsync(long UserId);
        //ResultPT DeleteAll();

        Task<ResultPT> GetByIDAsync(long ID);
    }
}

