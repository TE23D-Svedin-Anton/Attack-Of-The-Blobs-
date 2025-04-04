    using System;
using System.Drawing;
using System.Numerics;
using Raylib_cs;

    namespace Attackers;
     public class TriAttacker
    {
        public Raylib_cs.Rectangle Hitbox;
        public Raylib_cs.Rectangle PlayerHitbox; 
        
        public int Size = 80;

        public float Speed = 0f;
        public int Hp = 100;
    }

    public class CircAttacker
    {

    public Raylib_cs.Rectangle Hitbox; 
    
    public int radius = 40;
    public float Speed = 0f;
    public string HpText;
    public int Hp = 80;
    }

     public class RectAttacker
    {
        public Raylib_cs.Rectangle Rect;
        public float Speed = 0f;
        public int Hp = 120;
    }