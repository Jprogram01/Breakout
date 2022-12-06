using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class DifferentBalls
{

public Color BallColor;
public Vector2 BallCenter = new Vector2();
public DifferentBalls(float X, float Y, Color COLOR)
{
    BallCenter.X = X;
    BallCenter.Y = Y;
    BallColor = COLOR;
}


public void DrawBall(Vector2 BallCenter, Color COLOR)
{
     DrawCircleV(BallCenter, 10, COLOR);
}
public void NoDetectionBallPowerUp()
{
    
}


}