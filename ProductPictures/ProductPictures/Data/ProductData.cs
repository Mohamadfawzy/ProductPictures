using ProductPictures.Data;
using ProductPictures.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProductData))]
namespace ProductPictures.Data
{
    public class ProductData : IData<Product>
    {
        IEnumerable<Product> list;
        public Task Add()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> AllData()
        {
            var random = new Random();
            list = new List<Product>
            {
                new Product {Title = "iPad Desk Stand - The Heckler iPad Desk Stand is a desktop accessory for use with the Apple-branded tablet",
                    Image="1https://i.pinimg.com/564x/63/49/6c/63496cf037fc89fdb476a2b8becfb687.jpg",
                    Images = new List<string>{ /*"https://file-examples-com.github.io/uploads/2017/04/file_example_MP4_480_1_5MG.mp4",*/"https://i.pinimg.com/564x/ea/73/d7/ea73d7745e6e23fb1dace113e96bc7c1.jpg", "https://i.pinimg.com/564x/4a/28/af/4a28af1e56e50574c8a1c67b6cb85ec8.jpg", "https://i.pinimg.com/564x/c8/38/69/c83869032e0a4274049b85aa5e8fed00.jpg", "https://i.pinimg.com/564x/45/63/d7/4563d7db4f87d14883dce08266726fe4.jpg"},
                    Colors = new List<string> {"","" },
                    Price =  random.Next(100,1000),
                    CountPiecesSold = random.Next(100,10000),
                    Description = "iPad Desk Stand - The Heckler iPad Desk Stand is a desktop accessory for use with the Apple-branded tablet that will work to securely position it on a workstation to", IsFeatured = true },
                
                new Product {Title = "Dorm || NCT GFRIEND Ribut mulu, nikahnya kapan? Selamat membaca🐝 01 Mei 2020 #1 Sinb 01062020 #1 Yuju 02062020 #1 Umji 02062020 #1 Sowon 08062020 #2 Yerin 08062020",
                    Image="1https://i.pinimg.com/564x/4d/96/77/4d96777be51ab397a0bcedafd71eea20.jpg",
                    Images = new List<string>{"", "https://i.pinimg.com/564x/fd/87/8d/fd878d6656c1b7f0f893ad822c7e6d84.jpg", "https://i.pinimg.com/564x/f3/85/2e/f3852ea097c0011bed5ec31ca59b85f9.jpg", "https://i.pinimg.com/564x/c4/58/90/c458905d8e277ca5bfff8c3377a06370.jpg"},
                    Colors = new List<string> {"","" },
                    Price =  random.Next(100,1000),
                    CountPiecesSold = random.Next(100,10000),
                    Description = "iPad Desk Stand - The Heckler iPad Desk Stand is a desktop accessory for use with the Apple-branded tablet that will work to securely position it on a workstation to", IsFeatured = true },
                
                new Product {Title = "Tablet Stand Holder Adjustable, OMOTON T1 iPad Stand, Desktop Aluminum Tablet Dock Cradle Compatible with iPad Air 4/Mini, New iPad 10.2/9.7, iPad Pro 11/12.9, Samsung, Nintendo and More, Rose Gold",
                    Image="1https://i.pinimg.com/564x/0a/69/3a/0a693ab1cc6965357c689d6cdce26d3c.jpg",
                    Images = new List<string>{"", "https://i.pinimg.com/564x/da/bf/66/dabf664ce3c8e30a56245f9690c97e9c.jpg", "https://i.pinimg.com/564x/b5/71/cb/b571cb8c4c2591a720d2457889025d85.jpg", "https://i.pinimg.com/564x/02/b3/b2/02b3b263cf388b02235a15b225953924.jpg"},
                    Colors = new List<string> {"","" },
                    Price =  random.Next(100,1000),
                    CountPiecesSold = random.Next(100,10000),
                    Description = "iPad Desk Stand - The Heckler iPad Desk Stand is a desktop accessory for use with the Apple-branded tablet that will work to securely position it on a workstation to", IsFeatured = true },
                
                new Product {Title = "",
                    Image="",
                    Images = new List<string>{"","","",""},
                    Colors = new List<string> {"","" },
                    Price =  random.Next(100,1000),
                    CountPiecesSold = random.Next(100,10000),
                    Description = "iPad Desk Stand - The Heckler iPad Desk Stand is a desktop accessory for use with the Apple-branded tablet that will work to securely position it on a workstation to", IsFeatured = true },

                new Product {Title = "Mohamed Fawzy3", Description = "description", IsFeatured = true },
                new Product {Title = "Mohamed Fawzy4", Description = "description", IsFeatured = false },
                new Product {Title = "Mohamed Fawzy5", Description = "description" , IsFeatured = false},
                new Product {Title = "Mohamed Fawzy6", Description = "description", IsFeatured = true},
                //
            };
            return Task.FromResult(list);
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
