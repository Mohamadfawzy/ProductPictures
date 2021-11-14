using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductPictures.Data
{
    public interface IData<T>
    {
        Task Add();
        void Delete();
        T FindOne(T id);
        Task<IEnumerable<T>> AllData();
    }
}
