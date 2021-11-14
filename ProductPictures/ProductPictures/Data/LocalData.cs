using ProductPictures.Data;
using ProductPictures.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//[assembly:Dependency(typeof(LocalData))]
namespace ProductPictures.Data
{
    public class LocalData : IData<Product>
    {
        public Task Add()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> AllData()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Product FindOne(Product id)
        {
            throw new NotImplementedException();
        }
    }
}
