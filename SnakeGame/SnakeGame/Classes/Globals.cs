using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;

namespace SnakeGame
{
    public static class Globals
    {
        public static Random RNG     { get; } = new Random();
        public static int    Scale   { get; } = 64;
        public static int    Width   { get; } = 640;
        public static int    Height  { get; } = 640;
        public static int    Columns { get; } = Width / Scale;
        public static int    Rows    { get; } = Height / Scale;
        public static Rectangle GameArea => new Rectangle(0, 0, Width, Height);
    }
}