// BEGIN CUT HERE
// PROBLEM STATEMENT
// 
// Sometimes when computer programs have a limited number of colors to use, they use a technique called dithering.  Dithering is when you use a pattern made up of different colors such that when the 
// colors are viewed together, they appear like another color.  For example, you can use a checkerboard pattern of black and white pixels to achieve the illusion of gray.
// 
// 
// 
// You are writing a program to determine how much of the screen is covered by a certain dithered color.  Given a computer screen where each pixel has a certain color, and a list of all the solid 
// colors that make up the dithered color, return the number of pixels on the screen that are used to make up the dithered color.  Each pixel will be represented by a character in screen.  Each 
// character in screen and in dithered will be an uppercase letter ('A'-'Z') representing a color.
// 
// 
// 
// Assume that any pixel which is a color contained in dithered is part of the dithered color.
// 
// 
// DEFINITION
// Class:ImageDithering
// Method:count
// Parameters:string, string[]
// Returns:int
// Method signature:int count(string dithered, string[] screen)
// 
// 
// CONSTRAINTS
// -dithered will contain between 2 and 26 upper case letters ('A'-'Z'), inclusive.
// -There will be no repeated characters in dithered.
// -screen will have between 1 and 50 elements, inclusive.
// -Each element of screen will contain between 1 and 50 upper case letters ('A'-'Z'), inclusive.
// -All elements of screen will contain the same number of characters.
// 
// 
// EXAMPLES
// 
// 0)
// "BW"
// {"AAAAAAAA",
//  "ABWBWBWA",
//  "AWBWBWBA",
//  "ABWBWBWA",
//  "AWBWBWBA",
//  "AAAAAAAA"}
// 
// Returns: 24
// 
// Here, our dithered color could consist of black (B) and white (W) pixels, composing a shade of gray.  In the picture, there is a dithered gray square surrounded by another color (A).
// 
// 1)
// "BW"
// {"BBBBBBBB",
//  "BBWBWBWB",
//  "BWBWBWBB",
//  "BBWBWBWB",
//  "BWBWBWBB",
//  "BBBBBBBB"}
// 
// Returns: 48
// 
// Here is the same picture, but with the outer color replaced with black pixels.  Although in reality, the outer pixels do not form a dithered color, your algorithm should still assume they are part 
// of the dithered pattern.
// 
// 2)
// "ACEGIKMOQSUWY"
// {"ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
//  "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
//  "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
//  "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
//  "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
//  "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX"}
// 
// Returns: 150
// 
// A picture of vertical stripes, every other stripe is considered part of the dithered color.
// 
// 3)
// "CA"
// {"BBBBBBB",
//  "BBBBBBB",
//  "BBBBBBB"}
// 
// Returns: 0
// 
// The dithered color is not present.
// 
// 4)
// "DCBA"
// {"ACBD"}
// 
// Returns: 4
// 
// The order of the colors doesn't matter.
// 
// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class ImageDithering {
    public int count(string dithered, string[] screen) {
        int res = 0;

        for (int i = 0; i < screen.Length; i++)
        {
            for (int j = 0; j < screen[i].Length; j++)
            {
                for (int color = 0; color < dithered.Length; color++)
                {
                    if (screen[i][j] == dithered[color])
                    {
                        res++;
                    }
                }
            }
        }

        return res;
    }

// BEGIN CUT HERE
    public static void Main(String[] args) {
        try  {
            eq(0,(new ImageDithering()).count("BW", new string[] {"AAAAAAAA",
                "ABWBWBWA",
                "AWBWBWBA",
                "ABWBWBWA",
                "AWBWBWBA",
                "AAAAAAAA"}),24);
            eq(1,(new ImageDithering()).count("BW", new string[] {"BBBBBBBB",
                "BBWBWBWB",
                "BWBWBWBB",
                "BBWBWBWB",
                "BWBWBWBB",
                "BBBBBBBB"}),48);
            eq(2,(new ImageDithering()).count("ACEGIKMOQSUWY", new string[] {"ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX"}),150);
            eq(3,(new ImageDithering()).count("CA", new string[] {"BBBBBBB",
                "BBBBBBB",
                "BBBBBBB"}),0);
            eq(4,(new ImageDithering()).count("DCBA", new string[] {"ACBD"}),4);
        } 
        catch( Exception exx)  {
            System.Console.WriteLine(exx);
            System.Console.WriteLine( exx.StackTrace);
        }
    }
    private static void eq( int n, object have, object need) {
        if( eq( have, need ) ) {
            Console.WriteLine( "Case "+n+" passed." );
        } else {
            Console.Write( "Case "+n+" failed: expected " );
            print( need );
            Console.Write( ", received " );
            print( have );
            Console.WriteLine();
        }
    }
    private static void eq( int n, Array have, Array need) {
        if( have == null || have.Length != need.Length ) {
            Console.WriteLine("Case "+n+" failed: returned "+have.Length+" elements; expected "+need.Length+" elements.");
            print( have );
            print( need );
            return;
        }
        for( int i= 0; i < have.Length; i++ ) {
            if( ! eq( have.GetValue(i), need.GetValue(i) ) ) {
                Console.WriteLine( "Case "+n+" failed. Expected and returned array differ in position "+i );
                print( have );
                print( need );
                return;
            }
        }
        Console.WriteLine("Case "+n+" passed.");
    }
    private static bool eq( object a, object b ) {
        if ( a is double && b is double ) {
            return Math.Abs((double)a-(double)b) < 1E-9;
        } else {
            return a!=null && b!=null && a.Equals(b);
        }
    }
    private static void print( object a ) {
        if ( a is string ) {
            Console.Write("\"{0}\"", a);
        } else if ( a is long ) {
            Console.Write("{0}L", a);
        } else {
            Console.Write(a);
        }
    }
    private static void print( Array a ) {
        if ( a == null) {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for ( int i= 0; i < a.Length; i++ ) {
            print( a.GetValue(i) );
            if( i != a.Length-1 ) {
                Console.Write(", ");
            }
        }
        Console.WriteLine( '}' );
    }
// END CUT HERE
}
