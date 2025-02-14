using System;
using Raylib_cs;
using Attackers;
using System.Numerics;

float CooldownTime = 2.0f;
float PlrLastTimeSpawned = 0.0f;
float EnemyLastTimeSpawned = 0.0f;

List<CircAttacker> PlrCircles = [];
List<CircAttacker> EnemyCircles = [];
List<CircAttacker> EnemyCirHitbox =[];
List<TriAttacker> PlrTriangles = [];
List<TriAttacker> EnemyTriangles = [];
List<TriAttacker> EnemyTriHitbox =[];
List<RectAttacker> PlrRectangles = [];
List<RectAttacker> EnemyRectangles = [];

void SpawnButton() //Skapar en anfallare beroende på vilken knapp som trycks
{
    int PlrSpawnX = 200;
    int EnemySpawnX = 1300;
    int SpawnY = 760;
    Vector2 PlrCircSpawn = new Vector2(200, 760);
    Vector2 EnemyCircSpawn = new Vector2(1300, 760);
    
    if(Raylib.IsKeyPressed(KeyboardKey.One) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= CooldownTime))
    {
        PlrCircles.Add(new CircAttacker() {Position = PlrCircSpawn}); //Skapar en ny Rektangel i rectangles listan
        PlrLastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.Eight) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= CooldownTime))
    {
        EnemyCircles.Add(new CircAttacker() {Position = EnemyCircSpawn}); //Skapar en ny Rektangel i rectangles listan
        EnemyCirHitbox.Add(new CircAttacker () {Hitbox = new Rectangle(EnemySpawnX - 40, SpawnY - 40,80,80) });
        EnemyLastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.Two) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= CooldownTime))
    {
        PlrTriangles.Add(new TriAttacker() {Position = new Vector2(PlrSpawnX, SpawnY - 40)}); //Skapar en ny Rektangel i rectangles listan
        PlrLastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.Nine) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= CooldownTime))
    {
        EnemyTriangles.Add(new TriAttacker() {Position = new Vector2(EnemySpawnX, SpawnY - 40)}); //Skapar en ny Rektangel i rectangles listan
        EnemyTriHitbox.Add(new TriAttacker () {Hitbox = new Rectangle(EnemySpawnX - 40, SpawnY - 40,80,80) });
        EnemyLastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.Three) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= CooldownTime))
    {
        PlrRectangles.Add(new RectAttacker() {Rect = new Rectangle(PlrSpawnX - 40, SpawnY - 40, 80, 80)}); //Skapar en ny Rektangel i rectangles listan
        PlrLastTimeSpawned = (float)Raylib.GetTime();   
    }

    if(Raylib.IsKeyPressed(KeyboardKey.Zero) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= CooldownTime))
    {
        EnemyRectangles.Add(new RectAttacker() {Rect = new Rectangle(EnemySpawnX - 40, SpawnY - 40, 80, 80)}); //Skapar en ny Rektangel i rectangles listan
        EnemyLastTimeSpawned = (float)Raylib.GetTime();   
    }
}

void Draw() //Ritar alla spelarens och motståndarens anfallare som har skapats
{
    for (int i = 0; i < PlrCircles.Count; i++)
    {
        CircAttacker center = PlrCircles[i];
        Raylib.DrawCircleV(center.Position, center.radius, Color.Black);
        Raylib.DrawCircleV(center.Position, center.radius - 4, Color.Blue);
    }

    for (int i = 0; i < EnemyCircles.Count; i++)
    {
        CircAttacker center = EnemyCircles[i];
        CircAttacker Hit = EnemyCirHitbox[i];
        Raylib.DrawCircleV(center.Position, center.radius, Color.Black);
        Raylib.DrawCircleV(center.Position, center.radius - 4, Color.Blue);
        Raylib.DrawRectangleRec(Hit.Hitbox, new Color(255,255,255,0));
        Raylib.DrawRectangleLinesEx(Hit.Hitbox, 4, Color.Black);
    }
     
    for (int i = 0; i < PlrTriangles.Count; i++)
    {
        TriAttacker tri = PlrTriangles[i];
        Vector2 p1 = tri.Position;
        Vector2 p2 = new Vector2(tri.Position.X - tri.Size / 2, tri.Position.Y + tri.Size);
        Vector2 p3 = new Vector2(tri.Position.X + tri.Size / 2, tri.Position.Y + tri.Size);

        Raylib.DrawTriangle(p1, p2, p3, Color.Black);
        Raylib.DrawTriangle(p1 + new Vector2(0,8), p2 + new Vector2(6,-4), p3 - new Vector2(6,4), Color.Green);
    }

    for (int i = 0; i < EnemyTriangles.Count; i++)
    {
        TriAttacker tri = EnemyTriangles[i];
        TriAttacker Hit = EnemyTriHitbox[i];
        Vector2 p1 = tri.Position;
        Vector2 p2 = new Vector2(tri.Position.X - tri.Size / 2, tri.Position.Y + tri.Size);
        Vector2 p3 = new Vector2(tri.Position.X + tri.Size / 2, tri.Position.Y + tri.Size);

        Raylib.DrawTriangle(p1, p2, p3, Color.Black);
        Raylib.DrawTriangle(p1 + new Vector2(0,8), p2 + new Vector2(6,-4), p3 - new Vector2(6,4), Color.Green);
        Raylib.DrawRectangleRec(Hit.Hitbox, new Color(255,255,255,0));
        Raylib.DrawRectangleLinesEx(Hit.Hitbox, 4, Color.Black);
    }

     for (int i = 0; i < PlrRectangles.Count; i++)
    {
        RectAttacker rect = PlrRectangles[i];
        Raylib.DrawRectangleRec(rect.Rect, Color.Red);
        Raylib.DrawRectangleLinesEx(rect.Rect, 4, Color.Black);
    }

    for (int i = 0; i < EnemyRectangles.Count; i++)
    {
        RectAttacker rect = EnemyRectangles[i];
        Raylib.DrawRectangleRec(rect.Rect, Color.Red);
        Raylib.DrawRectangleLinesEx(rect.Rect, 4, Color.Black);
    }
}

void UpdateMovement() //Method som flyttar anfallarna mot motståndarens bas
{
    for (int i = 0; i < PlrCircles.Count; i++)
    {
        CircAttacker center = PlrCircles[i];
        if(center.Position.X + center.radius < 1500)
        {
            center.Position.X += center.Speed;
        }else
        {
            center.Speed = 0;
        }
    }

    for (int i = 0; i < EnemyCircles.Count; i++)
    {
        CircAttacker center = EnemyCircles[i];
        CircAttacker Hit = EnemyCirHitbox[i];
         if(center.Position.X - center.radius > 0)
        {
            center.Position.X -= center.Speed;
            Hit.Hitbox.X -= center.Speed;
        }else
        {
            center.Speed = 0;
        }
    }

    for (int i = 0; i < PlrTriangles.Count; i++)
    {
        TriAttacker tri = PlrTriangles[i];
        if(tri.Position.X + tri.Size/2 < 1500)
        {
        tri.Position.X += tri.Speed;
        } else
        {
            tri.Speed = 0;
        }
    }

    for (int i = 0; i < EnemyTriangles.Count; i++)
    {
        TriAttacker tri = EnemyTriangles[i];
        TriAttacker Hit = EnemyTriHitbox[i];
         if(tri.Position.X - tri.Size/2> 0)
        {
        tri.Position.X -= tri.Speed;
        Hit.Hitbox.X -= tri.Speed;
        } else
        {
            tri.Speed = 0;
        }
    }

    for (int i = 0; i < PlrRectangles.Count; i++)
    {
        RectAttacker rect = PlrRectangles[i];
        if(rect.Rect.X + rect.Rect.Width < 1500)
        {
        rect.Rect.X += rect.Speed;
        } else
        {
            rect.Speed = 0;
        }

        for(int j = 0; j < EnemyRectangles.Count; j++)
        {
            RectAttacker EnemyRect = EnemyRectangles[j];
            if(Raylib.CheckCollisionRecs(rect.Rect, EnemyRect. Rect))
            {
                rect.Speed = 0;
                EnemyRect.Speed = 0;
            }
        }

        for(int o = 0; o < EnemyCircles.Count; o++)
        {
            CircAttacker EnemyCenter = EnemyCircles[o];
            CircAttacker EnemyCenterHit = EnemyCirHitbox[o];
            if(Raylib.CheckCollisionRecs(rect.Rect, EnemyCenterHit.Hitbox))
            {
                rect.Speed = 0;
                EnemyCenter.Speed = 0;
            }
        }

        for(int t = 0; t < EnemyTriangles.Count; t++)
        {
            TriAttacker EnemyPosition = EnemyTriangles[t];
            TriAttacker EnemyPositionHit = EnemyTriHitbox[t];
            if(Raylib.CheckCollisionRecs(rect.Rect, EnemyPositionHit.Hitbox))
            {
                rect.Speed = 0;
                EnemyPosition.Speed = 0;
            }
        }
    }

    for (int i = 0; i < EnemyRectangles.Count; i++)
    {
        RectAttacker rect = EnemyRectangles[i];
        if(rect.Rect.X> 0)
        {
        rect.Rect.X -= rect.Speed;  
        } else
        {
            rect.Speed = 0;
        }
    }
}

void Fighting()
{}

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
    Fighting();
    Raylib.EndDrawing();
} 