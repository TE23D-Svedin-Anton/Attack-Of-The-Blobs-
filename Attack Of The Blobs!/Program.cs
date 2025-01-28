using System;
using Raylib_cs;
using Attacker;
using CirAttacker;
using TriAttacker;

CirStats cir = new CirStats();
TriStats tri = new TriStats();

List<RectAttacker> rectangles = new List<RectAttacker>();

Raylib.InitWindow(1000,500, "Attack Of The Blobs!");

Raylib.SetTargetFPS(60);

Color Blue = new(0, 130, 255, 255);

while(Raylib.WindowShouldClose() == false)
{
    if(Raylib.IsKeyPressed(KeyboardKey.One))
    {
        int randomX = Raylib.GetRandomValue(0, Raylib.GetScreenWidth()-50);
        int randomY = Raylib.GetRandomValue(0, Raylib.GetScreenWidth()-50);
        rectangles.Add(new RectAttacker(randomX, randomY));
    }
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Blue); 
    foreach (RectAttacker rect in rectangles)
    {
        Raylib.DrawRectangle(rect.x, rect.y, rect.width, rect.height, Color.Red);
    }
    Raylib.EndDrawing();
} 