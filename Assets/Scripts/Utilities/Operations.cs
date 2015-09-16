using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Operations
{
	public static void Shuffle<T>(IList<T> list)  
	{  
		System.Random selector = new System.Random();
		int i = list.Count;  
		
		while (i > 1) 
		{
			i--;  
			int j = selector.Next(i + 1);  
			T value = list[j];  
			list[j] = list[i];  
			list[i] = value;  
		}  
	}
    public static AudioManager AudioManager()
    {
        return GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public static float Distance(float n1, float n2)
    {
        float distance = n1 - n2;

        return distance;
    }
    public static float Module(float n1)
    {
        if (n1 < 0)
            n1 *= -1;

        return n1;
    }
    public static string KnowStringDirection(float n1)
    {
    	if(n1 >= 0)
    		return "Right";
    		
    	else
    		return "Left";
    }
    public static int KnowIntDirection(string direction)
    {
        if (direction.Equals("Up") || direction.Equals("Right"))
            return 1;

        else
            return -1;
    }
    public static int KnowIntDirection(float n1)
    {
        if (n1 >= 0)
            return 1;

        else
            return -1;
    }
    public static int KnowIntDirection(float n1, float n2)
    {
        if (n1 <= n2)
            return 1;

        else
            return -1;
    }
    public static int Raw(float n1)
    {
        if (n1 > 0)
            return 1;

        else
            return -1;
    }
    public static int Random(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    public static float Random(float min, float max)
    {
    	return UnityEngine.Random.Range(min,max);
    }
    public static string CompareSignals(float n1, float n2)
    {
        if (n1 > 0 && n2 < 0 || n1 < 0 && n2 > 0)
            return "!=";
        else if (n1 > 0 && n2 > 0 || n1 < 0 && n2 < 0)
            return "==";
        else
            return "ERROR: It was not possible to compare.";
    }
    public static bool StringEquals(string main, string[] targets)
    {
        char[] damage = main.ToCharArray();
        string verificator = "";
        bool theReturn = false;

        for (int i = 0; i < damage.Length; i++)
        {
            verificator += damage[i];

            for(int j = 0; j < targets.Length; j++)
            {
                if (verificator.Equals(targets[j]))
                {
                    theReturn = true;
                    break;
                }
            }
        }

        return theReturn;
    }
    public static bool TargetIsClose(float start, float target, float distance_MIN)
    {
        float distance = Operations.Module(start - target);

        if (distance > distance_MIN)
            return false;

        else
            return true;
    }
}
