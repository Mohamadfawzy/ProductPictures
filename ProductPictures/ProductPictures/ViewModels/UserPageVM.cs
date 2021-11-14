using ProductPictures.Data;
using ProductPictures.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProductPictures.ViewModels
{
    public class UserPageVM
    {
        public string MyName { get; set; }
        readonly IData<User> data;

        public UserPageVM()
        {
            data = DependencyService.Get<IData<User>>();
            MyName = data.FindOne(new User()).Name;

        }
    }
}
