using SkiaSharp;
using Xamarin.Forms;

namespace SkiaElfo.Pages
{
    public class ElfoLogoPage : ContentPage
    {
        private static readonly SKColor Orange1 = new SKColor(255, 200, 0);
        private static readonly SKColor Orange2 = new SKColor(255, 150, 0);
        private static readonly SKColor Orange3 = new SKColor(255, 100, 0);
        private static readonly SKColor Green = new SKColor(0x77, 0xd0, 0x65);
        private static readonly SKColor Purple = new SKColor(0xb4, 0x55, 0xb6);

        public ElfoLogoPage()
        {
            Content = new SkiaView(DrawElfoLogo);
        }

        public static void DrawElfoLogo(SKCanvas canvas, int width, int height)
        {
            var totalSize = ((float)height > width ? width : height) * 0.5f;
            var squareSize = totalSize / 3f;
            var topLeft = new SKPoint((width - totalSize) / 2f, (height - totalSize) / 2f);

            var p1 = new SKPoint((width - totalSize) / 2f, (height - totalSize) / 2f);
            var p2 = new SKPoint(p1.X + squareSize, p1.Y);
            var p3 = new SKPoint(p2.X + squareSize, p2.Y);

            var p4 = new SKPoint(p1.X, p1.Y + squareSize);
            var p5 = new SKPoint(p4.X + squareSize, p4.Y);
            var p6 = new SKPoint(p5.X + squareSize, p5.Y);

            var p7 = new SKPoint(p1.X, p4.Y + squareSize);
            var p8 = new SKPoint(p7.X + squareSize, p7.Y);
            var p9 = new SKPoint(p8.X + squareSize, p8.Y);

            var blackSquare1 = SKRect.Create(p1.X, p1.Y, squareSize, squareSize);
            var blackSquare2 = SKRect.Create(p2.X, p2.Y, squareSize, squareSize);
            var blackSquare3 = SKRect.Create(p3.X, p3.Y, squareSize, squareSize);
            var blackSquare4 = SKRect.Create(p4.X, p4.Y, squareSize, squareSize);
            var blackSquare5 = SKRect.Create(p5.X, p5.Y, squareSize, squareSize);
            var blackSquare6 = SKRect.Create(p6.X, p6.Y, squareSize, squareSize);
            var orangeSquare1 = SKRect.Create(p7.X, p7.Y, squareSize, squareSize);
            var whiteSquare1 = SKRect.Create(p8.X, p8.Y, squareSize, squareSize);
            var whiteSquare2 = SKRect.Create(p9.X, p9.Y, squareSize, squareSize);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.StrokeCap = SKStrokeCap.Square;
                paint.StrokeWidth = 3;

                canvas.Clear(Green);

                paint.Color = SKColors.Black;
                
                // black1
                canvas.DrawRect(blackSquare1, paint);
                // black2
                canvas.DrawRect(blackSquare2, paint);
                // black3
                canvas.DrawRect(blackSquare3, paint);
                // black4
                canvas.DrawRect(blackSquare4, paint);
                // black5
                canvas.DrawRect(blackSquare5, paint);
                // black6
                canvas.DrawRect(blackSquare6, paint);

                paint.Color = Orange1;
                // orange1
                canvas.DrawRect(orangeSquare1, paint);

                paint.Color = SKColors.White;
                // white1
                canvas.DrawRect(whiteSquare1, paint);
                // white2
                canvas.DrawRect(whiteSquare2, paint);

                //setto stroke per poter disegnare le linee
                paint.IsStroke = true;
                
                //linee bianche
                using (var path = new SKPath())
                {
                    path.MoveTo(p4.X, p4.Y);
                    path.LineTo(p6.X + squareSize, p6.Y);

                    path.MoveTo(p2.X, p2.Y);
                    path.LineTo(p8.X, p8.Y);

                    path.MoveTo(p3.X, p3.Y);
                    path.LineTo(p9.X, p9.Y);

                    canvas.DrawPath(path, paint);
                }

                paint.Color = SKColors.Black;

                //linee nere
                using (var path = new SKPath())
                {
                    path.MoveTo(p8.X, p8.Y);
                    path.LineTo(p8.X, p8.Y + squareSize);

                    path.MoveTo(p9.X, p9.Y);
                    path.LineTo(p9.X, p9.Y + squareSize);

                    canvas.DrawPath(path, paint);
                }

                //tolgo stroke
                paint.IsStroke = false;

                //disegno i 2 quadrati colorati ruotati
                canvas.Save();

                paint.Color = Orange2;
                var orangeSquare2 = SKRect.Create(0, 0, squareSize, squareSize);
                canvas.Translate(p8.X - 10, p8.Y + 10);
                canvas.RotateDegrees(-15);
                canvas.DrawRect(orangeSquare2, paint);
                canvas.Restore();

                paint.Color = Orange3;
                var orangeSquare3 = SKRect.Create(0, 0, squareSize, squareSize);
                canvas.Translate(p9.X, p9.Y + 10);
                canvas.RotateDegrees(-30);
                canvas.DrawRect(orangeSquare3, paint);
                canvas.Restore();
            }    
        }
    }
}
