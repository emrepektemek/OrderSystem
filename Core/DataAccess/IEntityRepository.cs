using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess // namespace proje adı . klasor varsa adi . klasor varsa adi . klasor varsa adi.   namespaceler standar olarak boyle verilir fakat boyle vermezseniz hata vermez ama duzen olmasi icin boyle olmali
{
    public interface IEntityRepository<T> where T : class, IEntity , new()  
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); // filtre = null filtre vermeyebilirsin anlamına geliyor. Bu kodu bir kere yazıyorsun sonra aylarca bakmıyorsun tek sefer yazman yeterli

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
