using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class PlayerLives
{
ObjectMovement ObjectMovement = new ObjectMovement();
public int Lives;
public bool GameOver;

public PlayerLives()
{
    Lives = 3;
    GameOver = false;
}

public bool PlayerLivesDisplay()
{
    Console.WriteLine(Lives);
    if (GameOver == false)
    {
        UpdateLives(ObjectMovement.BallOutOfBounds);
        Console.Write(ObjectMovement.BallOutOfBounds);
        DisplayLives();
        GameOver = IsGameOver();
    }
    return GameOver;
    
}

public void UpdateLives(bool result)
{
if (result == true)
{
    Lives -= 1;
}
// if (result == false)
// {
//     Lives += 1;
// }
}
public void DisplayLives()
{
for (int i = 0; i == Lives; i++ )
{
    var BallPositionChanger = i * 10;
    var XPosition = 50;
    var YPosition = 450;
    Vector2 LivesBallCenter;
    LivesBallCenter.X = XPosition + BallPositionChanger;
    LivesBallCenter.Y = YPosition;


    DrawCircleV(LivesBallCenter, 10, BLACK);
}
}




public bool IsGameOver()
{
var IsGameOver = false;
if (Lives == 0)
{
    IsGameOver = true;
}
return IsGameOver;

}


}