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
            // Ball Ball = new Ball();
            // Paddle Paddle = new Paddle();
            ObjectMovement MovingObjects = new ObjectMovement();
            PlayerLives PlayerLives = new PlayerLives();
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
                Raylib.ClearBackground(Color.WHITE);
                MovingObjects.BallObjectMovement();
                MovingObjects.PaddleMovement();
                GameOver = PlayerLives.PlayerLivesDisplay();
                Raylib.EndDrawing();
                }
                else if (GameOver == true)
                {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                DrawText("You LOST!!!", 400, 450, 20, Color.RED); 
                Raylib.EndDrawing();
                }
            }
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
