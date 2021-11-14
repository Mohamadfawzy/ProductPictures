using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static System.Diagnostics.Debug;
namespace ProductPictures.Behavior
{
    public class CarouselViewBehavior : Behavior<CarouselView>
    {
        private PanGestureRecognizer _panGestureRecognizer;
        private CarouselView Carousel;
        protected override void OnAttachedTo(CarouselView bindable)
        {
            base.OnAttachedTo(bindable);
            Carousel = bindable;
        }

        protected override void OnDetachingFrom(CarouselView bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        private void OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {

        }
    }
}
