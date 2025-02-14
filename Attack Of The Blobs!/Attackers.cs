    using System;
using System.Drawing;
using System.Numerics;
using Raylib_cs;

    namespace Attackers;

    public class CircAttacker
    {
    public Vector2 Position;
    public int radius = 40;
    public float Speed = +2.0f;
    }

    public class TriAttacker
    {
        public Vector2 Position;
        public int Size = 80;

        public float Speed = +0.8f;
    }

     public class RectAttacker
    {
        public Raylib_cs.Rectangle Rect;
        public float Speed = +0.6f;
    }