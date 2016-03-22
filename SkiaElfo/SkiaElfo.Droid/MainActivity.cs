using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SkiaElfo.Droid
{
    [Activity(Label = "SkiaElfo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // set up resource paths
            string fontName = "compacta.ttf";
            string fontPath = Path.Combine(CacheDir.AbsolutePath, fontName);
            using (var asset = Assets.Open(fontName))
            using (var dest = File.Open(fontPath, FileMode.Create))
            {
                asset.CopyTo(dest);
            }

            ResourceUtility.FontPath = fontPath;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

