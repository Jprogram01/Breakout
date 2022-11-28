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
            var ScreenHeight = 900;
            var ScreenWidth = 1100;
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Peggle");
            Raylib.InitAudioDevice();
            Raylib.SetTargetFPS(60);
           

        

           


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                MovingObjects.BallObjectMovement();
                MovingObjects.PaddleMovement();


                Raylib.EndDrawing();
            }
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
