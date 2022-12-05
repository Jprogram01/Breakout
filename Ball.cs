using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;




class Ball: MovementDirection
{

Paddle Paddle = new Paddle();

Dictionary<int, Tuple<Vector2, bool, int>> Balls = new Dictionary<int, Tuple<Vector2, bool, int >>();
public Vector2 BallCenter = new Vector2();

public float BallOnPaddleX;
public float BallOnPaddleY;

public Ball()
{
BallOnPaddleX = Paddle.MovingPaddle.x + 60;
BallOnPaddleY = Paddle.MovingPaddle.y - 10;
BallCenter.X = BallOnPaddleX;
BallCenter.Y = BallOnPaddleY;


}
}