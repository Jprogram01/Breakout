using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class ObjectMovement: Velocity
{
    Ball Ball = new Ball();
    Paddle Paddle = new Paddle();

    Collision Collision = new Collision();

    float OldX;

public ObjectMovement()
{
    OldX = Paddle.MovingPaddle.x;
}
public void PaddleMovement()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && Paddle.MovingPaddle.x <= 970) {
        Paddle.MovingPaddle.x = (Paddle.MovingPaddle.x + Paddle.PaddleSpeed);
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)&& Paddle.MovingPaddle.x >= 10) {
        Paddle.MovingPaddle.x = (Paddle.MovingPaddle.x - Paddle.PaddleSpeed);
    }
    DrawRectangleRec(Paddle.MovingPaddle, Color.RED);
}
    public void BallObjectMovement()
{
    
    if (Ball.Launch == false)
    {
    bool Launched = Launcher();
    
    if (Launched == true)
    {
        GoingUp = true;
    }

    }
    else if (Ball.Launch == true)
    {
    BallFlying();
    }
}


    public void BallFlying()
    {
    var YDirection = DirectionChangerY();
    var XDirection = DirectionChangerX();
    MovingBall(YDirection, XDirection);
    DrawCircleV(Ball.BallCenter, 10, BLACK);
    
    }

    public bool BallPaddleCollision()
    {
    if (Collision.BallPaddleCollision(Ball.BallCenter, Paddle.MovingPaddle))
    {
        GoingUp = true;
    }

    return GoingUp;
    }
    public int PaddleDirectionChecker()
    {
        int direction = 0;
        if (OldX < Paddle.MovingPaddle.x)
        {
            direction = 1;
        }
        else if (OldX > Paddle.MovingPaddle.x)
        {
            direction = 2;
        }
        OldX = Paddle.MovingPaddle.x;
        return direction;

    }
    public void MovingBall(bool GoingUp, int SideWaysDirection)
    {
        if(GoingUp == true)
        { 
        Ball.BallCenter.Y = (Ball.BallCenter.Y - Ball.YSpeed);
        }
        else
        {
        Ball.BallCenter.Y = (Ball.BallCenter.Y + Ball.YSpeed);
        }
        if(SideWaysDirection == 1)
        { 
        Ball.BallCenter.X = (Ball.BallCenter.X + Ball.XSpeed);
        }
        else if (SideWaysDirection == 2)
        {
        Ball.BallCenter.X = (Ball.BallCenter.X - Ball.XSpeed);
        }
    }
public bool DirectionChangerY()
{
    GoingUp = BallPaddleCollision();
    if (Ball.BallCenter.Y < 0)
    {
        GoingUp = false;
    }
    return GoingUp;
}   
    
public int DirectionChangerX()
{   
    if (Ball.BallCenter.X >= 1100 && SideWaysDirection == 1)
    {
        SideWaysDirection = 2;
    }
    else if (Ball.BallCenter.X < 0 && SideWaysDirection == 2 )
    {
        SideWaysDirection = 1;
    }
    if (Collision.BallPaddleCollision(Ball.BallCenter, Paddle.MovingPaddle))
    {
        var SideWaysChecker = PaddleDirectionChecker();
        if (SideWaysChecker == 1)
        {
            SideWaysDirection = 1;
        }
        else if (SideWaysChecker ==2)
        {
            SideWaysDirection = 2;
        }
    }
    else
    {
        PaddleDirectionChecker();
    }


    return SideWaysDirection;
}
public bool Launcher()
{
    Ball.Launch = false;
    SideWaysDirection = 0;
    if (IsKeyDown(KeyboardKey.KEY_RIGHT) && Paddle.MovingPaddle.x <= 970) {
        Ball.BallCenter.X = (Ball.BallCenter.X + Paddle.PaddleSpeed);
        SideWaysDirection = 1;
    }


    if (IsKeyDown(KeyboardKey.KEY_LEFT)&& Paddle.MovingPaddle.x >= 10) {
        Ball.BallCenter.X = (Ball.BallCenter.X - Paddle.PaddleSpeed);

        SideWaysDirection = 2;
    }
    
    
    if (IsKeyDown(KeyboardKey.KEY_SPACE))
    {
        GoingUp = true;
        Ball.Launch = true;
    }
    DrawCircleV(Ball.BallCenter, 10, BLACK);
    return Ball.Launch;
}
}






















