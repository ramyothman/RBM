using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
namespace TestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Bitmap imageoriginal = new Bitmap(imageTest1.Image);
            Image image = imageTest1.Image;

            //Bitmap bmp = new Bitmap(image.Width, image.Height);
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Transparent);
            //    g.InterpolationMode = InterpolationMode.NearestNeighbor;
            //    g.PixelOffsetMode = PixelOffsetMode.None;
            //    g.DrawImage(image, Point.Empty);
            //}
            Bitmap n = ChangeColor(imageoriginal, colorPickOld.Color, colorPickNew.Color);
            AForge.Imaging.Filters.HueModifier filter = new AForge.Imaging.Filters.HueModifier(142);
            // apply the filter
            System.Drawing.Bitmap newImage = filter.Apply(imageoriginal);

            //int height = imageoriginal.Height;
            //int width = imageoriginal.Width;
            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        Color origC = imageoriginal.GetPixel(i, j);
            //        Color newC = GetNearestOfBWR(origC, ref imageoriginal);
            //        imageoriginal.SetPixel(i, j, newC);
            //    }
            //}


            imageTest2.Image = (Image)ChangeColor(imageoriginal, new Bitmap(imageTest1.Image.Width, imageTest1.Image.Height), colorPickOld.Color, colorPickNew.Color, colorPicNotChange.Color);

            //imageTest2.Image = TestChangeColor(c, 0, 10, (byte)colorPickNew.Color.GetHue());
        }
        Color GetNearestOfBWR(Color c,ref Bitmap imageoriginal)
        {
            float redness = Math.Abs(180 - c.GetHue()) / 180;
            float brightness = c.GetBrightness();
            float saturation = c.GetSaturation();

            double brightColourfulRedness = Math.Sqrt(redness * redness + brightness * brightness + saturation * saturation);
            if (brightColourfulRedness > 1)
                return Color.FromArgb(255, 0, 0); // red;

            if (brightness > 0.5)
                return Color.FromArgb(255, 255, 255); // white
            return Color.FromArgb(0, 0, 0); // black

            
            
        }
        public Image TestChangeColor(Bitmap bmp, byte minHue,byte maxHue,byte newHue)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmpData.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            for (int c = 0; c < rgbValues.Length; c += 4)
            {
                HSBColor hsb = new HSBColor(Color.FromArgb(
                    rgbValues[c + 3], rgbValues[c + 2],
                    rgbValues[c + 1], rgbValues[c]));
                if (hsb.H >= minHue && hsb.H <= maxHue)
                {
                    hsb.H = Convert.ToByte(newHue);
                }
                Color color = hsb.ToRGB();
                rgbValues[c] = color.B;
                rgbValues[c + 1] = color.G;
                rgbValues[c + 2] = color.R;
                rgbValues[c + 3] = color.A;
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
            return (Image)bmp;
        }

        public  Bitmap ChangeColor(Bitmap scrBitmap, Color oldColor, Color newColor)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
            
            Color actulaColor;
            //make an empty bitmap the same size as scrBitmap
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    //get the pixel from the scrBitmap image
                    actulaColor = scrBitmap.GetPixel(i, j);
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    if (actulaColor.A == 0 && actulaColor.R == 0 && actulaColor.G == 0 && actulaColor.B == 0 ) continue;
                    if (actulaColor.R != oldColor.R && actulaColor.G != oldColor.G && actulaColor.B != oldColor.B)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, actulaColor);
                }
            }
            return newBitmap;
        }
        public Bitmap ChangeColor(Bitmap scrBitmap, Bitmap result, Color oldColor, Color newColor, Color notToChange)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
            // Build a colour map of old to new colour
            ColorMap[] colorMap = BuildArrayOfOldAndNewColours(scrBitmap, oldColor, newColor, notToChange);


            Color actulaColor;
            //make an empty bitmap the same size as scrBitmap
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    //get the pixel from the scrBitmap image
                    actulaColor = scrBitmap.GetPixel(i, j);
                    var map = (from x in colorMap where x.OldColor.A == actulaColor.A && x.OldColor.R == actulaColor.R && x.OldColor.G == actulaColor.G && x.OldColor.B == actulaColor.B select x).FirstOrDefault();
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    if (actulaColor.A == 0 && actulaColor.R == 0 && actulaColor.G == 0 && actulaColor.B == 0) continue;
                    if (actulaColor.R != notToChange.R || notToChange.G != notToChange.G && actulaColor.B != notToChange.B)
                        newBitmap.SetPixel(i, j, map.NewColor);
                    else
                        newBitmap.SetPixel(i, j, actulaColor);
                }
            }
            return newBitmap;
        }
        private Bitmap TestImageTransform(Image source,Bitmap result,Color oldColor,Color newColor,Color notToChange)
        {
            
            {
                // Build a colour map of old to new colour
                ColorMap[] colorMap = BuildArrayOfOldAndNewColours(new Bitmap(source), oldColor, newColor, notToChange);

                // Build image attributes with the map
                var attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);

                // Draw a rectangle the same size as the image
                var rect = new Rectangle(0, 0, source.Width, source.Height);

                // Draw the old image into the new one with one colour mapped to the other
                var g = Graphics.FromImage(result);
                g.DrawImage(source, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);

                return result;
            }
        }

        private ColorMap[] BuildArrayOfOldAndNewColours(Bitmap scrBitmap,Color oldColor,Color newColor,Color notToChange)
        {
            List<ColorMap> colorMap = new List<ColorMap>();
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    ColorMap map = new ColorMap();
                    //get the pixel from the scrBitmap image
                    Color actulaColor = scrBitmap.GetPixel(i, j);
                    map.OldColor = actulaColor;
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    
                    if (actulaColor.R != notToChange.R || notToChange.G != notToChange.G && actulaColor.B != notToChange.B)
                    {
                        map.NewColor = GetDifferenceColor(oldColor, actulaColor, newColor);
                        colorMap.Add(map);
                    }
                    
                }
            }
            return colorMap.ToArray();
            
        }

        private Color GetDifferenceColor(Color mainOldColor,Color oldColor,Color mainNewColor)
        {
            int diffA = Math.Abs(mainOldColor.A - oldColor.A);
            int diffRed = Math.Abs(mainOldColor.R - oldColor.R);
            int diffGreen = Math.Abs(mainOldColor.G - oldColor.G);
            int diffBlue = Math.Abs(mainOldColor.B - oldColor.B);

            //if (diffA < 0)
            //    diffA *= -1;
            //if (diffRed < 0)
            //    diffRed *= -1;
            //if (diffGreen < 0)
            //    diffGreen *= -1;
            //if (diffBlue < 0)
            //    diffBlue *= -1;

            float pcDiffA = (float)diffBlue / 255;
            float pctDiffRed = (float)diffRed / 255;
            float pctDiffGreen = (float)diffGreen / 255;
            float pctDiffBlue = (float)diffBlue / 255;

            int newA = mainNewColor.A + diffA;
            int newRed = mainNewColor.R + diffBlue;
            int newGreen = mainNewColor.G + diffGreen;
            int newBlue = mainNewColor.B + diffBlue;
            if (newRed > 255)
                newRed = newRed - 255;
            if (newGreen > 255)
                newGreen = newGreen - 255;
            if (newBlue > 255)
                newBlue = newBlue - 255;

            return Color.FromArgb(255,newRed,newGreen,newBlue);
        }
    }
}
