using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class PowerUpBallObject: BallObjectMovement
{
public Vector2 PowerUpBallCenter = new Vector2();

public bool PowerUpGoingUp;

public int PowerUpSideWaysDirection;

public Color COLOR;

public PowerUpBallObject(Vector2 BallCenter, bool Goingup, int SideWaysDirection)
{
PowerUpBallCenter = BallCenter;
PowerUpGoingUp = Goingup;
PowerUpSideWaysDirection = SideWaysDirection;
COLOR = WHITE;
}
}