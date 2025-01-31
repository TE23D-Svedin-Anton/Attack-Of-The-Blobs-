using System;
using Raylib_cs;
using Attackers;
using TriAttacker;
using System.Numerics;

TriStats tri = new TriStats();

float CooldownTime = 1.0f;
float LastTimeSpawned = 0.0f;

List<RectAttacker> rectangles = [];
List<CircAttacker> circles = [];

void SpawnButton() //Skapar en anfallare beroende på vilken knapp som trycks
{
    int RectWidth = 80;
    int RectspawnX = 200 - (RectWidth/2);
    int RectspawnY = 760 - (RectWidth/2);
    Vector2 CircSpawn = new Vector2(200, 760);


    if(Raylib.IsKeyPressed(KeyboardKey.Three) && ((float)Raylib.GetTime() - LastTimeSpawned >= CooldownTime))
    {
        rectangles.Add(new RectAttacker() {Rect = new Rectangle(RectspawnX, RectspawnY, 80, 80)}); //Skapar en ny Rektangel i rectangles listan
        LastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.One) && ((float)Raylib.GetTime() - LastTimeSpawned >= CooldownTime))
    {
        circles.Add(new CircAttacker() {Center = CircSpawn}); //Skapar en ny Rektangel i rectangles listan
        LastTimeSpawned = (float)Raylib.GetTime();   
    }
}

void Draw() //Ritar alla anfallare som har skapats
{
    for (int i = 0; i < rectangles.Count; i++)
    {
        RectAttacker rect = rectangles[i];
        Raylib.DrawRectangleRec(rect.Rect, Color.Red);
        Raylib.DrawRectangleLinesEx(rect.Rect, 4, Color.Black);
    }

    for (int i = 0; i < circles.Count; i++)
    {
        CircAttacker center = circles[i];
        Raylib.DrawCircleV(center.Center, center.radius + 4, Color.Black);
        Raylib.DrawCircleV(center.Center, center.radius, Color.Blue);

    }
}

void UpdateMovement()
{
    for (int i = 0; i < rectangles.Count; i++)
    {
        RectAttacker rect = rectangles[i];
        rect.Rect.X += rect.Speed;
    }

     for (int i = 0; i < circles.Count; i++)
    {
        CircAttacker center = circles[i];
        center.Center.X += center.Speed;
    }
}

Raylib.InitWindow(1500,800, "Attack Of The Blobs!");

Raylib.SetTargetFPS(60);

Color Blue = new(0, 130, 255, 255);

while(Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Blue); 
    SpawnButton();
    Draw();
    UpdateMovement();
    Raylib.EndDrawing();
} 