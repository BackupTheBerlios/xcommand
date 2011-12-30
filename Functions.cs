using System;
using System.Collections.Generic;
using System.Text;

namespace X_Command
{
    /// <summary>
    /// This Holds INTERNAL Functions
    /// </summary>
    public static class Functions
    {
        // Stuff For Getting Arguments
        // Argument Get Array String
        public static string argumentgetarstr(string[] input)
        {
            // sets up the output string
            string output;
            // gets rid of the first string in the array and
            input[0] = "";
            // joins the array up + cleans up + returns the arguments
            output = string.Join(" ", input);
            return output.TrimStart(' ');
        }
        // Argument Get String String
        public static string argumentgetstrstr(string input)
        {
            // creates a string array
            string[] inputar = input.Split(new char[] { ' ' });
            // ouputs that string array passed thtough argumentgetarstr
            return argumentgetarstr(inputar);
        }
        // Argument Get Array Array
        public static string[] argumentgetarar(string[] input)
        {
            // creates an argument string by passing input through argumentgetarstr
            string inputstr = argumentgetarstr(input);
            // outputs an array made out of inputstr
            return inputstr.Split(new char[] { ' ' });
        }
        // Argument Get String Array
        public static string[] argumentgetstrar(string input)
        {
            // gets the varibles is string format by passing input through argumentgetstrstr
            input = argumentgetstrstr(input);
            // returns an array made of input
            return input.Split(new char[] { ' ' });
        }

        public static void message(string type, string message)
        {
            if (type == "messagebox") { System.Windows.Forms.MessageBox.Show(message); }
            if (type == "message") { Console.WriteLine(message); }
        }

        // DO NOT USE YET
        //    public static string[] strarr {  }
        //    public static string arrstr {  }




        public static void Pause()
        {
            Console.ReadKey();
        }
    }
}


