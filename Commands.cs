using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace X_Command
{
    /// <summary>
    /// This Holds The Commands You Enter At The Prompt
    /// </summary>
    public static class Commands
    {
        // the prompt command: sets the prompt
        public static void promptset(string[] input)
        {
            // gets the arguments
            string args = Functions.argumentgetarstr(input);
            // then sets the prompt to the arguments
            values.prompt = args;
        }

        // the cd command
        public static void cd(bool up, string[] input)
        {
            string dir;
            // checks if cd.. was entered via bool
            if (up == false)
            {
                // if not then gets the arguments
                dir = Functions.argumentgetarstr(input);
            }
            // else it just sets dir to ".."
            else { dir = ".."; }

            // starts the dir move...
            try
            {
                Environment.CurrentDirectory = (dir);
            }
            catch
            {
                // if it fails this should output somthing appropriate eg: cd = C:\ cd weet = Folder Doesn't Exist: weet
                if (dir == "") { Console.WriteLine(Directory.GetCurrentDirectory() + "\n"); }
                else { Console.WriteLine("Folder Doesn't Exist: " + dir + "\n"); }
            }
        }

        // The version output
        public static void ver()
        {
            // starts the art command with "xcommand" as the argument
            art("logo");
            // outputs the real infomation
            Console.WriteLine("Version: " + values.version);
            Console.WriteLine("Programmed By: " + values.programmer);
            Console.WriteLine("Testing By: " + values.tester);
            Console.WriteLine("Of " + values.company);
            Console.WriteLine();
        }

        // the art command
        public static void art(string arttype)
        {
            // if the art type is "xcommand" output the xcommand logo
            if (arttype == "logo")
            {
                // gets the xcommand logo from values
                Console.WriteLine(values.logo);
            }
            // else just echo the input
            else { Console.WriteLine(arttype); }
        }

        // Lists the files in a directory
        public static void dir(String[] args)
        {
            string path = Environment.CurrentDirectory;
            if (args.Length > 1)
            {
                if (Directory.Exists(args[1]))
                {
                    path = args[1];
                }
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                foreach (FileInfo f in dir.GetFiles("*.*"))
                {
                    string name = f.Name;
                    long size = f.Length;
                    DateTime creationTime = f.CreationTime;
                    Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", size,
                        creationTime, name);
                }
            }
                // writes out error message if dir is unautherized
            catch (UnauthorizedAccessException) { Console.WriteLine("Acesses Denied!"); }
        }

        public static void messagebox (string input) { Functions.message("messagebox",Functions.argumentgetstrstr(input)); }
        public static void echo (string input) { Functions.message("message", Functions.argumentgetstrstr(input)); }

        internal static void Help(string[] inputlr)
        {
            string[] args = Functions.argumentgetarar(inputlr);
            Console.WriteLine(@"X/COMMAND Help

Command   |Argument
-------------------
Help      |
echo      |text
messagebox|text
dir/ls    |
prompt    |prompt
cls       |
art       |arttype
ver       |
cd        |directory
cd..      |
pause     |text
intcommand|internel command
XCL ONLY COMMANDS!
chkver    |version
");
        }

        public static void Pause() { Pause("Press Any Key..."); }
        public static void Pause(string key)
        {
            Console.Write(key);
            Functions.Pause();
            Console.WriteLine();
        }

        public static bool chkver(string ver) {
            if (values.numver != ver) { return true; }
            else { return false; }
        }

        public static void intcommand(string[] inputlr, string[] input)
        {
            string[] cmd = Functions.argumentgetarar(inputlr) ;
            if (cmd[0] == "argumentget") { Console.WriteLine(Functions.argumentgetarstr(Functions.argumentgetarar(Functions.argumentgetarar(input)))); return; }
            if (cmd[0] == "mainloop") { Program.MainLoop(); return; }
            Console.WriteLine("Bad Argument!");
        }
    }
}
