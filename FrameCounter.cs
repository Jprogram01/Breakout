class Frame
{
    public int FrameCount;

    public int Second;

    public Frame()
    {
    FrameCount = 0;
    Second = 0;
    }
    public int SecondCounter()
    {
    FrameCount += 1;
    if (FrameCount == 10)
    {
        Second += 1;
        FrameCount = 0;
    }
    return Second;
    }
    


}