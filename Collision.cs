using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class Collision: MovementDirection
{
    Ball Ball = new Ball();
    Paddle Paddle = new Paddle();

    BlockList BlockList = new BlockList();
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
    public bool BallBlockCollision(Vector2 Ball, Rectangle Block)
    {
    bool Collision = false;
    if (CheckCollisionCircleRec(Ball, 10, Block))
    {
    Collision = true;
    }
    return Collision;
    }
}

