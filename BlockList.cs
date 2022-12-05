using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;



class BlockList
{


Dictionary<int, List<Blocks>> FullBlocks = new Dictionary<int, List<Blocks>>();
Random rdn = new Random();

public Dictionary<int, List<Blocks>> CreateFullCubeDictionary()
{
for (int i = 0; i < 8; i++ )
    {
    FullBlocks.Add(i, CreateFirstList(i));
    // FullBlocks = PowerUpGenerators(FullBlocks);
    }
return FullBlocks;
}

public Dictionary<int, List<Blocks>> CreateBorderDictionary()
{
for (int i = 0; i < 8; i++ )
    {
    FullBlocks.Add(i, CreateFirstList(i));
    // FullBlocks = PowerUpGenerators(FullBlocks);
    FullBlocks = BorderShape(i, FullBlocks);
    }
return FullBlocks;
}

public Dictionary<int, List<Blocks>> BorderShape(int Line,  Dictionary<int, List<Blocks>> List)
{
for (int i = 0; i < List[Line].Count; i++ )
            {
            int CurrentIteration = i;
            bool Skip = CurrentIteration switch
                {
                10=>true,
                0=>true,
                18=>true,
                8=>true,
                _=>false,
                };
            if (Skip == true)
                {
                Color COLOR = GRAY;
                List[Line][i].Color = COLOR;
               
                }
            if (i == 9)
                {
                List[Line][i].Block.x = 2000;   
                }
            }
return List;
}


public Dictionary<int, List<Blocks>> CreateSmileyDictionary()
{
for (int i = 0; i < 8; i++ )
    {
    FullBlocks.Add(i, CreateFirstList(i));
    // FullBlocks = PowerUpGenerators(FullBlocks);
    FullBlocks = SmileyFaceShape(i, FullBlocks);
    }

return FullBlocks;
}
public Dictionary<int, List<Blocks>> SmileyFaceShape(int Line,  Dictionary<int, List<Blocks>> List)
{
if (Line == 0 || Line ==1)
    {   
        for (int i = 0; i < List[Line].Count; i++ )
            {
            int CurrentIteration = i;

            bool Skip = CurrentIteration switch
                {
                2=>true,
                3=>true,
                15=>true,
                16=>true,
                _=>false,
                };
            if (Skip == false)
                {
                
                List[Line][i].Block.x = 2000;
               
                }
            }
    }
if (Line == 2 || Line ==3)
    {
        for (int i = 0; i < List[Line].Count(); i++ )
        {
            bool Skip = i switch
                {
                8=>true,
                9=>true,
                10=>true,
                _=>false,
                };

        if (Skip == false)
            {
             List[Line][i].Block.x = 2000;   
            }
        }   
    }
if (Line == 4 | Line ==5)
    {
    for (int i = 0; i < List[Line].Count(); i++ )
        {
        bool Skip = i switch
            {
            1=>true,
            2=>true,
            16=>true,
            17=>true,
            _=>false,
            };
        if (Skip == false)
            {
             List[Line][i].Block.x = 2000;
            }
        }   
    }
    if (Line == 6 | Line ==7)
    {
        for (int i = 0; i < List[Line].Count(); i++ )
        {
            bool Remove = i switch
            {
            0=>true,
            1=>true,
            2=>true,
            16=>true,
            17=>true,
            18=>true,
            _=>false,
            };
        if (Remove == true)
            {
            List[Line][i].Block.x = 2000;
            }
        }   
    }
return List;
}
public List<Blocks> CreateFirstList(int CurrentLine)
{
List<Blocks> BlocksList = new List<Blocks>();
for (int i = 0; i < 19; i++ )
    {
    int XChanger = i * 58;
    int XValue = 5 + XChanger;
    int YChanger = CurrentLine * 25;
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
        DrawRectangleRec(FullBlocks[i][n].Block, FullBlocks[i][n].Color);
    }
    }
}

public Dictionary<int, List<Blocks>> PowerUpGenerators(Dictionary<int, List<Blocks>> FullBlocks)
{
int i = 0;
int i2 = 0;
while (i != 2)
{
int Random1 = rdn.Next(0,7);
int Random2 = rdn.Next(0,19);
    if(FullBlocks[Random1][Random2].Block.x != 2000 && FullBlocks[Random1][Random2].Color.Equals(GRAY) == false && FullBlocks[Random1][Random2].Color.Equals(SKYBLUE) == false && FullBlocks[Random1][Random2].Color.Equals(RED) == false)
    {
    FullBlocks[Random1][Random2].Color = SKYBLUE;
    i += 1;
    }
}
while (i2 != 2)
{
int Random1 = rdn.Next(0,7);
int Random2 = rdn.Next(0,19);

if(FullBlocks[Random1][Random2].Block.x != 2000 && FullBlocks[Random1][Random2].Color.Equals(GRAY) == false && FullBlocks[Random1][Random2].Color.Equals(SKYBLUE) == false && FullBlocks[Random1][Random2].Color.Equals(RED) == false)
    {
    FullBlocks[Random1][Random2].Color = RED;
    i2 += 1;
    }
}
return FullBlocks;
}


}
