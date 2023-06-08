using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.BaseModel;
using LabuteCalatoare.DataBase.BaseRepositories.Interfaces;
using LabuteCalatoare.DataBase.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LabuteCalatoare.DataBase.BaseRepositories
{
    public class BaseRepository<TContext, TModel>: IRepository<TContext, TModel>
        where TContext:BaseDbContext
        where TModel: BaseDbModel
    {
        private readonly TContext _context;  
        public BaseRepository(TContext context)
        {
            _context = context;
           
        }

        public async Task CreateAsync(TModel elements)
        {
            try
            {
                _context.Set<TModel>().AddRange(elements);
                await _context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
            }
            catch
            {
                //insert error logs
            }
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                IEnumerable<TModel> items = await _context.Set<TModel>().Where(filter).ToListAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
                _context.Set<TModel>().RemoveRange(items);
                return await _context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
            }
            catch
            {
                //insert error logs
                return 0;
            }
        }

        public async Task<int> DeleteAsync(params TModel[] entities)
        {
            try
            {
                _context.Set<TModel>().RemoveRange(entities);
                return await _context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
            }
            catch
            {
                //insert error logs
                return 0;
            }
        }

        public virtual async Task<IEnumerable<TModel>> ReadAsync(Expression<Func<TModel, bool>> filter, Func<TModel, object> orderBy, bool desc, int count)
        {
            try
            {
                IEnumerable<TModel> readValues = await _context.Set<TModel>().Where(filter).ToListAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
                if (orderBy != null)
                {
                    if (desc)
                    {
                        readValues.OrderByDescending(orderBy);
                    }
                    else
                    {
                        readValues.OrderBy(orderBy);
                    }

                    if (count > 0)
                        return readValues.Take(count);
                }
                return readValues;
            }
            catch
            {
                //insert error logs
                return null;
            }
        }

        public virtual async Task<IEnumerable<TModel>> ReadAsync(int count=-1, Func<TModel, object> orderBy=null, bool desc=true)
        {
            try
            {
                IEnumerable<TModel> readValues = await _context.Set<TModel>().ToListAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
                if(orderBy!=null)
                {
                    if(desc)
                    {
                        readValues.OrderByDescending(orderBy);
                    }
                    else
                    {
                        readValues.OrderBy(orderBy);
                    }

                    if (count > 0)
                        return readValues.Take(count);
                }
                return readValues;
            }
            catch
            {
                //insert error logs
                return null;
            }
        }

        public virtual async Task<int> UpdateAsync(Expression<Func<TModel, bool>> filter, Action<TModel> updateAction)
        {
            try
            {
                IEnumerable<TModel> updateValues = await _context.Set<TModel>().Where(filter).ToListAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
                foreach(TModel element in updateValues)
                {
                    _context.Entry(element).State = EntityState.Modified;
                    updateAction(element);
                }

                return await _context.SaveChangesAsync(new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
            }
            catch
            {
                //insert error logs
                return 0;
            }
            
        }
    }
}
