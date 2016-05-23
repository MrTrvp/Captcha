using System.Drawing;
using System.Drawing.Text;
using System.Security;
using System.Windows.Forms;
using dCaptcha.Core.Extensions;
using dCaptcha.UI.Helpers;

namespace dCaptcha.UI.Controls
{
    public class dCaptcha : PictureBox
    {
        public Mode Difficulty { get; set; }

        public SecureString CaptchaCode { get; private set; }

        public dCaptcha()
        {
            CaptchaCode = new SecureString();
            Size = new Size(140, 50);   
            GenerateCaptcha();
        }

        public void GenerateNewCode()
        {
            CaptchaCode = new SecureString();
            GenerateCaptcha();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphic = e.Graphics;
            graphic.Clear(BackColor);

            DrawPhantomText(graphic);
            switch (Difficulty)
            {
                case Mode.Easy:
                    DrawBlobs(e.Graphics);
                    break;
                case Mode.Medium:
                    DrawBlobs(e.Graphics);
                    DrawNoise(e.Graphics);
                    break;
                case Mode.Hard:
                    DrawBlobs(e.Graphics);
                    DrawNoise(e.Graphics);
                    DrawLines(e.Graphics);
                    DrawBoxes(e.Graphics);
                    break;
            }       
                    
            graphic.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawCode(graphic);
            DrawPhantomText(graphic);
        }
         
        private void DrawBlobs(Graphics graphic)
        {
            for (var i = 0; i < dCaptchaRandomHelper.Random.Next(0, 4); i++)
            {
                var x = dCaptchaRandomHelper.Random.Next(Width / 20, Width / 2);
                var y = dCaptchaRandomHelper.Random.Next(Height / 20, Height / 2);  
                var w = dCaptchaRandomHelper.Random.Next(30, 80); 
                var h = dCaptchaRandomHelper.Random.Next(30, 80);

                using (var brush = new SolidBrush(dCaptchaRandomHelper.GetRandomColor(ColorType.Blob)))
                    graphic.FillEllipse(brush, x, y, w, h);
            }
        }

        private void DrawBoxes(Graphics graphic)
        {                                   
            for (var i = 0; i < dCaptchaRandomHelper.Random.Next(5, 30); i++)
            {
                var pointOne = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));
                var pointTwo = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));

                graphic.DrawRectangle(Pens.Black, pointOne.X, pointOne.Y, 2, 2);
                graphic.FillRectangle(Brushes.Black, pointTwo.X, pointTwo.Y, 2, 2);
            }
        }

        private void DrawNoise(Graphics graphic)
        {
            for (var i = 0; i < dCaptchaRandomHelper.Random.Next(5, 30); i++)
            {
                var pointOne = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));
                var pointTwo = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));

                graphic.DrawRectangle(Pens.Black, pointOne.X, pointOne.Y, 2, 2);
                graphic.FillRectangle(Brushes.Black, pointTwo.X, pointTwo.Y, 2, 2);
            }
        }

        private void DrawLines(Graphics graphic)
        {                                       
            for (var i = 0; i < dCaptchaRandomHelper.Random.Next(5, 10); i++)
            {
                var start = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));
                var finish = new Point(dCaptchaRandomHelper.Random.Next(Width), dCaptchaRandomHelper.Random.Next(Height));
                graphic.DrawLine(new Pen(Color.Black), start, finish);
            }    
        }

        private void DrawRotatedText(Graphics graphic, int x, int y, float angle, string text, Font font, Brush brush)
        {
            graphic.TranslateTransform(x, y);
            graphic.RotateTransform(angle);
            graphic.TranslateTransform(-x, -y);

            var size = graphic.MeasureString(text, font);
            graphic.DrawString(text, font, brush, new PointF(x - size.Width / 2.0f, y - size.Height / 2.0f));

            graphic.ResetTransform();
        }

        private void DrawCode(Graphics graphic)
        {
            var points = dCaptchaRandomHelper.GetRandomPoints(5, Height);
            var code = CaptchaCode.ToStringEx().ToCharArray();

            for (var i = 0; i < code.Length; i++)
            {
                var angle = dCaptchaRandomHelper.Random.Next(-35, 35);
                var letter = code[i].ToString();
                using (var font = dCaptchaRandomHelper.GetRandomFont())
                using (var brush = new SolidBrush(dCaptchaRandomHelper.GetRandomColor(ColorType.Regular)))
                    DrawRotatedText(graphic, points[i].X, points[0].Y, angle, letter, font, brush);
            }
        }

        private void DrawPhantomText(Graphics graphic)
        {
            using (var font = new Font("Arial", 16))
            {
                for (var i = 0; i < dCaptchaRandomHelper.Random.Next(5, 25); i++)
                {
                    var color = Color.FromArgb(dCaptchaRandomHelper.Random.Next(1, 200), Color.Black);
                    using (var brush = new SolidBrush(color))
                    {
                        var x = dCaptchaRandomHelper.Random.Next(Width);
                        var y = dCaptchaRandomHelper.Random.Next(Height);
                        var angle = dCaptchaRandomHelper.Random.Next(-25, 25);
                        var letter = dCaptchaRandomHelper.Random.String(1).ToStringEx();
                        DrawRotatedText(graphic, x, y, angle, letter, font, brush);
                    }
                }
            }
        }

        private void GenerateCaptcha()
        {
            var code = dCaptchaRandomHelper.Random.String(5);
            CaptchaCode = code; 
        }

        public enum ColorType
        {
            Regular,
            Blob
        }

        public enum Mode
        {
            Easy = 0,
            Medium = 1,
            Hard = 2
        }  
    }
}     