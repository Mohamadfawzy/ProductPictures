using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductPictures.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBar : StackLayout
    {
        public event EventHandler TabBarClicked;
        public TabBar()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = TabBarClicked;
            handler?.Invoke(this, new EventArgs());
        }
    }
}