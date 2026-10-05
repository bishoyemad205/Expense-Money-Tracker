using ExpendProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Repository.Interfaces
{
    public interface IgenericRepo<TEntity , TKey>  where TEntity : BaseEntites 
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool istracked, CancellationToken ct = default);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        void UpDate(TEntity entity);
        void Add(TEntity entity);
        Task Delete(int id);
        Task<TEntity?>FirstOrDefault(Expression<Func<TEntity, bool>> condation, bool istracted = false, CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condation, bool istracted = false, CancellationToken ct = default);

        Task<int> CompleteAysnc();

    }
}
 