using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class Collision: Velocity
{
    Ball Ball = new Ball();
    Paddle Paddle = new Paddle();
    public bool CollisionBool;
public Collision()
{
    CollisionBool = false;
}
    public bool BallPaddleCollision(Vector2 FirstObject, Rectangle SecondObject)
    {
    
    if (CheckCollisionCircleRec(FirstObject, 10, SecondObject))
    {
        CollisionBool = true;
       
    }
    else
    {
        CollisionBool = false;
    }
    return CollisionBool;
    }
}

