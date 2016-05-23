using System.Collections.Generic;
using System.Drawing;
using dCaptcha.Core.Helpers;                  

namespace dCaptcha.UI.Helpers
{
    public static class dCaptchaRandomHelper
    {                       
        public static readonly SecureRandom Random;  
        private static readonly string[] FontNames;   
        private static readonly Color[] RegularColors;
        private static readonly Color[] BlobColors;

        static dCaptchaRandomHelper()
        {
            Random = new SecureRandom();
            FontNames = new []
            {
                "Arial",
                "Verdana",
                "Segui UI",
                "Consolas",
                "Calibri"
            };  
            
            RegularColors = new[]
            {
                Color.Black
                //Color.Red,
                //Color.Blue,
                //Color.Green,
                //Color.Black,
                //Color.Orange,
                //Color.Purple,
            };

            BlobColors = new[]
            {
                Color.DarkGray,
                Color.DarkSlateGray,
                SystemColors.Highlight,
                                
                // Color.Yellow,
                //  Color.Blue
            };
        }

        public static Point[] GetRandomPoints(int count, int height)
        {
            const int yMargin = 20;
            const int xMargin = 20;
            var points = new List<Point>();

            var control = new Point(Random.Next(20, xMargin + 10), Random.Next(yMargin, height - yMargin));

            points.Add(control);
            var lastXPos = control.X;
            for (var i = 0; i < count - 1; i++)
            {
                var point = new Point(Random.Next(lastXPos + xMargin, lastXPos + 24), Random.Next(yMargin, height - yMargin));

                lastXPos = point.X;
                points.Add(point);
            }
            return points.ToArray();
        }

        public static Color GetRandomColor(Controls.dCaptcha.ColorType type)
        {                     
            switch (type)
            {
                case Controls.dCaptcha.ColorType.Regular:
                    return RegularColors[Random.Next(RegularColors.Length)]; 
                default:
                    return BlobColors[Random.Next(BlobColors.Length)];  
            }
        }

        public static Font GetRandomFont()
        {
            var fontName = FontNames[Random.Next(FontNames.Length)];
            var fontSize = Random.Next(18, 22);
            return new Font(fontName, fontSize, FontStyle.Bold);
        }
    }
}      