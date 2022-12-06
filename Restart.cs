using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class Restart : PlayerLives{

    public Rectangle Button = new Rectangle(480, 710, 145, 60);

    bool btnAction = false;

    public bool playAgain() {
        int x = (int)Button.x + 5;
        int y = (int)Button.y + 10;
        DrawRectangleRec(Button, RED);
         DrawText("play again?", x, y, 24, Color.WHITE);
        
    if (CheckCollisionPointRec(GetMousePosition(), Button))
    {
        if (IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
        {
            return false;
        }    
        
        else {
         return true;
        }
    }
    else {
        return true;
    }
}
}
