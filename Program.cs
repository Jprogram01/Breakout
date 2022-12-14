using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;




namespace BreakOut
{
class Program



{

           
           public static void Main()
        {
            //sets things up
            // ObjectMovement MovingObjects = new ObjectMovement();
            PlayerLives PlayerLives = new PlayerLives();
            TopDisplay TopDisplay = new TopDisplay();
            BlockList BlocksList = new BlockList();
            Level1 Level1 = new Level1();
            Level2 Level2 = new Level2();
            Level3 Level3 = new Level3();
            Score Score = new Score();
            Restart restart = new Restart();
            var ScreenHeight = 900;
            var ScreenWidth = 1110;
            var frames = 0;
            int CurrentScore = 0;
            bool GameOver = false;
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Breakout");
            Raylib.InitAudioDevice();
            Raylib.SetTargetFPS(60);
           

        

           


            while (!Raylib.WindowShouldClose())
            {
            PlayerLives.GameOver = GameOver;
            Level1.Score.ScorePoints= CurrentScore;
            Level2.Score.ScorePoints= CurrentScore;
            Level3.Score.ScorePoints= CurrentScore;
                if (GameOver == false)
                {
                    //Runs level 1
                    if (PlayerLives.Level == 1)
                            {
                            Raylib.BeginDrawing();
                            Raylib.ClearBackground(Color.BLACK);
                            Level1.ObjectsInteracting();
                            CurrentScore = Level1.Score.ScorePoints;
                            TopDisplay.DisplayAll(PlayerLives.Lives, CurrentScore);
                            GameOver = PlayerLives.PlayerLivesDisplay(Level1.Ball.BallCenter);
                            //Sets the score and lives for the next level
                            if (Level1.NextLevelChecker())
                                {
                                    Level2.Score.ScorePoints =Level1.Score.ScorePoints;
                                    PlayerLives.Level += 1;
                                    PlayerLives.Lives += 1;
                                }
                            Raylib.EndDrawing();
                            }
                            //Displays a brief intermission page between levels
                    if (PlayerLives.Level == 2)
                        {
                        while (frames != 300)
                        {
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.BLACK);
                        DrawText("You Beat level 1!!!", 100, 450, 100, Color.BLUE); 
                        Raylib.EndDrawing();
                        frames += 1;
                        }
                        //Runs level 2
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.BLACK);
                        Level2.ObjectsInteracting();
                        CurrentScore = Level2.Score.ScorePoints;
                        TopDisplay.DisplayAll(PlayerLives.Lives, Level2.Score.ScorePoints);
                        GameOver = PlayerLives.PlayerLivesDisplay(Level2.Ball.BallCenter);
                        //Sets the score and lives for the next level
                        if (Level2.NextLevelChecker())
                            {
                                PlayerLives.Level += 1;
                                PlayerLives.Lives += 1;
                                Level3.Score.ScorePoints =Level2.Score.ScorePoints;
                                frames = 0;
                            }                       
                        Raylib.EndDrawing();
                        }
                    if (PlayerLives.Level == 3)
                        {
                        //Brief intermission page between levels
                        while (frames != 300)
                        {
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.BLACK);
                        DrawText("You Beat level 2!!!", 100, 450, 100, Color.BLUE); 
                        Raylib.EndDrawing();
                        frames += 1;
                        }
                        //Runs level 3
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.BLACK);
                        Level3.ObjectsInteracting();
                        CurrentScore = Level3.Score.ScorePoints;
                        TopDisplay.DisplayAll(PlayerLives.Lives, Level3.Score.ScorePoints);
                        GameOver = PlayerLives.PlayerLivesDisplay(Level3.Ball.BallCenter);
                        //Updates score
                        if (Level3.NextLevelChecker())
                            {
                                PlayerLives.Level += 1;
                                CurrentScore += PlayerLives.Lives * 100;
                            }
                        Raylib.EndDrawing();
                        }


                    }
                    if (PlayerLives.Level == 4)
                        {
                        //Runs win page
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.BLACK);
                        DrawText("You WON!!!", 300, 450, 100, Color.GOLD); 
                        DrawText($"Your Score:{CurrentScore}", 200, 600, 100, Color.PINK);
                        bool WinRestart = restart.playAgain();
                        //Resets the game when the restart button is pressed.
                        if (WinRestart == false){
                            GameOver = false;
                            PlayerLives.Lives = 3;
                            PlayerLives.Level = 1;
                            CurrentScore = 0;
                            Level1.BlockDictionary.Clear();
                            Level2.BlockDictionary.Clear();
                            Level3.BlockDictionary.Clear();
                            Level1.DictionaryLoader(1);
                            Level2.DictionaryLoader(2);
                            Level3.DictionaryLoader(3);
                        }
                        Raylib.EndDrawing();
                        }

                else if (GameOver == true)
                {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                DrawText("You LOST!!!", 300, 450, 100, Color.RED);
                DrawText($"Your Score:{CurrentScore}", 200, 600, 100, Color.PINK);
                // Restarts the level if the restart button pressed.
                bool pg = restart.playAgain();
                if (pg == false){
                    if (GameOver)
                    {
                    GameOver = false;
                    PlayerLives.Lives = 3;
                    PlayerLives.Level = 1;
                    CurrentScore = 0;
                    Level1.BlockDictionary.Clear();
                    Level2.BlockDictionary.Clear();
                    Level3.BlockDictionary.Clear();
                    Level1.DictionaryLoader(1);
                    Level2.DictionaryLoader(2);
                    Level3.DictionaryLoader(3);
                    }
                }
                Raylib.EndDrawing();
                

                }
            }
            
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow(); 
            
        }
    }
}
