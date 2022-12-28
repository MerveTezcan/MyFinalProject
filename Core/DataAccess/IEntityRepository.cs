using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
        //generic constraint (generic kısıt)
        //class : referans tip olabilir demek
        //IEntity :IEntity olabilir yada IEntity implemente eden bir nesne olabilir
        //new() : new'lenebilir olmalı IEntity new lenemez
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression ürünleri filtrelemeye örneğin
        //Id ye göre getir,fiyatı 50 olanı getir gibi
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       
    }
}
