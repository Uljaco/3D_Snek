struct Bounds
{
    int xmax { get; set; }
    int ymax { get; set; }
    int xmin { get; set; }
    int ymin { get; set; }

    public void set(int newXMax, int newXMin, int newYMax, int newYMin)
    {
        xmax = newXMax;
        xmin = newXMin;
        ymax = newYMax;
        ymin = newYMin;
    }
}