using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace X_Command
{
    /// <summary>
    /// This is the main code
    /// </summary>
    // values for program (should be self explanatory)
    public static class values
    {
        // sets up read only values
        public const string version = "0.9.0.1 Testing";
        public const string numver = "0901";
        public const string name = "X/Command";
        public const string nameversion = name + " " + version;
        public const string company = "INTERTECK";
        public const string programmer = "Skye Macdonald";
        public const string tester = "Charity Hall" ;
        public const string progcomp = programmer + " Of " + company;
        public const string testcomp = tester + " Of " + company ; 
        public const string defualtprompt = ">";
        // my squished asci art but when you enter "art xcommand" Good asci art? :-)
        public const string logo = "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n+X   X     /   CCCC  OOOOOO     MMM          MMM         A      NN    N DDDD  +\n+ X X     /   C      O    O    M M M        M M M       A A     N N   N D   D +\n+  X     /   C       O    O   M  M  M      M  M  M     AAAAA    N  N  N D    D+\n+ X X   /     C      O    O  M   M   M    M   M   M   A     A   N   N N D   D +\n+X   X /       CCCC  OOOOOO M    M    M  M    M    M A       A  N    NN DDDD  +\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" ;
        public const string autorun = "autocmd.xcl" ;
        // Sets up editable values
        public static string prompt { get; set; }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            // start of execution
            string arg = "";
            string arglr;
            string[] argar;
            string[] arglrar;

            //set editable values
            values.prompt = values.defualtprompt;

            try
            {
                arg = string.Join(" ", args);
                //makes lowercase arg string in arglr
                arglr = arg.ToLower();
                // converts string "inputlr" to an array of strings called "arglrar"
                arglrar = arglr.Split(new char[] { ' ' });
                // converts string "input" to an array of strings called "inputar" 
                argar = arg.Split(new char[] { ' ' });
            }
            catch { arg = "";
            //makes lowercase arg string in arglr
            arglr = arg.ToLower();
            // converts string "inputlr" to an array of strings called "arglrar"
            arglrar = arglr.Split(new char[] { ' ' });
            // converts string "input" to an array of strings called "inputar" 
            argar = arg.Split(new char[] { ' ' });
            }

            if (arglrar[0] == "/c") {
                arg = Functions.argumentgetstrstr(arg);
                arglr = Functions.argumentgetstrstr(arglr);
                arglrar = Functions.argumentgetarar(arglrar);
                argar = Functions.argumentgetarar(argar);
                // starts the command find system & see if the command was (in)valid and prints error message if appropriate
                if (cmdrun(arglrar, argar, arg) == true) { Console.WriteLine("Bad Command: " + argar[0]); }
                return;
            }
            else { if (File.Exists(arg)) { xclrun(arg); return; } }
            // Sets title & Shows welcome text
            Console.WriteLine("Welcome To " + values.nameversion + "\nProgramed By " + values.progcomp + "\nTesting By " + values.testcomp +"\n");
            Console.Title = "X/Command " + values.version;
            if (File.Exists(values.autorun)) { xclrun(values.autorun); }
            MainLoop();
            return;
        }

        // Main Loop (asks for command executes it, cleans up and start again untill exit is entered)
        public static void MainLoop () 
        {
            for (string input = "" ; input != "exit" ; input = "" ) {
                // Gets The Input
                input = Input(input);
                // makes new lowercase string
                string inputlr = input.ToLower();
                // converts string "inputlr" to an array of strings called "inputlrar" 
                string[] inputlrar = inputlr.Split(new char[] { ' ' });
                // converts string "input" to an array of strings called "inputar" 
                string[] inputar = input.Split(new char[] { ' ' });
                // exits in string is "exit"
                if (inputlrar[0] == "exit") { return; }
                // starts the command find system & see if the command was (in)valid and prints error message if appropriate
                if (cmdrun(inputlrar,inputar,input) == true) { Console.WriteLine("Bad Command: "+inputar[0]); }
            }
        }

        // Input (askes for input)
        static string Input(string input)
        {
            // shows the current directory & writes out the prompt
            Console.Write(Directory.GetCurrentDirectory());
            Console.Write(values.prompt);
            // gets the string
            input = Console.ReadLine();
            // returns input
            return input ;
        }

        public static Boolean cmdrun(string[] inputlr, string[] input, string inputstr)
        {
            // does internel commands
            if (inputlr[0] == "intcommand") { Commands.intcommand(inputlr, input); return false; }
            // pauses
            if (inputlr[0] == "pause") { if (input.Length >= 2) { Commands.Pause(Functions.argumentgetarstr(input)); } else { Commands.Pause(); } return false; }
            // shows help
            if (inputlr[0] == "help") { Commands.Help(inputlr); return false; }
            // checks if the command is echo
            if (inputlr[0] == "echo") { Commands.echo(inputstr); return false; }
            // Checks For The Messagebox Command
            if (inputlr[0] == "messagebox") { Commands.messagebox(inputstr); return false; }
            // Checks For The ls and dir commands
            if (inputlr[0] == "dir") { Commands.dir(input); return false; }
            if (inputlr[0] == "ls") { Commands.dir(input); return false; }
            // Checks if the command is "prompt" and then goes to prompt()
            if (inputlr[0] == "prompt") { Commands.promptset(input); return false; }
            // Checks if the command is cls and then clears the screen
            if (inputlr[0] == "cls") { Console.Clear(); return false; }
            // checks for art command and arguments if ok goes to art()
            if (inputlr[0] == "art") { try { Commands.art(inputlr[1]); } catch (IndexOutOfRangeException) { Console.WriteLine("No Arguments for: " + inputlr[0]); } return false; }
            // Checks if ver command is entered and then goes to ver()
            if (inputlr[0] == "ver") { Commands.ver(); return false; }
            // checks for "cd" command and then goes to cd() if cd.. is entered tells cd() to go up a directory
            if (inputlr[0] == "cd") { Commands.cd(false, input); return false; }
            if (inputlr[0] == "cd..") { Commands.cd(true, input); return false; }
            if (File.Exists(inputstr)) { xclrun(inputstr); return false; }
            if (File.Exists(inputstr + ".xcl")) { xclrun(inputstr+".xcl"); return false; }
            // Checks if there is a command and then returns false if appropriate (MUST BE AT END)
            if (inputlr[0] == "") { return false; } else { return true; }
        }

        public static void xclrun(string filename)
        {
            string line = "" ;
            TextReader text = new StreamReader(filename);
            while (line != null)
            {
                // reads the file
                line = text.ReadLine();
                // ends if line is null
                if (line == null) { text.Close() ; return; }
                // makes new lowercase string
                string inputlr = line.ToLower();
                // converts string "inputlr" to an array of strings called "inputlrar" 
                string[] inputlrar = inputlr.Split(new char[] { ' ' });
                // converts string "line" to an array of strings called "inputar" 
                string[] inputar = line.Split(new char[] { ' ' });
                // exits in string is "exit"
                if (inputlrar[0] == "exit") { return; }
                if (inputlrar[0] == "chkver") { if (Commands.chkver(inputlr)) { return; } }
                // starts the command find system & see if the command was (in)valid and prints error message if appropriate
                if (cmdrun(inputlrar, inputar, line) == true) { Console.WriteLine("Bad Command: " + inputar[0]); }
            }
        }

    }
}

