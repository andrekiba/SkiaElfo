using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SkiaElfo.SkiaView), typeof(SkiaElfo.iOS.SkiaViewRenderer))]

namespace SkiaElfo.iOS
{
    public class SkiaViewRenderer : ViewRenderer<SkiaView, NativeSkiaView>
    {
        public SkiaViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SkiaView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                SetNativeControl(new NativeSkiaView(Element));
        }
    }
}
