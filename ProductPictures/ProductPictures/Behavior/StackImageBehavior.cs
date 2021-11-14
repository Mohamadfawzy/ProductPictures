using ProductPictures.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static System.Diagnostics.Debug;

namespace ProductPictures.Behavior
{
    public class StackImageBehavior : Behavior<StackLayout>
    {
        private Image image;
        private StackLayout stack;
        private PanGestureRecognizer _panGestureRecognizer;
        private TapGestureRecognizer _tapGestureRecognizer;

        ProductDetailsPageVM vm;
        protected override void OnAttachedTo(StackLayout bindable)
        {
            base.OnAttachedTo(bindable);
            stack = bindable as StackLayout;
            _panGestureRecognizer = new PanGestureRecognizer();
            _tapGestureRecognizer = new TapGestureRecognizer();
            bindable?.GestureRecognizers.Add(_panGestureRecognizer);
            bindable?.GestureRecognizers.Add(_tapGestureRecognizer);
            _panGestureRecognizer.PanUpdated += OnPanUpdated;
            _tapGestureRecognizer.Tapped += TapOnImageToZoomInCarousel;
        }
        bool imageCase = true;
        private void TapOnImageToZoomInCarousel(object sender, EventArgs e)
        {
            var stack = sender as StackLayout;
            image = stack.Children[0] as Image;
            vm = BindingContext as ProductDetailsPageVM;
            if (imageCase)
            {
                vm.IsSwipeEnabledVM = false;
                image.TranslationX = 0;
                image.TranslationY = 0;
                image.ScaleTo(2, 100);
                _xOffset = 0.0;
            }
            else
            {
                image.ScaleTo(1, 100);
                image.TranslationX = 0;
                image.TranslationY = 0;
                vm.IsSwipeEnabledVM = true;
            }

            imageCase = imageCase ? false : true;
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
                    vm = BindingContext as ProductDetailsPageVM;
                    image = stack.Children[0] as Image;
                    var incrementX = 0.0;
                    vm.IsSwipeEnabledVM = false;
                    //Carousel.IsSwipeEnabled = false;
                    framePlus = image.Width / image.Scale;
                    frameSalep = image.Width / image.Scale * -1;
                    if (enableSwip)
                        vm.IsSwipeEnabledVM = true;
                    WriteLine($"width: {(int)image.Width} ");
                    WriteLine($"Pan start e.x: {(int)e.TotalX}");
                    break;
                case GestureStatus.Running:
                    WriteLine($"Pan run e.x: {(int)e.TotalX}");
                    incrementX = _xOffset + e.TotalX;

                    if (incrementX <= 180 && incrementX >= -180)
                    {
                        image.TranslationX = incrementX;
                        enableSwip = true;
                        WriteLine($"if: {(int)incrementX}");
                    }

                    image.TranslationY = _yOffset + e.TotalY;
                    WriteLine($"TX: {(int)image.TranslationX} ");
                    break;

                case GestureStatus.Completed:
                    WriteLine($"width: {(int)image.Width} ");
                    //
                    _xOffset = image.TranslationX;
                    _yOffset = image.TranslationY;
                    break;
            }
        }

        protected override void OnDetachingFrom(StackLayout bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable?.GestureRecognizers.Remove(_panGestureRecognizer);
            bindable?.GestureRecognizers.Remove(_tapGestureRecognizer);
            _panGestureRecognizer.PanUpdated -= OnPanUpdated;
        }
    }
}
