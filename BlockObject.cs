using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

class Blocks
{
int XPosition;

int YPosition;

public Color Color;
public Rectangle Block = new Rectangle(0, 0, 50, 20);

public Blocks(int X, int Y, Color ColorForBlock)
{
    
    XPosition = X;
    YPosition = Y;
    Block.x = XPosition;
    Block.y = YPosition;
    Color = ColorForBlock;
}
}