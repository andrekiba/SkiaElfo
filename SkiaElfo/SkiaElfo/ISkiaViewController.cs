using SkiaSharp;
using Xamarin.Forms;

namespace SkiaElfo
{
    public interface ISkiaViewController : IViewController
    {
        void SendDraw(SKCanvas canvas);
    }
}
