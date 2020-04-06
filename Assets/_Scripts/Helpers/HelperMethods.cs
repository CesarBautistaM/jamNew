/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 02:47:27
Description:  Helper methods for basic math operations 
*/


public class HelpMethods
{

    // Wraps a given input between a given range
    // Useful to keep time tracking variables between clock ranges (0 to 59 mins, 0 to 24 hours, etc)
    public static int WrapNumber(int minVal, int maxVal, int val)
    {
        return (minVal + (val - minVal) % (maxVal - minVal));
    }
}