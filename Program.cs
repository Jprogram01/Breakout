using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;




namespace Peggle
{
class Program
{
           
           public static void Main()
        {
            //sets things up
            ObjectMovement MovingObjects = new ObjectMovement();
            PlayerLives PlayerLives = new PlayerLives();
            TopDisplay TopDisplay = new TopDisplay();
            BlockList BlocksList = new BlockList();
            Score Score = new Score();
            var ScreenHeight = 900;
            var ScreenWidth = 1100;
            bool GameOver = false;
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Peggle");
            Raylib.InitAudioDevice();
            Raylib.SetTargetFPS(60);
           

        

           


            while (!Raylib.WindowShouldClose())
            {
                if (GameOver == false)
                {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                MovingObjects.ObjectsMoving();
                BlocksList.DrawBlocks();
                TopDisplay.DisplayAll(PlayerLives.Lives, Score.score);
                GameOver = PlayerLives.PlayerLivesDisplay(MovingObjects.Ball.BallCenter);
                Raylib.EndDrawing();
                }
                else if (GameOver == true)
                {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                DrawText("You LOST!!!", 300, 450, 100, Color.RED); 
                Raylib.EndDrawing();
                }
            }
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
