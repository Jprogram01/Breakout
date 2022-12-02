using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.PixelFormat;


class ObjectMovement: MovementDirection
{
    public BallObjectMovement Ball = new BallObjectMovement();
    public PaddleObjectMovement  Paddle = new PaddleObjectMovement();
    public Collision Collision = new Collision();

    public BlockList BlockList = new BlockList();
    
    public Dictionary<int, List<Blocks>> BlockDictionary;

public ObjectMovement()
{
    BlockDictionary = BlockList.CreateDictionary();
}
public void ObjectsMoving()
{
    UpdateBallXandYDirection(Ball.BallCenter, Paddle.MovingPaddle);
    Ball.BallCenter = Ball.BallMovement(Ball.BallCenter, Paddle.MovingPaddle, GoingUp, SideWaysDirection);
    Paddle.PaddleMovement();
    BlockFunctions(Ball.BallCenter);
}


public void BlockFunctions(Vector2 Ball)
{
    CollisionBallBlock(Ball);
    DrawBlocks();
}
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
public void CollisionBallBlock(Vector2 BallObject)
{
bool BlockCollision = false;
for (int i = 0; i < BlockDictionary.Count(); i++)
    {
    for (int n = 0; n < BlockDictionary[i].Count(); n++)
    {

        BlockCollision = Collision.BallBlockCollision(BallObject, BlockDictionary[i][n].Block);
        if (BlockCollision == true)
        {
        if (BallObject.X <= BlockDictionary[i][n].Block.x + 50 && BallObject.X >= BlockDictionary[i][n].Block.x)
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
        if (BallObject.Y <= BlockDictionary[i][n].Block.y + 20 && BallObject.Y >= BlockDictionary[i][n].Block.y)
        {
            Console.WriteLine("true");
            if (BallObject.X < BlockDictionary[i][n].Block.x + 50)
            {
                SideWaysDirection = 2;
            }
            else if (BallObject.X > BlockDictionary[i][n].Block.x)
            {
                SideWaysDirection = 1;
            }
        }
        BlockDictionary[i].Remove(BlockDictionary[i][n]);
        }
        
    }
    }
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
        GoingUp = Collision.BallPaddleCollision(BallObject, PaddleObject);
    }
 
}

//Changes the X Direction of the ball
public int UpdateBallXDirection(Vector2 BallObject, Rectangle PaddleObject)
{   
    if (BallObject.X >= 1100 && SideWaysDirection == 1)
    {
        SideWaysDirection = 2;
    }
    else if (BallObject.X < 0 && SideWaysDirection == 2 )
    {
        SideWaysDirection = 1;
    }
    if (Collision.BallPaddleCollision(BallObject, PaddleObject))
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
}










