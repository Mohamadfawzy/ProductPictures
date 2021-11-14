using ProductPictures.Data;
using ProductPictures.Models;
using ProductPictures.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProductPictures.ViewModels
{
    public class ProductDetailsPageVM : BaseViewModel
    {
        // readonly
        readonly IData<Product> dataProduct;
        // privet field
        private bool isSwipeEnabledVM = true;
        private ObservableCollection<string> images;
        private Product product;

        // public property
        public Product ProductVM
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public bool IsSwipeEnabledVM
        {
            get { return isSwipeEnabledVM; }
            set { SetProperty(ref isSwipeEnabledVM, value); }
        }
        
        public ObservableCollection<string> Images
        {
            get { return images; }
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }
        // Constructor -----------------------------------------------------------------------------
        public ProductDetailsPageVM()
        {
            dataProduct = DependencyService.Get<IData<Product>>();
            ProductVM = new Product();
            ProductVM = MainPageVM.CurrentProduct;
            LoadProducts();
        }
        private async void GetDataProduct()
        {
            //var list = await dataProduct. as List<Product>;
        }
        void LoadProducts()
        {
            Images = new ObservableCollection<string>()
            {
                 "image0.jpg",
                 "image1.jpg",
                 "image2.jpg",
            };
        }

    } // end class
}
