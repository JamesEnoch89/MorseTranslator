using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 Download and use csv file in path of current project. 
    - Make sure to understand the path so you are reading/writing the same one everytime
 As a user I should be able to type in a phrase (readline) to convert.
    - prompt the user (readline)
    - This phrase can take in letters and numbers
The program should convert that text that the user typed into Morse Code 
    via the csv dictionary.
The program should display the converted text to the user
    - writeline the user input 
    - study more about write/read line and write/read stream and their different use cases
THe program should ask the user if they have another word to convert. If yes repeat the process.
morseLibrary.Add(Convert.ToChar(letterInfo[0]), letterInfo[1]);
*/

namespace MorseConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var morseLibrary = new Dictionary<char, string>();
            // read the csv content store to morseLib
            const string FILE_PATH = "../../morse.csv";
            using (var reader = new StreamReader(FILE_PATH))
            // Add the dictionary components, convert the phrase to chars
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(',');
                    morseLibrary.Add(Convert.ToChar(line[0].ToLower()), line[1]);
                }

            }
            var isRunning = true;
            while (isRunning)
            // convert the input phrase 
            {
                Console.WriteLine("Type In A Word, Phrase, Or Letter And See The Result In Morse Code!");
                var userInput = Console.ReadLine();
                var letters = userInput.ToLower().ToCharArray();
                var morseOutput = "";

                foreach (char letter in letters)
                {
                    if (morseLibrary.ContainsKey(letter))
                    {
                        morseOutput = morseOutput + morseLibrary[letter];
                    }
                    else
                    {
                        morseOutput = morseOutput + letter;
                    }
                }

                Console.WriteLine($"Your input {userInput} converts to {morseOutput} in Morse code");

                Console.WriteLine("Do you want to translate something else into Morse code? (Yes) or (No)");
                var translateAgainResponse = Console.ReadLine().ToLower();
                if (translateAgainResponse == "no")
                {
                    isRunning = false;
                }
                    else
                {
                    isRunning = true;
                }

            }
        }
    }
}
