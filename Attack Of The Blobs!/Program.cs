using System.Numerics;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using Attackers;
using Raylib_cs;

Raylib.InitWindow(1000,500, "Attack Of The Blobs!");

Raylib.SetTargetFPS(60);

Color Blue = new(0, 130, 255, 255);

void Draw()
{
    RectAttacker rect = new RectAttacker();
    CirAttacker cir = new CirAttacker();
    TriAttacker tri = new TriAttacker();
    Raylib.DrawRectangle(rect.spawnX, rect.spawnY, rect.width, rect.height, Color.Red);
    Raylib.DrawCircle(cir.spawnX, cir.spawnY, cir.radius, Color.DarkBlue);
    Raylib.DrawTriangle(tri.Top,tri.LeftBottom,tri.RightBottom, Color.Green);
}

while(Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Blue); 
    Draw();

    Raylib.EndDrawing();

} 