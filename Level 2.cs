class Level2: ObjectInteraction
{

public Level2()
{
    DictionaryLoader(2);
}
new public bool NextLevelChecker()
{
    int LinesCleared = 0;
    bool Cleared = false;
    for (int i = 0; i < BlockDictionary.Count(); i++)
    {
        if(BlockDictionary[i].Count == 4 || BlockDictionary[i].Count == 0 )
        {   
            LinesCleared += 1;
            Console.WriteLine(LinesCleared);
            if (LinesCleared == 8)
            {
            Cleared = true;
            }
        }
    }
    return Cleared;
}
}