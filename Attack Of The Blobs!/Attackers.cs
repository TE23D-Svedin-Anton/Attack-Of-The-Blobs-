    using System;
using System.Numerics;
using Raylib_cs;

    namespace Attackers;
    public class RectAttacker
    {
        public Rectangle Rect;
        public int Speed = +2;
    }

    public class CircAttacker
{
    public Vector2 Center;
    public int radius = 40;
    public int Speed = +2;
}