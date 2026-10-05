using ExpendProject.DAL.Data.DB;
using ExpendProject.DAL.Model;
using ExpendProject.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Repository.Classes
{
    public class GenericReposiorty<TEntity, TKey> : IgenericRepo<TEntity, TKey> where TEntity : BaseEntites
    {
        private readonly ExpendProjectDBcontext _expendDbcontext;
        public GenericReposiorty(ExpendProjectDBcontext expendProjectDBcontext)
        {
            _expendDbcontext = expendProjectDBcontext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool istracked, CancellationToken ct = default)
        {
            var item = istracked ?_expendDbcontext.Set<TEntity>() : _expendDbcontext.Set<TEntity>().AsNoTracking();
            return await item.ToListAsync();
        }

        public Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var item = _expendDbcontext.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id); 
            return item;      
        }

        public void Add(TEntity entity)
        {
            _expendDbcontext.Add(entity);
        }

        public void UpDate(TEntity entity)
        {
            _expendDbcontext.Update(entity);
        }

        public async Task Delete(int id)
        {
          var item = await _expendDbcontext.Set<TEntity>().FirstOrDefaultAsync(i => i.Id==id);
            if(item != null)
            {
                 _expendDbcontext.Remove(item) ;
            }
             
        }


        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condation, bool istracted = false, CancellationToken ct = default)
        {
            return await _expendDbcontext.Set<TEntity>().AnyAsync(condation, ct);
        }

        public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> condation, bool istracted = false, CancellationToken ct = default)
        {
            var item = istracted ? _expendDbcontext.Set<TEntity>() : _expendDbcontext.Set<TEntity>().AsNoTracking();
            return await item.FirstOrDefaultAsync(condation, ct);   
        }


        public async Task<int> CompleteAysnc()
        {
            return await _expendDbcontext.SaveChangesAsync();
        }



    }

}
