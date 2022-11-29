// using Raylib_cs;
// using System.Numerics;
// using static Raylib_cs.Raylib;
// using static Raylib_cs.Color;
// using static Raylib_cs.PixelFormat;


// class BallList
// {
// Ball FirstBall = new Ball();

// Dictionary<int, Tuple<Vector2, bool, int>> Balls = new Dictionary<int, Tuple<Vector2, bool, int >>();


// Tuple<Vector2, bool, int> IndividualBall = new Tuple<Vector2, bool, int>(BallCenter, GoingUp, SideWaysDirection);

// public void AddFirstBall()
// {
//     FirstBall.IndividualBall = (BallCenter, GoingUp, SideWaysDirection)
//     Balls.Add(BallCenter);
// }
// public void AddedGeneratedBallToList(bool BallGenerated, Vector2 CurrentBall)
// {
//     if(BallGenerated)
//     {
//         Vector2 Ball = new Vector2();
//         Ball.X = CurrentBall.X; 
//         Ball.Y = CurrentBall.Y;
//         Balls.Add(Ball);
//     }

// }
// }