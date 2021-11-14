using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPictures.Models
{
    public class Product
    {
        // api propetry
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<string> Images { get; set; }
        public int CountPiecesSold { get; set; }
        public int Price { get; set; }
        public string Discount { get; set; }
        public List<string> Colors  { get; set; }
        public int Ratings { get; set; }
        public bool IsFeatured { get; set; }
        // binding protpetry
        public double XamarinWidth { get => App.XamarinWidth / 2; }
    }
}
