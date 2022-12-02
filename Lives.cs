using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class PlayerLives
{

BallObjectMovement Ball = new BallObjectMovement();
public int Lives;
public bool GameOver;


public PlayerLives()
{   
    Lives = 3;
    GameOver = false;
}

public bool PlayerLivesDisplay(Vector2 BallCenter)
{
    if (GameOver == false)
    {
        UpdateLives(Ball.CheckOutOfBounds(BallCenter));
        GameOver = IsGameOver();
    }
    return GameOver;
    
}

private void UpdateLives(bool result)
{
if (result == true)
{
    Lives = (Lives - 1);
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