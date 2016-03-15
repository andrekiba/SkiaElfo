using SkiaSharp;
using Xamarin.Forms;

namespace SkiaElfo.Pages
{
    public class ElfoLogoPage : ContentPage
    {
        private static readonly SKColor Orange1 = new SKColor(255, 200, 0);
        private static readonly SKColor Orange2 = new SKColor(255, 150, 0);
        private static readonly SKColor Orange3 = new SKColor(255, 100, 0);

        public ElfoLogoPage()
        {
            Content = new SkiaView(DrawElfoLogo);
        }

        public static void DrawElfoLogo(SKCanvas canvas, int width, int height)
        {
            var totalSize = ((float)height > width ? width : height) * 0.5f;
            var center = new SKPoint((width - totalSize) / 2f, (height - totalSize) / 2f);
            var squareSize = totalSize / 3f;
            var bottomLeft = new SKPoint((width - totalSize) / 2f, (height - totalSize) / 2f);



            var blackSquare1 = SKRect.Create(center.X - totalSize / 2f, center.Y, squareSize, squareSize);
            //var blackSquare2 = SKRect.Create(center.X - size / 2f, center.Y, squareSize, squareSize);
            //var blackSquare3 = SKRect.Create(center.X - size / 2f, center.Y, squareSize, squareSize);
            //var blackSquare4 = SKRect.Create(center.X - size / 2f, center.Y, squareSize, squareSize);
            //var blackSquare5 = SKRect.Create(center.X - size / 2f, center.Y, squareSize, squareSize);
            //var blackSquare6 = SKRect.Create(center.X - size / 2f, center.Y, squareSize, squareSize);

            //var rightRect = SKRect.Create(center.X + size / 2f, center.Y, size, size);

            // draw this at the current location / transformation
            //var rotatedRect = SKRect.Create(0f, 0f, size, size);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                canvas.Clear(SKColors.White);

                paint.Color = SKColors.Black;
                
                // black1
                canvas.DrawRect(blackSquare1, paint);
                // black2
                //canvas.DrawRect(blackSquare2, paint);
                // black3
                //canvas.DrawRect(blackSquare3, paint);
                // black4
                //canvas.DrawRect(blackSquare4, paint);
                // black5
                //canvas.DrawRect(blackSquare5, paint);
                // black6
                //canvas.DrawRect(blackSquare6, paint);

                // save
                canvas.Save();

                // transform
                //canvas.Translate(width / 2f, center.Y);
                //canvas.RotateDegrees(45);

                // draw
                //paint.Color = XamGreen;
                //canvas.DrawRect(rotatedRect, paint);

                // undo transform / restore
                //canvas.Restore();

                // draw
                //paint.Color = XamLtBlue;
                //canvas.DrawRect(rightRect, paint);
            }
        }
    }
}
