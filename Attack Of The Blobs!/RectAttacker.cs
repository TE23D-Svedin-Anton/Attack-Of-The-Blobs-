    using System;
    using Raylib_cs;

    namespace Attacker;
    public class RectAttacker
    {
        private static List<RectAttacker> rectangles = new List<RectAttacker>();
        public int height = 50;
        public int width = 50;
        public int x = 100-25 ;
        public int y = 500-50;

        public RectAttacker(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }