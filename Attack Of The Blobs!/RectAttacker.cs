using System;
using System.Drawing;
using System.Numerics;
using Raylib_cs;

namespace Attackers;

public class RectAttacker
{
    public int height = 50;
    public int width = 50;
    public int spawnX = 100-25 ;
    public int spawnY = 500-50;
}

public class CirAttacker
{
    public int radius = 25;
    public int spawnX = 50;
    public int spawnY = 500 - 25;
}

public class TriAttacker
{
    public Vector2 Top = new Vector2(150,475-25);
    public Vector2 LeftBottom = new Vector2(150-25,475+25);
    public Vector2 RightBottom = new Vector2(150+25,475+25);
}

