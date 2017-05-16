namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TextEditorWithStack
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var text = new StringBuilder();
            
            var undoStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Trim();
                var tokens = line.Split().ToList();
              
                if (tokens.Count > 1)
                {
                    var command = tokens[0];
                    if (command == "1")
                    {
                        var textToAppend = tokens[1];
                        text.Append(textToAppend);

                        undoStack.Push(line);
                    }
                    else if (command == "2")
                    {
                        var count = int.Parse(tokens[1]);
                        var textToRemove = text.ToString().Substring(text.Length - count);

                        text.Remove(text.Length - count, count);

                        tokens.Add(textToRemove);
                        undoStack.Push(line + " " + textToRemove);
                    }
                    else if (command == "3")
                    {
                        var index = int.Parse(tokens[1]);
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (tokens[0] == "4") 
                {
                    var undoTokens = undoStack.Pop().Split();

                    var undoCommand = undoTokens[0];

                    if (undoCommand == "1")
                    {
                        var undoCount = undoTokens[1].Length;

                        text.Remove(text.Length - undoCount, undoCount);
                    }
                    else
                    {
                        var textToAppend =undoTokens[2];

                        text.Append(textToAppend);
                    }
                }
            }
        }
    }
}
