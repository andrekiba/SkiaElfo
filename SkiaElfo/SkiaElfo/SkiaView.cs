using System;
using SkiaSharp;
using Xamarin.Forms;

namespace SkiaElfo
{
    public class SkiaView : View, ISkiaViewController
    {
        private readonly Action<SKCanvas, int, int> OnDraw;

        public SkiaView(Action<SKCanvas, int, int> onDraw)
        {
            this.OnDraw = onDraw;
        }

        void ISkiaViewController.SendDraw(SKCanvas canvas)
        {
            Draw(canvas);
        }

        protected virtual void Draw(SKCanvas canvas)
        {
            OnDraw(canvas, (int)Width, (int)Height);
        }
    }
}
