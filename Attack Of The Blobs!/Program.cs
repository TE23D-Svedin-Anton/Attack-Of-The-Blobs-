    using System;
    using Raylib_cs;
    using Attackers;
    using System.Numerics;

    float SpawnCooldownTime = 2.0f;
    float PlrLastTimeSpawned = 0.0f;
    float EnemyLastTimeSpawned = 0.0f;
    float CircAttackCooldownTime = 2.0f;
    float TriAttackCooldownTime = 2.0f;
    float RectAttackCooldownTime = 2.0f;
    float PlrCircLastTimeAttacked = 0.0f;
    float PlrTriLastTimeAttacked = 0.0f;
    float PlrRectLastTimeAttacked = 0.0f;
    float EnemyCircLastTimeAttacked = 0.0f;
    float EnemyTriLastTimeAttacked = 0.0f;
    float EnemyRectLastTimeAttacked = 0.0f;


    List<TriAttacker> PlrTriangles =[];
    List<TriAttacker> EnemyTriangles =[];
    List<CircAttacker> PlrCircles =[];
    List<CircAttacker> EnemyCircles = [];
    List<RectAttacker> PlrRectangles = [];
    List<RectAttacker> EnemyRectangles = [];

    void SpawnButton() //Skapar en anfallare beroende på vilken knapp som trycks
    {
        int PlrSpawnX = 200;
        int EnemySpawnX = 1300;
        int SpawnY = 760;

        if(Raylib.IsKeyPressed(KeyboardKey.Two) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= SpawnCooldownTime))
        {
            PlrTriangles.Add(new TriAttacker () {Hitbox = new Rectangle(PlrSpawnX - 200, SpawnY - 40,400,80) });//Skapar en ny Triangel i PlrTriangles listan
            PlrLastTimeSpawned = (float)Raylib.GetTime();   
        }

        if(Raylib.IsKeyPressed(KeyboardKey.Nine) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= SpawnCooldownTime))
        {
            EnemyTriangles.Add(new TriAttacker () {Hitbox = new Rectangle(EnemySpawnX - 200, SpawnY - 40,400,80) });//Skapar en ny Triangel i EnemyTriangles listan
            EnemyLastTimeSpawned = (float)Raylib.GetTime();   
        }
        
        if(Raylib.IsKeyPressed(KeyboardKey.One) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= SpawnCooldownTime))
        {
            PlrCircles.Add(new CircAttacker () {Hitbox = new Rectangle(PlrSpawnX - 40, SpawnY - 40,80,80)}); //Skapar en ny Cirkel i PlrCircles listan
            PlrLastTimeSpawned = (float)Raylib.GetTime();   
        }

        if(Raylib.IsKeyPressed(KeyboardKey.Eight) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= SpawnCooldownTime))
        {
            EnemyCircles.Add(new CircAttacker () {Hitbox = new Rectangle(EnemySpawnX - 40, SpawnY - 40,80,80) }); //Skapar en ny Cirkel i EnemyCircles listan
            EnemyLastTimeSpawned = (float)Raylib.GetTime();   
        }

        if(Raylib.IsKeyPressed(KeyboardKey.Three) && ((float)Raylib.GetTime() - PlrLastTimeSpawned >= SpawnCooldownTime))
        {
            PlrRectangles.Add(new RectAttacker() {Rect = new Rectangle(PlrSpawnX - 40, SpawnY - 40, 80, 80)}); //Skapar en ny Rektangel i PlrRectangles listan
            PlrLastTimeSpawned = (float)Raylib.GetTime();   
        }

        if(Raylib.IsKeyPressed(KeyboardKey.Zero) && ((float)Raylib.GetTime() - EnemyLastTimeSpawned >= SpawnCooldownTime))
        {
            EnemyRectangles.Add(new RectAttacker() {Rect = new Rectangle(EnemySpawnX - 40, SpawnY - 40, 80, 80)} ); //Skapar en ny Rektangel i EnemyRectangles listan
            EnemyLastTimeSpawned = (float)Raylib.GetTime();   
        }
    }

    void Draw() //Ritar alla spelarens och motståndarens anfallare som har skapats
    {
        for (int C = 0; C < PlrRectangles.Count; C++)
        {
            RectAttacker rect = PlrRectangles[C];
            Raylib.DrawRectangleRec(rect.Rect, Color.Red);
            Raylib.DrawRectangleLinesEx(rect.Rect, 4, Color.Black);
        }

        for (int c = 0; c < EnemyRectangles.Count; c++)
        {
            RectAttacker rect = EnemyRectangles[c];
            Raylib.DrawRectangleRec(rect.Rect, Color.Red);
            Raylib.DrawRectangleLinesEx(rect.Rect, 4, Color.Black);
        }

        for (int B = 0; B < PlrCircles.Count; B++)
        {
            CircAttacker PlrCirc = PlrCircles[B];
            PlrCirc.HpText = $"{PlrCirc.Hp}";
            Raylib.DrawCircleV(new Vector2(PlrCirc.Hitbox.X + 40, PlrCirc.Hitbox.Y + 40), PlrCirc.radius, Color.Black);
            Raylib.DrawCircleV(new Vector2(PlrCirc.Hitbox.X + 40, PlrCirc.Hitbox.Y + 40), PlrCirc.radius - 4, Color.Blue);
            Raylib.DrawTextEx(Raylib.GetFontDefault(),PlrCirc.HpText, new Vector2(PlrCirc.Hitbox.X + 30, PlrCirc.Hitbox.Y - 25), 20, 2,Color.White);

        }

        for (int b = 0; b < EnemyCircles.Count; b++)
        {
            CircAttacker EnemyCirc = EnemyCircles[b];
            EnemyCirc.HpText = $"{EnemyCirc.Hp}";
            Raylib.DrawCircleV(new Vector2(EnemyCirc.Hitbox.X + 40, EnemyCirc.Hitbox.Y + 40), EnemyCirc.radius, Color.Black);
            Raylib.DrawCircleV(new Vector2(EnemyCirc.Hitbox.X + 40, EnemyCirc.Hitbox.Y + 40), EnemyCirc.radius - 4, Color.Blue);
            Raylib.DrawTextEx(Raylib.GetFontDefault(),EnemyCirc.HpText, new Vector2(EnemyCirc.Hitbox.X + 30, EnemyCirc.Hitbox.Y - 25), 20, 2,Color.White);
        }

        for (int A = 0; A < PlrTriangles.Count; A++)
        {
            TriAttacker PlrTri = PlrTriangles[A];
            Vector2 p1 = new Vector2(PlrTri.Hitbox.X + 200, PlrTri.Hitbox.Y);
            Vector2 p2 = new Vector2(PlrTri.Hitbox.X + 160, PlrTri.Hitbox.Y + PlrTri.Size);
            Vector2 p3 = new Vector2(PlrTri.Hitbox.X + 240, PlrTri.Hitbox.Y + PlrTri.Size);
            Rectangle PlrShootingHitBox = new Rectangle(PlrTri.Hitbox.X, PlrTri.Hitbox.Y,400,80);
            Rectangle PlayerHitBox = new Rectangle(PlrTri.PlayerHitbox.X - 40, PlrTri.Hitbox.Y,400,80);

            Raylib.DrawTriangle(p1, p2, p3, Color.Black);
            Raylib.DrawTriangle(p1 + new Vector2(0,8), p2 + new Vector2(6,-4), p3 - new Vector2(6,4), Color.Green);
            Raylib.DrawRectangleRec(PlrShootingHitBox, new Color(255, 255, 255, 0));
            Raylib.DrawRectangleLinesEx(PlrShootingHitBox, 4, Color.Black);

        }

        for (int a = 0; a < EnemyTriangles.Count; a++)
        {
            TriAttacker EnemyTri = EnemyTriangles[a];
            Vector2 p1 = new Vector2(EnemyTri.Hitbox.X + 200, EnemyTri.Hitbox.Y);
            Vector2 p2 = new Vector2(EnemyTri.Hitbox.X + 160, EnemyTri.Hitbox.Y + EnemyTri.Size);
            Vector2 p3 = new Vector2(EnemyTri.Hitbox.X + 240, EnemyTri.Hitbox.Y + EnemyTri.Size);
            Rectangle EnemyShootingHitBox = new Rectangle(EnemyTri.Hitbox.X, EnemyTri.Hitbox.Y,400,80);

            Raylib.DrawTriangle(p1, p2, p3, Color.Black);
            Raylib.DrawTriangle(p1 + new Vector2(0,8), p2 + new Vector2(6,-4), p3 - new Vector2(6,4), Color.Green);
            Raylib.DrawRectangleRec(EnemyShootingHitBox, new Color(255, 255, 255, 0));
            Raylib.DrawRectangleLinesEx(EnemyShootingHitBox, 4, Color.Black);
        }

    }

    void UpdateMovementAndFighting() //Method som flyttar anfallarna mot motståndarens bas
    {
        for (int A = 0; A < PlrTriangles.Count; A++)
        {
            TriAttacker PlrTri = PlrTriangles[A];
            Rectangle PlayerHitBox = new Rectangle(PlrTri.PlayerHitbox.X - 40, PlrTri.Hitbox.Y,400,80);
            if (PlrTri.Hp <= 0)
            {
                PlrTriangles.RemoveAt(A);
                A--;
                }

            if(PlrTri.Hitbox.X + 400 <= 1500)
            {
            PlrTri.Hitbox.X += PlrTri.Speed;
            } else
            {
                PlrTri.Speed = 0;
            }

            for(int a = 0; a < EnemyTriangles.Count; a++)
            {
                TriAttacker EnemyTri = EnemyTriangles[a];
                if(Raylib.CheckCollisionRecs(PlayerHitBox, EnemyTri.Hitbox))
                {
                    PlrTri.Speed = 0;
                    if(Raylib.GetTime() - EnemyTriLastTimeAttacked >= TriAttackCooldownTime)
                    {
                    PlrTri.Hp -= 30;
                    EnemyTriLastTimeAttacked = (float)Raylib.GetTime(); 
                    }
                }
            }

            for(int b = 0; b < EnemyCircles.Count; b++)
            {
                CircAttacker EnemyCirc = EnemyCircles[b];
                if(Raylib.CheckCollisionRecs(PlrTri.Hitbox, EnemyCirc.Hitbox))
                {
                    PlrTri.Speed = 0;
                }
            }

            for(int c = 0; c < EnemyRectangles.Count; c++)
            {
                RectAttacker EnemyRect = EnemyRectangles[c];
                if(Raylib.CheckCollisionRecs(PlrTri.Hitbox, EnemyRect.Rect))
                {
                    PlrTri.Speed = 0;
                }
            }
        }

        for (int a = 0; a < EnemyTriangles.Count; a++)
        {
            TriAttacker EnemyTri = EnemyTriangles[a];
            if (EnemyTri.Hp <= 0)
            {
                EnemyTriangles.RemoveAt(a);
                a--;
                }
            if(EnemyTri.Hitbox.X >= 0)
            {
            EnemyTri.Speed = 1;
            EnemyTri.Hitbox.X -= EnemyTri.Speed;
            } 
            else
            {
                EnemyTri.Speed = 0;
            }

            for(int A = 0; A < PlrTriangles.Count; A++)
            {
                TriAttacker PlrTri = PlrTriangles[A];
                if(Raylib.CheckCollisionRecs(EnemyTri.Hitbox, PlrTri.Hitbox))
                {
                    EnemyTri.Speed = 0;
                    if(Raylib.GetTime() - PlrTriLastTimeAttacked >= TriAttackCooldownTime)
                    {
                    EnemyTri.Hp -= 30;
                    PlrTriLastTimeAttacked = (float)Raylib.GetTime(); 
                    }
                }
                else
                {
                    EnemyTri.Speed = 1;
                }
            }

            for(int B = 0; B < PlrCircles.Count; B++)
            {
                CircAttacker PlrCirc = PlrCircles[B];
                if(Raylib.CheckCollisionRecs(EnemyTri.Hitbox, PlrCirc.Hitbox))
                {
                    EnemyTri.Speed = 0;
                }
            }

            for(int C = 0; C < PlrRectangles.Count; C++)
            {
                RectAttacker PlrRect = PlrRectangles[C];
                if(Raylib.CheckCollisionRecs(EnemyTri.Hitbox, PlrRect.Rect))
                {
                    EnemyTri.Speed = 0;
                }
            }
        }

        for (int B = 0; B < PlrCircles.Count; B++)
        {
            CircAttacker PlrCirc = PlrCircles[B];
            if (PlrCirc.Hp <= 0)
        {
        PlrCircles.RemoveAt(B);
        B--;
        }
        else if(PlrCirc.Hp > 0 && PlrCirc.Hitbox.X + PlrCirc.radius*2 <= 1500)
        {
            PlrCirc.Hitbox.X += PlrCirc.Speed;
            }
            else
            {
                PlrCirc.Speed = 0;
            }

            for(int a = 0; a < EnemyTriangles.Count; a++)
            {
                TriAttacker EnemyTri = EnemyTriangles[a];
                if(Raylib.CheckCollisionRecs(PlrCirc.Hitbox, EnemyTri.Hitbox))
                {
                    PlrCirc.Speed = 0;
                }
            }

            for(int b = 0; b < EnemyCircles.Count; b++)
            {
                CircAttacker EnemyCirc = EnemyCircles[b];
                if(Raylib.CheckCollisionRecs(PlrCirc.Hitbox, EnemyCirc.Hitbox))
                {
                    PlrCirc.Speed = 0;
                }
            }

            for(int c = 0; c < EnemyRectangles.Count; c++)
            {
                RectAttacker EnemyRect = EnemyRectangles[c];
                if(Raylib.CheckCollisionRecs(PlrCirc.Hitbox, EnemyRect.Rect))
                {
                    PlrCirc.Speed = 0;
                }
            }            
        }

        for (int b = 0; b < EnemyCircles.Count; b++)
        {
            CircAttacker EnemyCirc = EnemyCircles[b];
            if (EnemyCirc.Hp <= 0)
        {
        EnemyCircles.RemoveAt(b);
        b--;
        }
        else if(EnemyCirc.Hp > 0 && EnemyCirc.Hitbox.X - EnemyCirc.radius*2 >= 0)
        {
            EnemyCirc.Hitbox.X -= EnemyCirc.Speed;
            }
            else
            {
                EnemyCirc.Speed = 0;
            }

            for(int A = 0; A < PlrTriangles.Count; A++)
            {
                TriAttacker PlrTri = PlrTriangles[A];
                if(Raylib.CheckCollisionRecs(EnemyCirc.Hitbox, PlrTri.Hitbox))
                {
                    EnemyCirc.Speed = 0;
                }
            }

            for(int B = 0; B < PlrCircles.Count; B++)
            {
                CircAttacker PlrCirc = PlrCircles[B];
                if(Raylib.CheckCollisionRecs(EnemyCirc.Hitbox, PlrCirc.Hitbox))
                {
                    EnemyCirc.Speed = 0;
                }
            }

            for(int C = 0; C < PlrRectangles.Count; C++)
            {
                RectAttacker PlrRect = PlrRectangles[C];
                if(Raylib.CheckCollisionRecs(EnemyCirc.Hitbox, PlrRect.Rect))
                {
                    EnemyCirc.Speed = 0;
                }
            }            
        }

        for (int C = 0; C < PlrRectangles.Count; C++)
        {
            RectAttacker PlrRect = PlrRectangles[C];
            if (PlrRect.Hp <= 0)
        {
        PlrRectangles.RemoveAt(C);
        C--;
        }
        else if(PlrRect.Hp > 0 && PlrRect.Rect.X + PlrRect.Rect.Width <= 1500)
        {
            PlrRect.Rect.X += PlrRect.Speed;
            }
            else
            {
                PlrRect.Speed = 0;
            }

            for(int a = 0; a < EnemyTriangles.Count; a++)
            {
                TriAttacker EnemyTri = EnemyTriangles[a];
                if(Raylib.CheckCollisionRecs(PlrRect.Rect, EnemyTri.Hitbox))
                {
                    PlrRect.Speed = 0;
                }
            }

            for(int b = 0; b < EnemyCircles.Count; b++)
            {
                CircAttacker EnemyCirc = EnemyCircles[b];
                if(Raylib.CheckCollisionRecs(PlrRect.Rect, EnemyCirc.Hitbox))
                {
                    PlrRect.Speed = 0;
                }
            }

            for(int c = 0; c < EnemyRectangles.Count; c++)
            {
                RectAttacker EnemyRect = EnemyRectangles[c];
                if(Raylib.CheckCollisionRecs(PlrRect.Rect, EnemyRect.Rect))
                {
                    PlrRect.Speed = 0;
                }
            }            
        }

        for (int c = 0; c < EnemyRectangles.Count; c++)
        {
            RectAttacker EnemyRect = EnemyRectangles[c];
            if (EnemyRect.Hp <= 0)
        {
        EnemyRectangles.RemoveAt(c);
        c--;
        }
        else if(EnemyRect.Hp > 0 && EnemyRect.Rect.X + EnemyRect.Rect.Width > 0)
        {
            EnemyRect.Rect.X -= EnemyRect.Speed;
            }
            else
            {
                EnemyRect.Speed = 0;    
            }

            for(int A = 0; A < PlrTriangles.Count; A++)
            {
                TriAttacker PlrTri = PlrTriangles[A];
                if(Raylib.CheckCollisionRecs(EnemyRect.Rect, PlrTri.Hitbox))
                {
                    EnemyRect.Speed = 0;
                }
            }

            for(int B = 0; B < PlrCircles.Count; B++)
            {
                CircAttacker PlrCirc = PlrCircles[B];
                if(Raylib.CheckCollisionRecs(EnemyRect.Rect, PlrCirc.Hitbox))
                {
                    EnemyRect.Speed = 0;
                }
            }

            for(int C = 0; C < PlrRectangles.Count; C++)
            {
                RectAttacker PlrRect = PlrRectangles[C];
                if(Raylib.CheckCollisionRecs(EnemyRect.Rect, PlrRect.Rect))
                {
                    EnemyRect.Speed = 0;
                }
            }            
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
        UpdateMovementAndFighting();
        Raylib.EndDrawing();
    } 