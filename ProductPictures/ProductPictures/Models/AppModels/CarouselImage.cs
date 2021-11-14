using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProductPictures.Models.AppModels
{
    public class CarouselImage : INotifyPropertyChanged
    {
        double imageTranslationX { get; set; }
        double imageTranslationY { get; set; }
        double imageSize { get; set; }
        public CarouselImage()
        {

        }
        public string Image { get; set; }
        public double ImageTranslationX
        {
            get => imageTranslationX;
            set
            {
                imageTranslationX = value;
                OnPropertyChanged();
            }
        }

        public double ImageTranslationY { get; set; }
        public double ImageSize { get; set; }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
