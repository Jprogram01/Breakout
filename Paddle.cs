using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;



// Sets up the paddle object, and also moves it around.
class Paddle: MovementDirection
{

public Rectangle MovingPaddle = new Rectangle(-0, 0, 120, 15);


public Paddle()
{
MovingPaddle.x = 490;
MovingPaddle.y = 870;
}

public void PaddleObject()
    {
    DirectionChanger();
    }
public void MoveUpDown()
{
    
}
public void DirectionChanger()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && MovingPaddle.x <= 970) {
        MovingPaddle.x = (MovingPaddle.x + PaddleSpeed);
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)&& MovingPaddle.x >= 10) {
        MovingPaddle.x =(MovingPaddle.x - PaddleSpeed);
    }
    DrawRectangleRec(MovingPaddle, Color.RED);
}








}