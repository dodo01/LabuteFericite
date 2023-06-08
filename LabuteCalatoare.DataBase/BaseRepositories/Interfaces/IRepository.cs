using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LabuteCalatoare.DataBase.BaseModel;
using LabuteCalatoare.DataBase.Contexts;

namespace LabuteCalatoare.DataBase.BaseRepositories.Interfaces
{
    public interface IRepository<TContext, TModel> where TContext: BaseDbContext where TModel: BaseDbModel
    {
        Task CreateAsync(TModel elements);
        Task<IEnumerable<TModel>> ReadAsync(Expression<Func<TModel, bool>> filter, Func<TModel, object> orderBy = null, bool desc = true, int count = -1);
        Task<IEnumerable<TModel>> ReadAsync(int count = -1, Func<TModel, object> orderBy = null, bool desc = true);
        Task<int> UpdateAsync(Expression<Func<TModel, bool>> filter, Action<TModel> updateAction);
        Task<int> DeleteAsync(Expression<Func<TModel, bool>> filter);
        Task<int> DeleteAsync(params TModel[] entities);
    }
}
