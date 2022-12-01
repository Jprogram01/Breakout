using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;




class Ball: Velocity
{

Paddle Paddle = new Paddle();

Dictionary<int, Tuple<Vector2, bool, int>> Balls = new Dictionary<int, Tuple<Vector2, bool, int >>();
public Vector2 BallCenter = new Vector2();

public float BallOnPaddleX;
public float BallOnPaddleY;
public bool Launch;

public Ball()
{
BallOnPaddleX = Paddle.MovingPaddle.x + 60;
BallOnPaddleY = Paddle.MovingPaddle.y - 10;
BallCenter.X = BallOnPaddleX;
BallCenter.Y = BallOnPaddleY;

YSpeed = 12;
XSpeed = 10;
SideWaysDirection = 0;
Launch = false;
}

public void AddFirstBall()
{
    
Tuple<Vector2, bool, int> IndividualBall = new Tuple<Vector2, bool, int>(BallCenter, GoingUp, SideWaysDirection);


    Balls.Add(0,IndividualBall);
}
public void AddedGeneratedBallToList(bool BallGenerated, Vector2 CurrentBall)
{
    if(BallGenerated)
    {
        int NumberOfBalls = Balls.Count; 
        Vector2 Ball = new Vector2();
        Ball.X = CurrentBall.X; 
        Ball.Y = CurrentBall.Y;
        Tuple<Vector2, bool, int> BallWithVariables = new Tuple<Vector2, bool, int>(BallCenter, GoingUp, SideWaysDirection);
        Balls.Add(NumberOfBalls, BallWithVariables);
    }

}











}