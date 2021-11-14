using AwesomeFonts;
using ProductPictures.Data;
using ProductPictures.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HotKeyData))]

namespace ProductPictures.Data
{
    public class HotKeyData : IData<HotKey>
    {
        IEnumerable<HotKey> list;
        public Task Add()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotKey>> AllData()
        {
            list = new List<HotKey>
            {
                new HotKey {Name = "Categories", BackgroundColor=Color.PaleVioletRed, Image= IconFont.FormatListBulletedType },
                new HotKey {Name = "currency",BackgroundColor=Color.DarkGoldenrod, Image=IconFont.StarShootingOutline},
                new HotKey {Name = "Gifts",BackgroundColor=Color.DarkCyan, Image=IconFont.GiftOpen},
                new HotKey {Name = "Fashion Picks",BackgroundColor=Color.DarkSlateBlue, Image=IconFont.WeatherNight},
                new HotKey {Name = "Coupon holders",BackgroundColor=Color.Crimson, Image=IconFont.Cash },
                new HotKey {Name = "Hadatat discoveries And long text her",BackgroundColor=Color.Crimson, Image=IconFont.LightbulbOn },
                new HotKey {Name = "style zone ",BackgroundColor=Color.DarkSlateBlue, Image=IconFont.MapClockOutline },
            };
            return Task.FromResult(list);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public HotKey FindOne(HotKey id)
        {
            throw new NotImplementedException();
        }
    }
}
