using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class PaddleObjectMovement: Paddle
{
Collision Collision = new Collision();

public float OldX;
public PaddleObjectMovement()
{
    OldX = MovingPaddle.x;
}

public void PaddleMovement()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && MovingPaddle.x <= 970) {
        MovingPaddle.x = (MovingPaddle.x + PaddleSpeed);
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)&& MovingPaddle.x >= 10) {
        MovingPaddle.x = (MovingPaddle.x - PaddleSpeed);
    }
    DrawRectangleRec(MovingPaddle, Color.RED);
}

public int PaddleDirectionChecker()
    {
        int direction = 0;
        if (OldX < MovingPaddle.x)
        {
            direction = 1;
        }
        else if (OldX > MovingPaddle.x)
        {
            direction = 2;
        }
        OldX = MovingPaddle.x;
        return direction;

    }

}