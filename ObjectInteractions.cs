using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;

//Class for all the objectinteractions in the game
//Handles a lot of the logic
class ObjectInteraction: MovementDirection
{
    //Calls all the classes needed for objects to interact or logic to run
    public BallObjectMovement Ball = new BallObjectMovement();
    public PaddleObjectMovement  Paddle = new PaddleObjectMovement();
    public Collision Collision = new Collision();
    
    public BlockList BlockList = new BlockList();
    public Score Score = new Score();
    public RedPowerUpBallList RedPowerUp = new RedPowerUpBallList();

    public List<DifferentBalls> PowerUpBallList = new List<DifferentBalls>();

    public Dictionary<int, List<Blocks>> BlockDictionary = new Dictionary<int, List<Blocks>>();

    public int Runner = 0;
    public int PowerUpframes = 0;
    public int RedPowerUpframes = 0;

    public bool BlueOn = false;
    public bool PowerUpSKYBLUE = false;

    public bool RedOn = false;
    public bool PowerUpRed = false;

    public int RADIUS = 10;

//Runs all the different for objects to move and interact
public void ObjectsInteracting()
{
    UpdateBallXandYDirection(Ball.BallCenter, Paddle.MovingPaddle);
    Ball.BallCenter = Ball.BallMovement(Ball.BallCenter, Paddle.MovingPaddle, GoingUp, SideWaysDirection, RADIUS);
    Paddle.PaddleMovement();
    BlockFunctions(Ball.BallCenter, Paddle.MovingPaddle);
    PointUpdater(Ball.BallCenter, Paddle.MovingPaddle);
    DevTools();
}

//Runs all the block and powerup functions
public void BlockFunctions(Vector2 Ball, Rectangle Paddle)
{
    RemoveFarBlocks();
    DrawBlocks();
    PowerUpRunner(Ball, Paddle);
}

//Runs the powers up functions
public void PowerUpRunner(Vector2 Ball, Rectangle Paddle)
{
if (BlueOn)
{
    BluePowerUpRunner();
}
if (RedOn)
{
    RedPowerUpRunner();
}
var Remove = false;
var PowerUpBall = CollisionBallBlock(Ball);
float xChecker = PowerUpBall.BallCenter.X;
if (xChecker != 0)
    {
    PowerUpBallList.Add(PowerUpBall);
    }
for(int i = 0; i < PowerUpBallList.Count; i++)
{
    PowerUpBallList[i].BallCenter = UpdateBallPosition(PowerUpBallList[i]);
    PowerUpBallList[i].DrawBall(PowerUpBallList[i].BallCenter, PowerUpBallList[i].BallColor);
    if (Collision.BallPaddleCollision(PowerUpBallList[i].BallCenter, Paddle, RADIUS) && PowerUpBallList[i].BallColor.Equals(SKYBLUE))
        {
            TurnOnBluePowerUp();
            Remove = true;
        }
        
    if (Collision.BallPaddleCollision(PowerUpBallList[i].BallCenter, Paddle, RADIUS) && PowerUpBallList[i].BallColor.Equals(RED))
        {
            TurnOnRedPowerUp();
            Remove = true;
        }

    if (!CheckBallFall(PowerUpBallList[i]))
        {
            Remove = true;
        }

    if (Remove)
        {
            PowerUpBallList.Remove(PowerUpBallList[i]);
        }
    
}
}
//runs the blue power up
public void BluePowerUpRunner()
{
    PowerUpframes += 1;
    if (PowerUpframes != 600)
    {
        PowerUpSKYBLUE = true;
    }
    else if (PowerUpframes == 600)
    {
        PowerUpSKYBLUE = false;
        BlueOn = false;
        PowerUpframes = 0;
    }
}

//Turns on the blue power up
public void TurnOnBluePowerUp()
{
    BlueOn = true;
    PowerUpframes = 0;

}

//runs the red power up
public void RedPowerUpRunner()
{
    RedPowerUpframes += 1;
    if (RedPowerUpframes != 600)
    {
        PowerUpRed = true;
    }
    else if (RedPowerUpframes == 600)
    {
        RedPowerUpframes = 0;
        RADIUS = 10;
        RedOn = false;
        PowerUpRed = false;
    }
    if(PowerUpRed)
    {
        RADIUS = 30;
    }
}
//turns on the red power up
public void TurnOnRedPowerUp()
{
    RedOn = true;
}
//Loads the block dictionary according to which level it is.
public void DictionaryLoader(int Level)
{
    if (Level == 1)
    {
        BlockDictionary = BlockList.CreateSmileyDictionary();
        BlockDictionary = BlockList.PowerUpGenerators(BlockDictionary);
    }
    else if (Level == 2)
    {
        BlockDictionary = BlockList.CreateBorderDictionary();
        BlockDictionary = BlockList.PowerUpGenerators(BlockDictionary);
    }
    else if (Level == 3)
    {
        BlockDictionary = BlockList.CreateFullCubeDictionary();
        BlockDictionary = BlockList.PowerUpGenerators(BlockDictionary);
    }
}
//Dev tool to delete the blocks to progress the levels
public void DevTools()
{
if (IsKeyDown(KeyboardKey.KEY_DELETE))
{
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    BlockDictionary[i].Clear();
    }
}
}
//Checks to see if the blocks are clear to progress to the next level
public bool NextLevelChecker()
{
    int LinesCleared = 0;
    bool Cleared = false;
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
        if(BlockDictionary[i].Count == 0)
        {   
            LinesCleared += 1;
            if (LinesCleared == 8)
            {
            Cleared = true;
            }
        }
    }
    return Cleared;
}
//Draw the blocks for the current level
public void DrawBlocks()
{
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    for (int n = 0; n < BlockDictionary[i].Count(); n++)
    {
        DrawRectangleRec(BlockDictionary[i][n].Block, BlockDictionary[i][n].Color);
    }
    }
}
//For the different formations it just sends the non-needed blocks far away, this function then removes them
public void RemoveFarBlocks()
{
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    for (int n = 0; n < BlockDictionary[i].Count(); n++)
    {
        if (BlockDictionary[i][n].Block.x > 1500)
        {
        BlockDictionary[i].Remove(BlockDictionary[i][n]);
        }
    }
    }
}
//Updates points for each collision
public void PointUpdater(Vector2 BallObject, Rectangle PaddleObject)
{
    if (Collision.BallPaddleCollision(BallObject, PaddleObject, RADIUS) && Ball.Launch == true && GoingUp == false )
    {
        Score.ScorePoints = Score.ScoreSubtract(1, Score.ScorePoints);
    }  
    if (BallObject.Y >910 )
    {
        Score.ScorePoints = Score.ScoreSubtract(2, Score.ScorePoints);
    }
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    for (int n = 0; n < BlockDictionary[i].Count(); n++)
    {
    if (Collision.BallBlockCollision(BallObject, BlockDictionary[i][n].Block, RADIUS))
    {
        if (!BlockDictionary[i][n].Color.Equals(GRAY))
        {
        Score.ScorePoints = Score.ScoreAdd(1, Score.ScorePoints);
        }
    }
    }
    }

}
//Updates the ball direction when collision happens
public void BallDirectionChangerCollision(bool BlockCollision, Vector2 BallObject, int i, int n)
{
BlockCollision = Collision.BallBlockCollision(BallObject, BlockDictionary[i][n].Block, RADIUS);
        if (BlockCollision == true) 
        {
        if (BallObject.X <= BlockDictionary[i][n].Block.x + 50 && BallObject.X >= BlockDictionary[i][n].Block.x && PowerUpSKYBLUE == false)
        {
            if (BallObject.Y > BlockDictionary[i][n].Block.y)
            {
                GoingUp = false;
            }
            else if (BallObject.Y < BlockDictionary[i][n].Block.y + 20)
            {
                GoingUp = true;
            }
        }
        if (BallObject.Y <= BlockDictionary[i][n].Block.y + 20 && BallObject.Y >= BlockDictionary[i][n].Block.y && PowerUpSKYBLUE == false)
        {
            if (BallObject.X < BlockDictionary[i][n].Block.x + 50)
            {
                SideWaysDirection = 2;
            }
            else if (BallObject.X > BlockDictionary[i][n].Block.x)
            {
                SideWaysDirection = 1;
            }
        }   
        }
}
//Updates the ball direction if bluepower up is on and if it collides with a gray block
public void  BallDirectionChangerCollisionBluePower(bool BlockCollision, Vector2 BallObject, int i, int n)
{
    if (BallObject.X <= BlockDictionary[i][n].Block.x + 50 && BallObject.X >= BlockDictionary[i][n].Block.x && PowerUpSKYBLUE == true && BlockDictionary[i][n].Color.Equals(GRAY))
        {
            if (BallObject.Y > BlockDictionary[i][n].Block.y)
            {
                GoingUp = false;
            }
            else if (BallObject.Y < BlockDictionary[i][n].Block.y + 20)
            {
                GoingUp = true;
            }
        }
        if (BallObject.Y <= BlockDictionary[i][n].Block.y + 20 && BallObject.Y >= BlockDictionary[i][n].Block.y && PowerUpSKYBLUE == true && BlockDictionary[i][n].Color.Equals(GRAY))
        {
            if (BallObject.X < BlockDictionary[i][n].Block.x + 50)
            {
                SideWaysDirection = 2;
            }
            else if (BallObject.X > BlockDictionary[i][n].Block.x)
            {
                SideWaysDirection = 1;
            }
        }
}
// public DifferentBalls RemoveBlockReturnBall(Vector2 BallObject, int i, int n)
// {
//     float XFloat = 0;
//     float YFloat = 0;
//     float XValue = 0;
//     float YValue = 0;
//     Color ColorValue = WHITE;
//     bool BlockCollision = false;

//     if (!BlockDictionary[i][n].Color.Equals(GRAY))
//         {
//         BlockCollision = Collision.BallBlockCollision(BallObject, BlockDictionary[i][n].Block, RADIUS);
//         BallDirectionChangerCollision(BlockCollision, BallObject, i, n);
//         BallDirectionChangerCollisionBluePower(BlockCollision, BallObject, i, n);
//             if (BlockDictionary[i][n].Color.Equals(SKYBLUE))
//                 {
//                 Score.ScorePoints = Score.ScoreAdd(2, Score.ScorePoints);
//                 XFloat = (float)BlockDictionary[i][n].Block.x;
//                 YFloat = (float)BlockDictionary[i][n].Block.y;;
//                 ColorValue = BlockDictionary[i][n].Color;
//                 BlockDictionary[i].Remove(BlockDictionary[i][n]);
//                 }
//             else if (BlockDictionary[i][n].Color.Equals(RED))
//                 {
//                 Score.ScorePoints = Score.ScoreAdd(2, Score.ScorePoints);
//                 XValue = BlockDictionary[i][n].Block.x;
//                 XFloat = (float)XValue;
//                 YValue = BlockDictionary[i][n].Block.y;
//                 YFloat = (float)YValue;
//                 ColorValue = BlockDictionary[i][n].Color;
//                 BlockDictionary[i].Remove(BlockDictionary[i][n]);
//                 }
            
//             else 
//                 {
//                 Score.ScorePoints = Score.ScoreAdd(1, Score.ScorePoints);
//                 BlockDictionary[i].Remove(BlockDictionary[i][n]);
//                 }   
                  
//         }
//     DifferentBalls PowerUpBall = new DifferentBalls(XFloat, YFloat, ColorValue);
//     return PowerUpBall;
// }
//Detects the collision between the blocks and the ball, returns the x and y location of the block as a ball object so if
//it is a power up block is can generate a power up block
public DifferentBalls CollisionBallBlock(Vector2 BallObject)
{
float XValue = 0;
float XFloat = (float)XValue;
float YValue = 0;
float YFloat  = (float)YValue;
Color ColorValue = BLACK;



bool BlockCollision = false;
for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    for (int n = 0; n < BlockDictionary[i].Count(); n++)
    {

        BlockCollision = Collision.BallBlockCollision(BallObject, BlockDictionary[i][n].Block, RADIUS);
        BallDirectionChangerCollision(BlockCollision, BallObject, i, n);
        BallDirectionChangerCollisionBluePower(BlockCollision, BallObject, i, n);
        Console.WriteLine(BlockCollision);
    if (BlockCollision)
    {
        if (!BlockDictionary[i][n].Color.Equals(GRAY))
        {
            if (BlockDictionary[i][n].Color.Equals(SKYBLUE))
                {
                Score.ScorePoints = Score.ScoreAdd(2, Score.ScorePoints);
                XFloat = (float)BlockDictionary[i][n].Block.x;
                YFloat = (float)BlockDictionary[i][n].Block.y;;
                ColorValue = BlockDictionary[i][n].Color;
                BlockDictionary[i].Remove(BlockDictionary[i][n]);
                }
            else if (BlockDictionary[i][n].Color.Equals(RED))
                {
                Score.ScorePoints = Score.ScoreAdd(2, Score.ScorePoints);
                XFloat = (float)BlockDictionary[i][n].Block.x;
                YFloat = (float)BlockDictionary[i][n].Block.y;
                ColorValue = BlockDictionary[i][n].Color;
                BlockDictionary[i].Remove(BlockDictionary[i][n]);
                }
            
            else 
                {
                Score.ScorePoints = Score.ScoreAdd(1, Score.ScorePoints);
                BlockDictionary[i].Remove(BlockDictionary[i][n]);
                }   
                  
        }
        
        }
    }
    }


DifferentBalls PowerUpBall = new DifferentBalls(XFloat, YFloat, ColorValue);
return PowerUpBall;
}   

// Changea the direction of both X and Y direction of ball.
public void UpdateBallXandYDirection(Vector2 BallObject, Rectangle PaddleObject)
{
UpdateBallXDirection(BallObject, PaddleObject);
UpdateBallYDirection(BallObject, PaddleObject);
}


// Changes the Y Direction of the ball
public void UpdateBallYDirection(Vector2 BallObject, Rectangle PaddleObject)
{
    
    if (IsKeyDown(KeyboardKey.KEY_SPACE) && Ball.Launch == false)
    {
        GoingUp = true;
    }
    if (BallObject.Y <= 50)
    {
        GoingUp = false;
    }
    if (GoingUp == false)
    {
        GoingUp = Collision.BallPaddleCollision(BallObject, PaddleObject, RADIUS);
    }
 
}

//Changes the X Direction of the ball
public int UpdateBallXDirection(Vector2 BallObject, Rectangle PaddleObject)
{   
    if (BallObject.X >= 1090 && SideWaysDirection == 1)
    {
        SideWaysDirection = 2;
    }
    else if (BallObject.X < 10 && SideWaysDirection == 2 )
    {
        SideWaysDirection = 1;
    }
    if (Collision.BallPaddleCollision(BallObject, PaddleObject, RADIUS))
    {
        var SideWaysChecker = Paddle.PaddleDirectionChecker();
        if (SideWaysChecker == 1)
        {
            SideWaysDirection = 1;
        }
        else if (SideWaysChecker == 2)
        {
            SideWaysDirection = 2;
        }
    }
    if (Ball.Launch == false)
    {
        var SideWaysChecker = Paddle.PaddleDirectionChecker();
        if (SideWaysChecker == 1)
        {
            SideWaysDirection = 1;
        }
        else if (SideWaysChecker == 2)
        {
            SideWaysDirection = 2;
        }
        else
        {
            SideWaysDirection = 0;
        }
    }
    else
    {
        Paddle.PaddleDirectionChecker();
    }


    return SideWaysDirection;
}
//Updates ball position when it moves
public Vector2 UpdateBallPosition(DifferentBalls DifferentBalls)
{
    DifferentBalls.BallCenter = MoveGeneratedBall(DifferentBalls.BallCenter);
    return DifferentBalls.BallCenter;
}
//Checks is ball is falling down
public bool CheckBallFall(DifferentBalls DifferentBalls)
{
    var StillFalling = true;
    if (DifferentBalls.BallCenter.Y > 910)
    {

    StillFalling = false;
    }
    return StillFalling;
}
//Moves power up ball
public Vector2 MoveGeneratedBall(Vector2 Ball)
{
    Ball.Y += 5;
    return Ball;
}

}










