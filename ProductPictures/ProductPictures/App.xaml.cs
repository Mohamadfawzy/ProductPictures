using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductPictures
{
    public partial class App : Application
    {
        public static double XamarinWidth;
        public static double XamrinHight;
        public App()
        {
            InitializeComponent();
            GetWidth();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private void GetWidth()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            var rotation = mainDisplayInfo.Rotation;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Width (in xamarin.forms units)
            XamarinWidth = width / mainDisplayInfo.Density;
            //Console.WriteLine("\n \n \n xamarin" + XamarinWidth);
            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            XamrinHight = height / mainDisplayInfo.Density;
            // Screen density
            var density = mainDisplayInfo.Density;
        }
    }
}
