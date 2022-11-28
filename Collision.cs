using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class Collision: Velocity
{
    Ball Ball = new Ball();
    Paddle Paddle = new Paddle();


    public bool BallPaddleCollision(Vector2 FirstObject, Rectangle SecondObject)
    {
    var CollisionBool = false;
    if (CheckCollisionCircleRec(FirstObject, 10, SecondObject))
    {
        CollisionBool = true;
       
    }
    return CollisionBool;
    }
}

