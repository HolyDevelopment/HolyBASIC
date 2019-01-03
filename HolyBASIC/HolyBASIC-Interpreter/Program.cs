/*
               BASIC keywords 

               LET - assign value
               DATA - hold a list of values

               IF, THEN, (ELSE) - self-explanatory
               FOR, TO, (STEP), NEXT) - repeat a section of code a given number of times
               WHILE, WEND / REPEAT, UNTIL - repeat a section of code while the specified condition is ture
               DO, LOOP (WHILE)/(UNTIL) - repeat a section of code Forever or While/Until the specified condition is true

               GOTO - jumps to a numbered of labelled line in the program
               GOSUB - jumps to a numbered or labelled line, executes the code it finds there until it reaches a return command
               ON, GOTO/GOSUB - chooses where to jump based on the specified conditions. (basically switch?)
               DEF FN - a pair of keywords introduced in the early 1960s to define functions.

               LIST - displays all inputted code
               PRINT - outputs any sort of message
               INPUT - asks the user to enter the value of a variable
               TAB/AT - sets the position where the next character will be shown on the screen or printed on paper

               ABS - absolute value
               ATN - arctangent value
               COS - cosine value
               EXP - exponential vlaue
               INT - integer value
               LOG - natural logarithmic value
               RND - random value
               SIN - sine value
               SQR - square root value
               TAN - tangent value

               (rest is the more unimportant stuff)

*

               HolyBASIC keywords 

               HOLY - assign value
               DATA - hold a list of values

               IF, THEN, (ELSE) - self-explanatory
               FOR, TO, (STEP), NEXT) - repeat a section of code a given number of times
               WHILE, WEND / REPEAT, UNTIL - repeat a section of code while the specified condition is ture
               DO, LOOP (WHILE)/(UNTIL) - repeat a section of code Forever or While/Until the specified condition is true

               GODMOVE - jumps to a numbered of labelled line in the program
               GOSUB - jumps to a numbered or labelled line, executes the code it finds there until it reaches a return command
               ON, GODMOVE/GOSUB - chooses where to jump based on the specified conditions. (basically switch?)
               DEF FN - a pair of keywords introduced in the early 1960s to define functions.

               GODSLIST - displays all inputted code
               GODSAY - outputs any sort of message
               GODLISTEN - asks the user to enter the value of a variable
               GODTAB - sets the position where the next character will be shown on the screen or printed on paper

               ABS - absolute value
               ATN - arctangent value
               COS - cosine value
               EXP - exponential vlaue
               CMDMT - integer value
               LOG - natural logarithmic value
               RND - random value
               SIN - sine value
               SQR - square root value
               TAN - tangent value
*/

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Interpreter.Logic;

namespace Interpreter
{
    class Program
    {
        static bool Interactivity;

        static void Main(string[] args)
        {
            if (args.Length < 1)
                Environment.Exit(0);

            if (args.Contains("-i"))
                Interactivity = true;

            if (!File.Exists(args[0]) && Interactivity == false)
                Environment.Exit(0);

            Parser.ParseAsync(Lexer.AnalyzeMultiple(File.ReadAllText(args[0]))).ConfigureAwait(false).GetAwaiter().GetResult();

            // InteractiveMode().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task InteractiveMode()
        {
            await Console.Out.WriteLineAsync("HolyBASIC ver pre0.0.0");
            await Console.Out.WriteLineAsync("Welcome to the interactive window! Feel free to do about anything in here!");

            while (true)
            {
                await Console.Out.WriteAsync(">");
                string input = await Console.In.ReadLineAsync();
                
            }
        }
    }
}
