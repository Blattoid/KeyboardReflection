using Spectral;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyboardReflection
{
    class KeyMap
    {
        public static Dictionary<LedName, KeyData> LookupTable = new Dictionary<LedName, KeyData>()
        {
            //There was no easy way to make this. I had to manually measure the location of each key and the size if it had unusual dimensions.
            //My keyboard is a Corsair STRAFE RGB MK-2 so the lookup table is based on that.

            { LedName.Escape,         new KeyData(38,86) },
            { LedName.F1,             new KeyData(232,86) },
            { LedName.F2,             new KeyData(347,86) },
            { LedName.F3,             new KeyData(462,86) },
            { LedName.F4,             new KeyData(577,86) },
            { LedName.F5,             new KeyData(770,86) },
            { LedName.F6,             new KeyData(884,86) },
            { LedName.F7,             new KeyData(1001,86) },
            { LedName.F8,             new KeyData(1116,86) },
            //Unfortunately, the Corsair logo is not controllable through this library.
            { LedName.F9,             new KeyData(1308,86) },
            { LedName.F10,            new KeyData(1422,86) },
            { LedName.F11,            new KeyData(1537,86) },
            { LedName.F12,            new KeyData(1652,86) },
            { LedName.PrintScreen,    new KeyData(1799,86) },
            { LedName.ScrollLock,     new KeyData(1915,86) },
            { LedName.Pause,          new KeyData(2030,86) },
            { LedName.Mute,           new KeyData(2180,44, 1.4,0.6) },
            { LedName.Stop,           new KeyData(2180,44, 1.4,0.6) },
            { LedName.PreviousTrack,  new KeyData(2290,44, 1.4,0.6) },
            { LedName.PlayPause,      new KeyData(2400,44, 1.4,0.6) },
            { LedName.NextTrack,      new KeyData(2510,44, 1.4,0.6) },

            { LedName.Tilde,          new KeyData(37,427) },
            { LedName.One,            new KeyData(154,427) },
            { LedName.Two,            new KeyData(269,427) },
            { LedName.Three,          new KeyData(384,427) },
            { LedName.Four ,          new KeyData(499,427) },
            { LedName.Five,           new KeyData(615,427) },
            { LedName.Six,            new KeyData(731,427) },
            { LedName.Seven,          new KeyData(845,427) },
            { LedName.Eight,          new KeyData(961,427) },
            { LedName.Nine,           new KeyData(1077,427) },
            { LedName.Zero,           new KeyData(1193,427) },
            { LedName.Minus,          new KeyData(1307,427) },
            { LedName.Plus,           new KeyData(1422,427) },
            { LedName.Backspace,      new KeyData(1595,427, 2.6) },
            { LedName.Insert,         new KeyData(1799,427) },
            { LedName.Home,           new KeyData(1913,427) },
            { LedName.PageUp,         new KeyData(2030,427) },
            { LedName.NumLock,        new KeyData(2176,427) },
            { LedName.Divide,         new KeyData(2292,427) },
            { LedName.Multiply,       new KeyData(2407,427) },
            { LedName.Subtract,       new KeyData(2522,427) },

            { LedName.Tab,            new KeyData(70,661, 1.8) },
            { LedName.Q,              new KeyData(211,661) },
            { LedName.W,              new KeyData(328,661) },
            { LedName.E,              new KeyData(443,661) },
            { LedName.R,              new KeyData(558,661) },
            { LedName.T,              new KeyData(673,661) },
            { LedName.Y,              new KeyData(788,661) },
            { LedName.U,              new KeyData(904,661) },
            { LedName.I,              new KeyData(1019,661) },
            { LedName.O,              new KeyData(1134,661) },
            { LedName.P,              new KeyData(1249,661) },
            { LedName.LeftBracket,    new KeyData(1364,661) },
            { LedName.RightBracket,   new KeyData(1479,661) },
            { LedName.Enter,          new KeyData(1624,661, 1.8) },
            { LedName.Delete,         new KeyData(1799,661) },
            { LedName.End,            new KeyData(1914,661) },
            { LedName.PageDown,       new KeyData(2030,661) },
            { LedName.Numpad7,        new KeyData(2175,661) },
            { LedName.Numpad8,        new KeyData(2291,661) },
            { LedName.Numpad9,        new KeyData(2406,661) },
            { LedName.Add,            new KeyData(2522,735, 1.0,2.6) },

            { LedName.CapsLock,       new KeyData(81,894, 1.8) },
            { LedName.A,              new KeyData(240,894) },
            { LedName.S,              new KeyData(355,894) },
            { LedName.D,              new KeyData(471,894) },
            { LedName.F,              new KeyData(587,894) },
            { LedName.G,              new KeyData(701,894) },
            { LedName.H,              new KeyData(816,894) },
            { LedName.J,              new KeyData(932,894) },
            { LedName.K,              new KeyData(1047,894) },
            { LedName.L,              new KeyData(1162,894) },
            { LedName.Semicolon,      new KeyData(1277,894) },
            { LedName.Quote,          new KeyData(1392,894) },
            { LedName.NonUsTilde,     new KeyData(1507,894) },
            { LedName.Numpad4,        new KeyData(2176,894) },
            { LedName.Numpad5,        new KeyData(2290,894) },
            { LedName.Numpad6,        new KeyData(2406,894) },

            { LedName.LeftShift,      new KeyData(50,1131, 1.4) },
            { LedName.NonUsBackslash, new KeyData(181,1131) },
            { LedName.Z,              new KeyData(297,1131) },
            { LedName.X,              new KeyData(413,1131) },
            { LedName.C,              new KeyData(528,1131) },
            { LedName.V,              new KeyData(644,1131) },
            { LedName.B,              new KeyData(758,1131) },
            { LedName.N,              new KeyData(874,1131) },
            { LedName.M,              new KeyData(989,1131) },
            { LedName.Comma,          new KeyData(1104,1131) },
            { LedName.Period,         new KeyData(1220,1131) },
            { LedName.Slash,          new KeyData(1335,1131) },
            { LedName.RightShift,     new KeyData(1550,1131, 3.6) },
            { LedName.UpArrow,        new KeyData(1914,1131) },
            { LedName.Numpad1,        new KeyData(2177,1131) },
            { LedName.Numpad2,        new KeyData(2293,1131) },
            { LedName.Numpad3,        new KeyData(2407,1131) },
            { LedName.NumpadEnter,    new KeyData(2522,1235, 1.0,2.6) },

            { LedName.LeftControl,    new KeyData(65,1355, 1.8) },
            { LedName.LeftWindows,    new KeyData(209,1355) },
            { LedName.LeftAlt,        new KeyData(399,1355, 1.4) },
            { LedName.Spacebar,       new KeyData(787,1355, 2) }, //The led is only a point on the spacebar, doesn't visually make sense to average the entire area of the bar.
            { LedName.RightAlt,       new KeyData(1233,1355, 1.4) },
            { LedName.RightWindows,   new KeyData(1363,1355) },
            { LedName.Applications,   new KeyData(1479,1355) },
            { LedName.RightControl,   new KeyData(1623,1355, 1.8) },
            { LedName.LeftArrow,      new KeyData(1798,1355) },
            { LedName.DownArrow,      new KeyData(1915,1355) },
            { LedName.RightArrow,     new KeyData(2031,1355) },
            { LedName.Numpad0,        new KeyData(2234,1355, 2.6) },
            { LedName.Decimal,        new KeyData(2408,1355) }
        };

        public class KeyData
        {
            public readonly int X, Y, width, height;
            /// <summary>
            /// This class is a brief description of a keycap's position and size on a grid the size of the primary display.
            /// </summary>
            /// <param name="X">The X coordinate of the center of the keycap.</param>
            /// <param name="Y">The Y coordinate of the center of the keycap.</param>
            /// <param name="width">Allows scaling the width of the keycap from the default of 1. For example, the backspace key is twice as wide than normal.</param>
            /// <param name="height">Allows scaling the height of the keycap from the default of 1. For example, the numberpad enter is twice as tall than normal.</param>
            public KeyData(int X, int Y, double width = 1.0, double height = 1.0)
            {
                //Scale the values to be correct for different resolution monitors
                this.X = (int)Map(X, 0, 2560, 0, Screen.PrimaryScreen.Bounds.Width);
                this.Y = (int)Map(Y, 0, 1440, 0, Screen.PrimaryScreen.Bounds.Height);
                this.width = (int)(Screen.PrimaryScreen.Bounds.Width / 2560.0 * width * 100);
                this.height = (int)(Screen.PrimaryScreen.Bounds.Height / 1440.0 * height * 170);
            }
        }

        //Port of the Arduino's map function because it's so darn useful
        private static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}