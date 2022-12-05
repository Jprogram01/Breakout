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
    public bool BallPaddleCollision(Vector2 FirstObject, Rectangle SecondObject, int RADIUS)
    {
    
    if (CheckCollisionCircleRec(FirstObject, RADIUS, SecondObject))
    {
        CollisionBool = true;
       
    }
    else
    {
        CollisionBool = false;
    }
    return CollisionBool;
    }
    public bool BallBlockCollision(Vector2 Ball, Rectangle Block, int RADIUS)
    {
    bool Collision = false;
    if (CheckCollisionCircleRec(Ball, RADIUS, Block))
    {
    Collision = true;
    }
    return Collision;
    }
}

