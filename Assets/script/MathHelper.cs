using UnityEngine;
using System.Collections;

public class MathHelper
{
    public static float ToRadians(float degrees)
    {
        return (float)(degrees * (Mathf.PI / 180));
    }

    public static float ToDegrees(float radians)
    {
        return (float)(radians * (180 / Mathf.PI));
    }

    public static float	GetEaseFlow(float flow, NemoEaseMode ease)
	{
		switch (ease)
		{
		case NemoEaseMode.Linear: return flow;
		case NemoEaseMode.CubicIn: return flow*flow*flow;
		case NemoEaseMode.CubicOut: return (flow-1)*(flow-1)*(flow-1)+1;
		case NemoEaseMode.CubicInOut: return ((flow*2<1)? flow*flow*flow*4.0f:((flow-1)*(flow-1)*(flow-1)*8+1)/2.0f+0.5f);
		}
		return 0;
	}

    public static string GetTimeString(int totalSeconds)
    {
        string timeString = "";
        if (totalSeconds > 3600)
        {
            int hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            timeString += string.Concat(hours, ":");
        }

        int minutes = totalSeconds / 60;
        totalSeconds %= 60;
        timeString += string.Concat(minutes, "':");

        timeString += string.Concat(totalSeconds, "\"");
        return timeString;
    }

    public static float GetDegrees(Vector3 p1, Vector3 p2)
    {
        Vector3 diff = (p1 - p2);
        diff.z = 0;
        return MathHelper.ToDegrees(Mathf.Atan2(diff.y, diff.x));
    }

    public static string GetStringWithComma(int n)
    {
        string coinsText = n.ToString();
        int length = coinsText.Length;
        int loopCount = length / 3;

        if (length % 3 == 0)
            loopCount--;

        for (int i = 0; i < loopCount; i++)
        {
            coinsText = coinsText.Insert(length - (3 * (i + 1)) - i, ",");
            length = coinsText.Length;
        }

        return coinsText;
    }
}

public enum NemoEaseMode
{
    Linear,
    CubicIn,
    CubicOut, 
    CubicInOut
}