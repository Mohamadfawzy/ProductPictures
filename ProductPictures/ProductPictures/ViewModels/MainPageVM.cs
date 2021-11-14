using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ProductPictures.Models;
using ProductPictures.Data;
using ProductPictures.Views;
using System.Linq;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;
namespace ProductPictures.ViewModels
{
    public class MainPageVM : BaseViewModel
    {
        readonly IData<Product> dataProduct;
        readonly IData<HotKey> dataHotKey;

        // public property
        public static Product CurrentProduct;
        public ObservableCollection<Product> ProductsItemsSource { get; set; }
        public List<HotKey> HotKeyItemsSource { get; set; }

        double flexLayoutItemsHeightRequest;
        public double FlexLayoutItemsHeightRequest
        {
            get { return flexLayoutItemsHeightRequest; }
            set { SetProperty(ref flexLayoutItemsHeightRequest, value); }
        }

        public ICommand ProductsItemsSourceCommand => new Command<Product>(ExcuteProductsItemsSourceCommand);
        public ICommand RefreshViewCommand => new Command<RefreshView>(ExecuteRefreshViewCommand);
        public MainPageVM()
        {
            // get Dependency Service
            dataProduct = DependencyService.Get<IData<Product>>();
            dataHotKey = DependencyService.Get<IData<HotKey>>();
            
            // new instance
            CurrentProduct = new Product();
            ProductsItemsSource = new ObservableCollection<Product>();
            HotKeyItemsSource = new List<HotKey>();

            // call methods 
            GetDataProducts();
            GetDataHotKey();
        }
        // Methods
        private async void ExecuteRefreshViewCommand(RefreshView sender)
        {
            var refreshView = sender as RefreshView;
            await Task.Delay(200);
            refreshView.IsRefreshing = false;
            ProductsItemsSource.Clear();
            GetDataProducts();
        }
        private void ExcuteProductsItemsSourceCommand(Product product)
        {
            CurrentProduct = product;
            App.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage(product), false);
        }
        // FalseString="300"
        // TrueString="280"
        int isFeaturedCount;
        
        private async void GetDataProducts()
        {
            isFeaturedCount = 1;
            FlexLayoutItemsHeightRequest = 0;
            int ColumnOne=0;
            int ColumnTow=0;
            var list = await dataProduct.AllData() as List<Product>;
            var countHalfList = Math.Ceiling(list.Count()/2.0);

            for (var i = 0; i < list.Count(); i++)
            {
                var item = list[i];
                if (i < countHalfList)
                {
                    if (item.IsFeatured)
                        ColumnOne += 280;
                    else
                        ColumnOne += 300;
                }
                else
                {
                    if (item.IsFeatured)
                        ColumnTow += 280;
                    else
                        ColumnTow += 300;
                }
                if (ColumnOne > ColumnTow)
                    FlexLayoutItemsHeightRequest = ColumnOne;
                else
                    FlexLayoutItemsHeightRequest = ColumnTow;
                ProductsItemsSource.Add(item);
                isFeaturedCount++;
                WriteLine("FlexLayoutItemsHeightRequest: " + FlexLayoutItemsHeightRequest);
                //await Task.Delay(500);
            } // end for

        }

        private async void GetDataProducts_abslot()
        {
            isFeaturedCount = 1;
            FlexLayoutItemsHeightRequest = 0;

            var list = await dataProduct.AllData();

            foreach (var item in list)
            {
                WriteLine("end for ------------------------: " + isFeaturedCount);
                // is odd
                if (isFeaturedCount % 2 != 0)
                {
                    WriteLine("odd: " + isFeaturedCount % 2);
                    if (item.IsFeatured)
                    {
                        WriteLine("odd Is featured");
                        FlexLayoutItemsHeightRequest += 280;
                    }
                    else
                    {
                        WriteLine("odd not featured");

                        FlexLayoutItemsHeightRequest += 300;
                    }
                }
                // is even
                else
                {
                    if (!item.IsFeatured)
                    {
                        WriteLine("even not featured");
                        WriteLine("even: " + isFeaturedCount % 2);

                        FlexLayoutItemsHeightRequest += 20;
                    }
                }
                ProductsItemsSource.Add(item);
                isFeaturedCount++;
                //await Task.Delay(500);
            } // end for

        }
        private async void GetDataHotKey()
        {
            HotKeyItemsSource = await dataHotKey.AllData() as List<HotKey>;
        }
    }
}
