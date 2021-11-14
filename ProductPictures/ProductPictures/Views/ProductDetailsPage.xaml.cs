using ProductPictures.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProductPictures.ViewModels;
using ProductPictures.Models;
using System.Net.Http;
using System.Net;
using System.IO;

namespace ProductPictures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        private const int headerHeightRequest = 60;
        private const int lengthAnimation = 300;
        private List<Label> labelsListTabSection;
        private Label proviousLableTabSection;
        private ProductDetailsPageVM vm;

        public double Layoutwidth { get => 416; }

        public ProductDetailsPage(Product product)
        {
            InitializeComponent();
            vm = BindingContext as ProductDetailsPageVM;

            // instance
            labelsListTabSection = new List<Label>();
            proviousLableTabSection = new Label();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carousel2.Position = 0;
            imageFloat.Source = Carousel.CurrentItem.ToString();
            gridGallery.IsVisible = false;
            var list = containerTabSection.Children;
            foreach (Label label in list)
            {
                labelsListTabSection.Add(label);
            }
            proviousLableTabSection = labelsListTabSection.FirstOrDefault();
        }

        private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (image != null)
                ResetImage();
            enableSwip = false;
        }
        private void Carousel_body_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            imageFloat.Source = Carousel.CurrentItem.ToString();
        }
        bool imageCase = true;
        private void TapOnImageToZoomInCarousel(object sender, EventArgs e)
        {
            var stack = sender as StackLayout;
            image = stack.Children[0] as Image;

            if (imageCase)
            {
                Carousel2.IsSwipeEnabled = false;
                enableSwip = false;
                image.TranslationX = 0;
                image.TranslationY = 0;
                image.ScaleTo(2, 100);
                currentScale = 2;
                xOffset = image.TranslationX;
                yOffset = image.TranslationY;
                _xOffset = 0.0;
            }
            else
            {
                image.ScaleTo(1, 100);
                image.TranslationX = 0;
                image.TranslationY = 0;
                Carousel2.IsSwipeEnabled = true;
                enableSwip = true;
            }

            imageCase = imageCase ? false : true;
            Reset();
        }
        double postionImage;
        // Mohamed 1
        double screenHeight;
        double imageHeigth;
        int HeightView = 416 + 60;
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //--------------------
            var an = new Animation();
            var mystack = sender as StackLayout;
            var myImage = mystack.Children[0] as Image;

            //--------------------
            imageHeigth = myImage.Height;
            screenHeight = parentGrid.Height;
            postionImage = (screenHeight / 2) - (imageHeigth / 2);

            //--------------------
            stackFloatImage.HeightRequest = HeightView;
            stackFloatImage.IsVisible = true;
            //Stream sourceImage = await DownLoadImages();
            //imageFloat.Source = ImageSource.FromStream(() => sourceImage);// Carousel.CurrentItem.ToString();
            //imageFloat.Source = Carousel.CurrentItem.ToString();
            //stackFloatImage.HeightRequest = 0;

            // --------------------
            an.Add(0, 1, new Animation((x) => stackFloatImage.HeightRequest = x, HeightView, screenHeight));
            an.Add(0, 1, new Animation((x) => imageFloat.TranslationY = x, headerHeightRequest, postionImage));
            an.Commit(Carousel, "cars", length: lengthAnimation, easing: Easing.SinIn, finished: (x, c) =>
            {
                gridGallery.IsVisible = true;
                stackFloatImage.IsVisible = false;
            });

        }
        private void TapBoxcloseGallery(object sender, EventArgs e)
        {
            var an = new Animation();

            stackFloatImage.IsVisible = true;
            //imageFloat.Source = Carousel.CurrentItem.ToString();
            gridGallery.IsVisible = false;

            an.Add(0, 1, new Animation((x) => stackFloatImage.HeightRequest = x, screenHeight, HeightView));
            an.Add(0, 1, new Animation((x) => imageFloat.TranslationY = x, postionImage, headerHeightRequest));
            an.Commit(Carousel, "cars1", length: lengthAnimation, easing: Easing.SinOut, finished: (x, c) =>
            {
                stackFloatImage.IsVisible = false;
            });
        }

        void Reset()
        {
            _xOffset = 0.0;
            currentScale = 1;
            startScale = 1;
            xOffset = 0;
            yOffset = 0;
        }
        void ResetImage()
        {
            image.ScaleTo(1, 100);
            image.TranslationX = 0;
            image.TranslationY = 0;
        }
        double currentScale = 1;
        double startScale = 1;
        double xOffset = 0;
        double yOffset = 0;
        StackLayout stack;
        Image image;
        private async void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {

            if (e.Status == GestureStatus.Started)
            {
                imageCase = true;
                Carousel.IsSwipeEnabled = false;
                var stack = sender as StackLayout;
                image = stack.Children[0] as Image;

                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = image.Scale;
                image.AnchorX = 0.5;
                image.AnchorY = 0.5;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = image.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (image.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = image.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (image.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * image.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * image.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                // image.TranslationX = targetX.Clamp(-image.Width * (currentScale - 1), 0);
                //image.TranslationY = targetY.Clamp(-image.Height * (currentScale - 1), 0);

                // Apply scale factor.
                image.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                imageCase = false;
                // Store the translation delta's of the wrapped user interface element.
                xOffset = image.TranslationX;
                yOffset = image.TranslationY;
            }
        }
        double _xOffset = 0.0;
        double _yOffset = 0.0;
        double framePlus = 0.0;
        double frameSalep = 0.0;
        bool enableSwip = false;
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    var incrementX = 0.0;
                    stack = sender as StackLayout;
                    image = stack.Children[0] as Image;
                    //Carousel.IsSwipeEnabled = false;
                    framePlus = image.Width / image.Scale;
                    frameSalep = image.Width / image.Scale * -1;
                    if (enableSwip)
                        Carousel2.IsSwipeEnabled = true;
                    //WriteLine($"width: {(int)image.Width} ");
                    //WriteLine($"Pan start e.x: {(int)e.TotalX}");
                    break;
                case GestureStatus.Running:
                    //WriteLine($"Pan run e.x: {(int)e.TotalX}");

                    incrementX = _xOffset + e.TotalX;
                    if (image.Scale != 1)
                        if (incrementX <= framePlus && incrementX >= frameSalep)
                        {
                            image.TranslationX = incrementX;
                            WriteLine($"if: {(int)incrementX}");
                        }
                        else
                        {
                            enableSwip = true;
                        }
                    if (enableSwip && Carousel2.Position == 0)
                    {
                        if (e.TotalX > 0)
                        {
                            //image.TranslationX = incrementX;
                            enableSwip = false;
                        }
                    }
                    image.TranslationY = _yOffset + e.TotalY;
                    //WriteLine($"TX: {(int)image.TranslationX}");
                    break;

                case GestureStatus.Completed:
                    //WriteLine($"width: {(int)image.Width}");
                    //
                    _xOffset = image.TranslationX;
                    _yOffset = image.TranslationY;
                    break;
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Carousel.Position = 2;
        }


        readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
        async Task<Stream> DownLoadImages()
        {

            var httpResponse = await _httpClient.GetAsync(Carousel.CurrentItem.ToString());
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return await httpResponse.Content.ReadAsStreamAsync();
            }
            else
            {
                //Url is Invalid
                return null;
            }
        }
        double index = 0;
        double scrollOffcet = 0;
        enum tabs
        {
            Overfiew,
            Colors,
            Reviews,
            Desc,
            Recommendation
        }
        int currentPostion = -1;
        private async void ScrollBody_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY <= bodyContentSecondRow.Bounds.Top)
            {
                if (TabSection.IsVisible)
                    TabSection.IsVisible = false;
                Carousel.TranslationY = e.ScrollY / 2;
                currentPostion = -1;
                //stackFirstSection.TranslationY = -e.ScrollY / 1.5;
            }
            //Carousel.TranslationY = e.ScrollY / 2;
            else if (e.ScrollY > bodyContentSecondRow.Children[0].Bounds.Top && e.ScrollY > bodyContentSecondRow.Children[0].Bounds.Bottom)
            {
                if (!TabSection.IsVisible)
                    TabSection.IsVisible = true;
                if (currentPostion != (int)tabs.Overfiew)
                {
                    labelsListTabSection[0].TextColor = Color.Crimson;
                    proviousLableTabSection = labelsListTabSection[0];
                    currentPostion = 0;
                }
                WriteLine($" 1 top: {bodyContentSecondRow.Bounds.Top}");
            }
            else if (e.ScrollY >= bodyContentSecondRow.Children[2].Bounds.Top &&
                     e.ScrollY <= bodyContentSecondRow.Children[2].Bounds.Bottom)
            {
                if (currentPostion != ((int)tabs.Colors))
                {
                    proviousLableTabSection.TextColor = Color.Black;
                    labelsListTabSection[1].TextColor = Color.Crimson;
                    proviousLableTabSection = labelsListTabSection[1];
                    currentPostion = 1;
                }
                WriteLine($" 1 top: {bodyContentSecondRow.Children[2].Bounds.Top}, bottom: {bodyContentSecondRow.Children[2].Bounds.Bottom}");

                // _ = TabSection.ScrollToAsync(labelsListTabSection[1], ScrollToPosition.MakeVisible, true);
            }
            else if (e.ScrollY >= bodyContentSecondRow.Children[4].Bounds.Top &&
                     e.ScrollY <= bodyContentSecondRow.Children[4].Bounds.Bottom)
            {
                if (currentPostion != ((int)tabs.Reviews))
                {
                    proviousLableTabSection.TextColor = Color.Black;
                    labelsListTabSection[2].TextColor = Color.Crimson;
                    proviousLableTabSection = labelsListTabSection[2];
                    currentPostion = 2;
                }
                
                //_ = TabSection.ScrollToAsync(labelsListTabSection[2], ScrollToPosition.MakeVisible, true);
            }
            
        }
        void ChangeLableMode(int index, Label label,int postion)
        {
            if (currentPostion == ((int)tabs.Colors)) return;
            proviousLableTabSection.TextColor = Color.Black;
            label.TextColor = Color.Crimson;
            proviousLableTabSection = label;
            currentPostion = postion;
        }
        private void TabSection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            //TabSection1.ScrollTo(2, position:ScrollToPosition.MakeVisible, animate: true);// (labelsListTabSection[1], ScrollToPosition.MakeVisible, true);
        }
    } // end class
}