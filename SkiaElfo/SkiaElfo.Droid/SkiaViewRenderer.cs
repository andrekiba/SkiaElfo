using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SkiaElfo.SkiaView), typeof(SkiaElfo.Droid.SkiaViewRenderer))]

namespace SkiaElfo.Droid
{
    public class SkiaViewRenderer : ViewRenderer<SkiaView, NativeSkiaView>
    {
        private NativeSkiaView view;

        public SkiaViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SkiaView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                SetNativeControl(new NativeSkiaView(Context, Element));
        }
    }
}