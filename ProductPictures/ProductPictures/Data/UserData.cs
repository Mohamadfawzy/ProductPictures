using ProductPictures.Data;
using ProductPictures.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserData))]
namespace ProductPictures.Data
{
    public class UserData : IData<User>
    {
        public Task Add()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> AllData()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public User FindOne(User id)
        {
            return new User() { Name = "Mohamed fawzy" };
        }
    }
}
