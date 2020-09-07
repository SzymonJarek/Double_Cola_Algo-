//Solution 1:

using System;

public class Line
    {
        public static string WhoIsNext(string[] names , long n)
        { 
            float len = names.Length;
            
            //find right row
            while(len < n)
            {
                n = n - (long)len;
                len *= 2;
            }
            
            //find right index 
            return names[(int)Math.Ceiling(n / (len / names.Length)) - 1];
        }
    }

//Solution 2: (Recursive)

using System;

public class Line
{
    public static string WhoIsNext(string[] names , long n)
    {
        var l = names.Length;
        return n <= l ? names[n - 1] : WhoIsNext(names, (n - l + 1) / 2);
    }
}

// Explenation (by SicarianKIssstalker): 

// I will try to explain this decision:
// imagine what our series looks like abcde 2a2b2c2d2e... and so on.
// if n<names.Length, it is very easy to determine who drank the right bottle.
// Otherwise, we simplify our range of names.

// n - l - We "cut" first names. We cut "abcde". and our range become 2a2b2c2d2e 4a4b4c4d4e...
// +1 - to make sure that after dividing by 2 we will not lose some elements
// /2 - when we divide, our "new" range from "2a2b2c2d2e 4a4b4c4d4e..." become "abcde 2a2b2c2d2e".
// So, we made new range the same as the old, but shorter.
