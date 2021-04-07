using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using Spectral;

namespace KeyboardReflection
{
    class Program
    {
         static Window form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CreateSystemTrayIcon();
            form = new Window();
            Application.Run(form);
        }

        [DllImport("User32.dll")]
         static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
                
        public static Thread LedUpdateThread;
        public static void LedUpdateThead_Task()
        {
            long[] LoadValues = new long[10];
            byte i = 0;

            Led.Initialize();
            Led.SetColor(0, 0, 0);

            int delay = 100; //Target delay between updates in milliseconds

            //Define a bitmap that will be used to hold the screen data while we copy it to an easy-access array of bytes
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);

            //Instantiation of the pixel array requires knowing the scan width of the screen
            /*It is beneficial to do this once rather than in the loop because creating large
              arrays is computationally expensive and they aren't disposed immediately*/
            //I was able to reduce average memory usage from 250MB to 63MB by doing this.
            BitmapData init_screen = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int size = Math.Abs(init_screen.Stride) * bitmap.Height; //Stride * Height IS EQUAL TO Number of pixels * bytes per pixel
            bitmap.UnlockBits(init_screen); //We don't need this anymore
            byte[] pixels = new byte[size]; //Creates the array for direct access to pixel data copied via the Marshal

            while (true)
            {
                //Keep track of how long we take to process a screencapture
                Stopwatch timer = new Stopwatch();
                timer.Start();

                using (Graphics capture = Graphics.FromImage(bitmap))
                {
                    try
                    {
                        //Capture the screen and copy it into the bitmap
                        capture.CopyFromScreen(
                            Screen.PrimaryScreen.Bounds.X,
                            Screen.PrimaryScreen.Bounds.Y,
                            0, 0,
                            bitmap.Size,
                            CopyPixelOperation.SourceCopy);
                    }
                    catch
                    {
                        //The copy operation can fail if the user locks the screen, so handling that exception is a good idea.
                        Thread.Sleep(delay);
                        continue;
                    }

                    //Lock the bitmap. This is required if we want to gain direct access to the pixel data, which we absolutely do.
                    BitmapData screen = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                    //Copy the pixels to the array
                    IntPtr pointer = screen.Scan0;
                    Marshal.Copy(pointer, pixels, 0, size);

                    foreach (var key in KeyMap.LookupTable)
                    {
                        //Calculate an average colour for the area around the position
                        int r, g, b, pixel_count;
                        r = g = b = pixel_count = 0;
                        //Loop over region centered around a key's coordinates
                        for (int y = key.Value.Y - key.Value.height / 2; y <= key.Value.Y + key.Value.height / 2; y += 5)
                        {
                            for (int x = key.Value.X - key.Value.width / 2; x <= key.Value.X + key.Value.width / 2; x += 5)
                            {
                                //Skip out of bounds coordinates
                                if (x < 0 ||
                                    y < 0 ||
                                    x >= Screen.PrimaryScreen.Bounds.Width ||
                                    y >= Screen.PrimaryScreen.Bounds.Height) continue;

                                //Index is the result of a formula for calculating the index to a target pixel
                                //We multiply x by 4 is because pixel data is encoded in 4 bytes: b,g,r,a
                                //Note that screen.Stride is the image width also multiplied by 4
                                //Once you have the index for a desired pixel, an offset of 2,1,0 will yield the red,green,blue values.
                                //The transparency/alpha channel value at offset 3 is seemingly unused because it appears to be a constant 255.
                                long index = (y * screen.Stride) + (x * 4);

                                //Mean average add
                                r += pixels[index + 2];
                                g += pixels[index + 1];
                                b += pixels[index];
                                pixel_count++; //Keep track of how many pixels we are averaging
                            }
                        }
                        if (pixel_count == 0) continue;
                        //Mean average divide
                        r /= pixel_count;
                        g /= pixel_count;
                        b /= pixel_count;

                        if (Flags.saturation_enable)
                        {
                            //Extract hue and lightness from colour
                            RGB2HSL.RgbToHls(r, g, b, out double h, out double l, out double s);
                            //Set saturation to max and change that back to rgb
                            RGB2HSL.HlsToRgb(h, l, Math.Min(1, s * Flags.saturation_factor), out r, out g, out b);
                        }

                        //Maximum value clamping at 255
                        r = Math.Min(r, 255);
                        g = Math.Min(g, 255);
                        b = Math.Min(b, 255);

                        //If enabled, draw the debug squares across the screen to illustrate
                        if (Flags.debug_enable)
                        {
                            IntPtr desktop = GetDC(IntPtr.Zero);
                            using (Graphics g_out = Graphics.FromHdc(desktop))
                            {
                                if (Flags.debug_showscanregion)
                                {
                                    //Outline the scan region
                                    g_out.DrawRectangle(Pens.White,
                                        //Top left point
                                        key.Value.X + (-key.Value.width / 2),
                                        key.Value.Y + (-key.Value.height / 2),
                                        //Dimensions
                                        key.Value.width,
                                        key.Value.height);
                                }
                                if (Flags.debug_showkeynames)
                                {
                                    //Write key name for reference
                                    g_out.DrawString(key.Key.ToString(),
                                        new Font("Arial", 7, FontStyle.Bold),
                                        Brushes.Cyan,
                                        //Position top left with 5px margin
                                        key.Value.X + (-key.Value.width / 2) + 5,
                                        key.Value.Y + (-key.Value.height / 2) + 5);
                                }

                                //Center box containing calculated colour, with 1px white border
                                g_out.FillRectangle(Brushes.White,
                                    key.Value.X - 6, key.Value.Y - 6, 12, 12);
                                g_out.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)),
                                    key.Value.X - 5, key.Value.Y - 5, 10, 10);

                            }
                            ReleaseDC(IntPtr.Zero, desktop);
                        }

                        //Update the led
                        Led.SetColorForLed(key.Key, (byte)r, (byte)g, (byte)b);
                    }
                    bitmap.UnlockBits(screen); //Don't forget to unlock the bitmap at the end
                }
                //Calculate how long we should sleep to wait the rest of the 100 milliseconds
                //Should the elapsed time exceed the desired wait time, the Max function ensures we never pass a value below 0. If that were to happen then an exception would be thrown.
                timer.Stop();
                Thread.Sleep(Math.Max(0, delay - (int)timer.ElapsedMilliseconds));

            }
        }

        public class Flags
        {
            public static bool saturation_enable;
            public static double saturation_factor;
            public static bool debug_enable;
            public static bool debug_showscanregion;
            public static bool debug_showkeynames;
        }

        private static NotifyIcon trayIcon;
        private static void CreateSystemTrayIcon()
        {
            ContextMenu menu = new ContextMenu();
            MenuItem[] items = new MenuItem[]
            {
                new MenuItem("Settings", new EventHandler(notifyIcon_SettingsClick)),
                new MenuItem("Quit",     new EventHandler(notifyIcon_ExitClick))
            };
            menu.MenuItems.AddRange(items);
            trayIcon = new NotifyIcon
            {
                Icon = Properties.Resources.Icon,
                ContextMenu = menu,
                Visible = true
            };
        }
        private static void notifyIcon_SettingsClick(object sender, EventArgs e)
        {
            form.Show();
        }
        private static void notifyIcon_ExitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    class RGB2HSL
    {
        //http://csharphelper.com/blog/2016/08/convert-between-rgb-and-hls-color-models-in-c/
        // Convert an RGB value into an HLS value.
        public static void RgbToHls(int r, int g, int b,
            out double h, out double l, out double s)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = r / 255.0;
            double double_g = g / 255.0;
            double double_b = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h *= 60;
                if (h < 0) h += 360;
            }
        }

        // Convert an HLS value into an RGB value.
        public static void HlsToRgb(double h, double l, double s,
            out int r, out int g, out int b)
        {
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(double_r * 255.0);
            g = (int)(double_g * 255.0);
            b = (int)(double_b * 255.0);
        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }
    }
}