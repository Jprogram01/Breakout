using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;



class BlockList
{

Dictionary<int, List<Blocks>> FullBlocks = new Dictionary<int, List<Blocks>>();
// Blocks Block = new Blocks(0, 0, BLACK);
public BlockList()
{
// CreateDictionary();
}

public Dictionary<int, List<Blocks>> CreateDictionary()
{
for (int i = 0; i < 8; i++ )
    {
    FullBlocks.Add(i, CreateList(i));
    }
return FullBlocks;
}
public List<Blocks> CreateList(int CurrentLine)
{
List<Blocks> BlocksList = new List<Blocks>();
for (int i = 0; i < 19; i++ )
    {
    int XChanger = i * 57;
    int XValue = 10 + XChanger;
    int YChanger = CurrentLine * 40;
    int YValue = 100 + YChanger;

    Color COLOR = CurrentLine switch
    {
    0 => PURPLE,
    1 => PURPLE,
    2 => YELLOW,
    3 => YELLOW,
    4 => ORANGE,
    5 => ORANGE,
    6 => WHITE,
    7 => WHITE,
    _ => PURPLE,
    };
    Blocks Block = new Blocks(XValue, YValue, COLOR);
    BlocksList.Add(Block);
    }
return BlocksList;
}

public void DrawBlocks()
{
    for (int i = 0; i < FullBlocks.Count(); i++)
    {
    for (int n = 0; n < FullBlocks[i].Count(); n++)
    {
        Console.WriteLine(FullBlocks[i]);
        // Console.WriteLine(FullBlocks);
        DrawRectangleRec(FullBlocks[i][n].Block, FullBlocks[i][n].Color);
    }
    }
}


}
