using ProductPictures.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Diagnostics.Debug;
namespace ProductPictures
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var stack = stackLayoutItems.Children[4] as StackLayout;
            //var defultColor = stack.BackgroundColor;
            //stack.BackgroundColor = Color.Bisque;
            //await scrollView.ScrollToAsync(stack, ScrollToPosition.Center, true);
            //await Task.Delay(1500);
            //stack.BackgroundColor = defultColor;
            var bound = stackTap1.Bounds;
            await scrollView.ScrollToAsync(bound.X, bound.Y, true);
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY >= stackTap1.Bounds.Y)
            {
                if (!stackTap2.IsVisible)
                    stackTap2.IsVisible = true;
                //WriteLine("if - ScrollY: " + (int)e.ScrollY + " bound:" + buttonAddNewItem.Bounds.Y);
            }
            else
            {
                if(stackTap2.IsVisible)
                    stackTap2.IsVisible = false;
                //WriteLine("else - ScrollY:" + (int)e.ScrollY + " bound:" + buttonAddNewItem.Bounds.Y);
            }

            //WriteLine("Y: " + e.ScrollY);
        }

        private void TabBar_TabBarClicked(object sender, EventArgs e)
        {
            var stack = sender as StackLayout;
        }
        // methods for servsece
        readonly DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        private double density = 0.0;
        // Width and heith (in xamarin.forms units)
        private double xamarinWidth = 0.0;
        private double xamarinHeight = 0.0;
        private void DisplyInfo()
        {
            density = mainDisplayInfo.Density;

            // Orientation (Landscape, Portrait, Square, Unknown)
            //var orientation = mainDisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            //var rotation = mainDisplayInfo.Rotation;

            var width = mainDisplayInfo.Width;
            var height = mainDisplayInfo.Height;
            xamarinWidth = width / density;
            xamarinHeight = Height / density;


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage()) ;
        }
    }
}
