using System;
using System.Drawing;

namespace Cybersecurity_chatbot
{
    public class Logo
    {
        public Logo()
        {
            // get the project location
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            //replacing the bin\Debug\netcoreapp3.1 with the image folder
            string updated_path = path_project.Replace("bin\\Debug\\", "");

            string full_path = System.IO.Path.Combine(updated_path, "logo.jpg");

            //Ascii art for the logo
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new System.Drawing.Size(90, 50));

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int blue = (int)(pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = blue > 200 ? ' ' : blue > 150 ? '.' : blue > 100 ? '*' : blue > 50 ? '+' : ':';
                    Console.Write(asciiChar);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(" ");
            }
        }
    }
}