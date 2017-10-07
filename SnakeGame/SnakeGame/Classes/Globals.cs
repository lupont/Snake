using System;
using Microsoft.Xna.Framework;

namespace SnakeGame
{
    public static class Globals
    {
        public static Random RNG         { get; } = new Random();
        public static int    Scale       { get; } = 64;
        public static int    Width       { get; } = 640;
        public static int    Height      { get; } = 640;
        public static int    Columns     { get; } = Width / Scale;
        public static int    Rows        { get; } = Height / Scale;
        public static Rectangle GameArea { get; } = new Rectangle(0, 0, Width, Height);
    }
}