using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class RedPowerUpBallList: BallObjectMovement
{
public List<PowerUpBallObject> BallsList = new List<PowerUpBallObject>();


public void AddBallsToList(PowerUpBallObject Ball)
{
BallsList.Add(Ball);
}

public void DisplayBalls()
{
    bool InitialGoingUp = true;
    int InitialSideWaysDirection = 0;
    bool InputGoingUp = true;
    int InputSideWaysDirection = 0;

    for(int i = 0; i < BallsList.Count; i++)
    {
    if(i == 0)
    {
        InitialGoingUp = BallsList[i].PowerUpGoingUp;
        InitialSideWaysDirection = BallsList[i].PowerUpSideWaysDirection;
        InputGoingUp = BallsList[i].PowerUpGoingUp;
        InputSideWaysDirection = BallsList[i].PowerUpSideWaysDirection;
    }
    else if(i ==1)
    {
        if(InitialGoingUp == true);
        {
            InputGoingUp = false;
        }
        if(InitialGoingUp == false);
        {
            InputGoingUp = true;
        }
        InputSideWaysDirection = InitialSideWaysDirection;
    }
    else if (i == 2)
    {
        InputGoingUp = InitialGoingUp;
        if(InitialSideWaysDirection == 1 || InitialSideWaysDirection == 0)
        {
        InputSideWaysDirection = 2;
        }
        else
        {
        InputSideWaysDirection = 1;
        }

    }
    else
    {
        if(InitialSideWaysDirection == 1 || InitialSideWaysDirection == 0)
        {
        InputSideWaysDirection = 2;
        }
        else
        {
        InputSideWaysDirection = 1;
        }
        if(InitialGoingUp == true);
        {
            InputGoingUp = false;
        }
        if(InitialGoingUp == false);
        {
            InputGoingUp = true;
        }

    }
    BallsList[i].PowerUpSideWaysDirection = InputSideWaysDirection;
    BallsList[i].PowerUpGoingUp = InputGoingUp;
    }

}

}