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

               IMPORT [library] - imports hb library

               holy - assign value
               data - hold a list of values

               if, (else), (elseif), endif - self-explanatory
               for, endfor - repeat a section of code a given number of times
               while, endwhile - repeat a section of code while the specified condition is ture
               do, loop (while) - repeat a section of code Forever or While/Until the specified condition is true

               step - steps in for loops

               GODMOVE - jumps to a numbered of labelled line in the program
               GOSUB - jumps to a numbered or labelled line, executes the code it finds there until it reaches a return command
               ON, GODMOVE/GOSUB - chooses where to jump based on the specified conditions. (basically switch?)
               DEF FunctionName [args]: - function defining

               GODSLIST - displays all inputted code
               GODSAY - outputs any sort of message
               GODLISTEN - asks the user to enter the value of a variable
               GODTAB - sets the position where the next character will be shown on the screen or printed on paper

               (CMDMT - integer value)

               [Misc]
               
               _USENUMBERSYS 0-1 - determines if it should use the order-by-number system (deprecated)
               _IMPORTEXT (C# Module) - import C# module, for EXTERN
               EXTERN (FunctionName) (C# Equivalent) - implement a function that is defined externally

               ## will comment things out
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Interpreter.Logic;

namespace Interpreter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
                Environment.Exit(0);
            else if (args[0] == "-i")
                await InteractiveMode();
            else if (File.Exists(args[0]))
                Parser.Parse(Lexer.Analyze(await File.ReadAllLinesAsync(args[0])));
        }

        static async Task InteractiveMode()
        {
            await Console.Out.WriteLineAsync("HolyBASIC ver pre0.0.0");
            await Console.Out.WriteLineAsync("Welcome to the interactive window! Feel free to do about anything in here!\n");

            while (true)
            {
                await Console.Out.WriteAsync($"> ");
                List<string> _code = new List<string>();

                while (true)
                {
                    string input = await Console.In.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(input))
                        break;
                    _code.Add(input);
                }

                try
                {
                    Parser.Parse(Lexer.Analyze(_code.ToArray()));
                } catch (Exception e)
                {
                    await Console.Out.WriteLineAsync($"Error!: {e.Message}");
                }
            }
        }
    }
}
