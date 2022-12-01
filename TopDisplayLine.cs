using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class TopDisplay
{

PlayerLives PlayerLives = new PlayerLives();

public void DisplayAll(int Lives, int Score)
{
    DisplayTopLine();
    DisplayText();
    DisplayScore(Score);
    DisplayLives(Lives);
}



private void DisplayTopLine()
{
    DrawRectangle(0, 0, 1500, 50, Color.YELLOW);
}

private void DisplayText()
{
    DrawText("LIVES:", 50, 10, 40, Color.RED);
    DrawText("Score:", 800, 10, 40, Color.RED);
}

private void DisplayScore(int Score)
{
    string StringScore = Score.ToString();
    DrawText(StringScore, 950, 10, 40, Color.RED);
}


private void DisplayLives(int Lives)
{
for (int i = 0; i < Lives; i++ )
{

    var BallPositionChanger = i * 40;
    var XPosition = 210;
    var YPosition = 30;
    Vector2 LivesBallCenter;
    LivesBallCenter.X = XPosition + BallPositionChanger;
    LivesBallCenter.Y = YPosition;

    DrawCircleV(LivesBallCenter, 15, Color.BLACK);
}
}





}
