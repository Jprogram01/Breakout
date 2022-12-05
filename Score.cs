using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class Score
{
public int ScorePoints;

public Score()
{
    ScorePoints = 0;
}

public int ScoreAdd(int AddType, int ScorePoints)
{   
    int AddPointsAmount = AddType switch
    {
    1=>10,
    2=>20,
    3=>100,
    _=>0,
    };
    return ScorePoints + AddPointsAmount;
}
public int ScoreSubtract(int LoseType, int ScorePoints)
{
    int ReturnScorePoints = 0;
    int SubtractPointsAmount = LoseType switch
    {
    1=>-10,
    2=>-50,
    _=>0,
    };
    ReturnScorePoints = ScorePoints + SubtractPointsAmount;
    ScorePoints = ReturnScorePoints;
    if (ScorePoints <= 0)
        {
        ReturnScorePoints = 0;
        }
    return ReturnScorePoints;
    
}
}