using System;
using Raylib_cs;
using Attacker;
using CirAttacker;
using TriAttacker;

CirStats cir = new CirStats();
TriStats tri = new TriStats();

List<RectAttacker> rectangles = [];

void SpawnButton() //Skapar en anfallare beroende på vilken knapp som trycks
{
    int RectWidth = 50;
    int spawnX = 200 - (RectWidth/2);
    int spawnY = 500 - RectWidth;
    if(Raylib.IsKeyPressed(KeyboardKey.One))
    {
        rectangles.Add(new RectAttacker() {Rect = new Rectangle(spawnX, spawnY, 50 , 50)}); //Skapar en ny Rektangel i rectangles listan
    }
}

void Draw()
{
    for (int i = 0; i < rectangles.Count; i++)
    {
        RectAttacker rect = rectangles[i];
        Raylib.DrawRectangleRec(rect.Rect, Color.Beige);
    }
}

Raylib.InitWindow(1000,500, "Attack Of The Blobs!");

Raylib.SetTargetFPS(60);

Color Blue = new(0, 130, 255, 255);

while(Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Blue); 
    SpawnButton();
    Draw();
    Raylib.EndDrawing();
} 