using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class BallObjectMovement: Ball




{
 
public bool Launch;
public BallObjectMovement()
{
Launch = false;
}

// Loads in all the different methods and covers ball status, positon, movement
public Vector2 BallMovement(Vector2 BallObject, Rectangle PaddleObject, bool GoingUp, int SideWaysDirection, int RADIUS)
{
    var BallOutOfBounds = false;
    BallOutOfBounds = CheckOutOfBounds(BallObject);
    if (BallOutOfBounds == true)
    {
        Launch = false;
        BallObject.X = PaddleObject.x + 60;
        BallObject.Y = PaddleObject.y - 10;
    }
    if (Launch == false)
    {
        BallObject = Launcher(BallObject, PaddleObject);
        Launch = LaunchCheck(Launch);
    }
    else
    {
        BallObject = BallFlying(BallObject, GoingUp, SideWaysDirection);
    }

    
    
    DrawCircleV(BallObject, RADIUS, WHITE);
    return BallObject;
}


// Handles when the ball is flying
public Vector2 BallFlying(Vector2 BallObject,bool GoingUp, int SideWaysDirection)
{
    BallObject = MovingBall(GoingUp, SideWaysDirection, BallObject);

    return BallObject;
    
}

//Checks whether or not the ball has fallen below the paddle.
public bool CheckOutOfBounds(Vector2 BallObject)
{
        var BallOutOfBounds = false;
        if (BallObject.Y >= 915)
            BallOutOfBounds = true;
            return BallOutOfBounds;
}

//Moves the ball depending on direction its going
    public Vector2 MovingBall(bool GoingUp, int SideWaysDirection, Vector2 BallObject)
    {
        if(GoingUp == true)
        { 
            BallObject.Y = (BallObject.Y - YSpeed);
        }
        else
        {
            BallObject.Y = (BallObject.Y + YSpeed);
        }
        if(SideWaysDirection == 1)
        { 
            BallObject.X = (BallObject.X + XSpeed);
        }
        else if (SideWaysDirection == 2)
        {
            BallObject.X = (BallObject.X - XSpeed);
        }
    return BallObject;
    }


//Handles the ball in it's prelaunched state. When it's on the paddle.
public bool LaunchCheck(bool Launch)
{
    
    if (IsKeyDown(KeyboardKey.KEY_SPACE) && Launch == false)
    {
        Launch = true;
    }
    
    return Launch;
}
public Vector2 LauncherBallMovement(Vector2 BallObject, Rectangle PaddleObject)
{
        if (IsKeyDown(KeyboardKey.KEY_RIGHT) && PaddleObject.x <= 970)
        {

            BallObject.X = (BallObject.X + PaddleSpeed);
            SideWaysDirection = 1;
        }


        if (IsKeyDown(KeyboardKey.KEY_LEFT)&& PaddleObject.x >= 10) 
        {
            BallObject.X = (BallObject.X - PaddleSpeed);
            SideWaysDirection = 2;
        }
    // BallObject.X += 1;
    return BallObject;
}
public Vector2 Launcher(Vector2 BallObject, Rectangle PaddleObject)
{
BallObject = LauncherBallMovement(BallObject, PaddleObject);

return BallObject;
}
        















}