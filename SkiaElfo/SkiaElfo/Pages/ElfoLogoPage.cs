﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

            //var stack = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};
            //stack.Children.Add(new SkiaView(DrawElfoLogo));

            //Content = stack;
        }

        public void DrawElfoLogo(SKCanvas canvas, int width, int height)
        {
            //dimensione totale quadrati
            var squareTotalSize = ((float)height > width ? width : height) * 0.25f;
            //dimensioni quadrato
            var squareSize = squareTotalSize / 3f;
            //dimensione totale logo
            const int spacing = 20;
            var logoTotalSize = squareTotalSize * 3f + spacing;

            /*

            P1_ _ _ _ _ P2 _ _ _ _ _P3 _ _ _ _ _ 
            |           |           |           |
            |           |           |           |
            |           |           |           |
            |           |           |           |
            P4_ _ _ _ _ P5 _ _ _ _ _P6 _ _ _ _ _|
            |           |           |           |
            |           |           |           |
            |           |           |           |
            |           |           |           |
            P7_ _ _ _ _ P8 _ _ _ _ _P9 _ _ _ _ _|
            |           |           |           |
            |           |           |           |
            |           |           |           |
            |           |           |           |
            |_ _ _ _ _ _|_ _ _ _ _ _|_ _ _ _ _ _|  

            */

            var p1 = new SKPoint((width - logoTotalSize) / 2f, (height - squareTotalSize) / 2f);
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
                paint.StrokeWidth = 2;

                canvas.Clear(Green);

                paint.Color = SKColors.Black;
                canvas.DrawRect(blackSquare1, paint);
                canvas.DrawRect(blackSquare2, paint);
                canvas.DrawRect(blackSquare3, paint);
                canvas.DrawRect(blackSquare4, paint);
                canvas.DrawRect(blackSquare5, paint);
                canvas.DrawRect(blackSquare6, paint);

                paint.Color = Orange1;
                canvas.DrawRect(orangeSquare1, paint);

                paint.Color = SKColors.White;
                canvas.DrawRect(whiteSquare1, paint);
                canvas.DrawRect(whiteSquare2, paint);

                //setto stroke per poter disegnare le linee
                paint.IsStroke = true;
                paint.Color = SKColors.DimGray;
                //linee grigie
                using (var path = new SKPath())
                {
                    path.MoveTo(p4.X, p4.Y);
                    path.LineTo(p6.X + squareSize, p6.Y);

                    path.MoveTo(p7.X, p7.Y);
                    path.LineTo(p9.X + squareSize, p9.Y);

                    path.MoveTo(p2.X, p2.Y);
                    path.LineTo(p8.X, p8.Y + squareSize);

                    path.MoveTo(p3.X, p3.Y);
                    path.LineTo(p9.X, p9.Y + squareSize);

                    path.MoveTo(p1.X, p1.Y);
                    path.LineTo(p7.X, p7.Y + squareSize);
                    path.LineTo(p9.X + squareSize, p9.Y + squareSize);
                    path.LineTo(p3.X + squareSize, p3.Y);
                    path.LineTo(p1.X, p1.Y);

                    canvas.DrawPath(path, paint);
                }

                //tolgo stroke
                paint.IsStroke = false;

                //disegno i 2 quadrati colorati ruotati
                canvas.Save();

                paint.Color = Orange2;
                var orangeSquare2 = SKRect.Create(0, 0, squareSize, squareSize);
                canvas.Translate(p8.X - 5, p8.Y + 5);
                canvas.RotateDegrees(-15);
                canvas.DrawRect(orangeSquare2, paint);

                canvas.Restore();
                canvas.Save();

                paint.Color = Orange3;
                var orangeSquare3 = SKRect.Create(0, 0, squareSize, squareSize);
                canvas.Translate(p9.X, p9.Y + 5);
                canvas.RotateDegrees(-30);
                canvas.DrawRect(orangeSquare3, paint);
                canvas.Restore();

                const string text = "Elfo";
                var assembly = typeof(ElfoLogoPage).GetTypeInfo().Assembly;
                var fontName = assembly.GetName().Name + ".Fonts.compacta.ttf";

                using (var resource = assembly.GetManifestResourceStream(fontName))
                using (var stream = new SKManagedStream(resource))
                using (var tf = SKTypeface.FromStream(stream))
                {
                    paint.Color = SKColors.Black;
                    paint.TextSize = squareSize * 3.66f;
                    paint.Typeface = tf;

                    canvas.DrawText(text, p9.X + squareSize + spacing, p9.Y + squareSize, paint);
                }
            }
        }

        public void DrawElfoText(SKCanvas canvas, int width, int height)
        {
            const string text = "Elfo";
            using (var paint = new SKPaint())
            {
                canvas.Clear(SKColors.White);
                paint.IsAntialias = true;

                using (var tf = SKTypeface.FromFile(ResourceUtility.FontPath))
                {
                    paint.Color = Orange2;
                    paint.TextSize = 60;
                    paint.Typeface = tf;

                    canvas.DrawText(text, 50, 150, paint);
                }

                var assembly = typeof(ElfoLogoPage).GetTypeInfo().Assembly;
                var fontName = assembly.GetName().Name + ".Fonts.compacta.ttf";

                using (var resource = assembly.GetManifestResourceStream(fontName))
                using (var stream = new SKManagedStream(resource))
                using (var tf = SKTypeface.FromStream(stream))
                {
                    paint.Color = Orange3;
                    paint.TextSize = 60;
                    paint.Typeface = tf;

                    canvas.DrawText(text, 50, 200, paint);
                }
            }
        }
    }
}
