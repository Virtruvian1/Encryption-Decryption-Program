using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace EncryptionExercise
{
    public class Encryption
    {

        public Encryption()
        {
            Console.Write("Enter in data to be encrypted: ");
            string input = Console.ReadLine();
            input = SanitizeInput(input);
            string key = SetKey();
            string output = EncryptSanitizedInput(input, KeyConversion(key));
            Console.WriteLine($"Output is {output}");
        }

        private string SanitizeInput(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    output += char.ToUpper(c);
                }
            }
            return output;
        }

        private string SetKey()
        {
            Console.Write("Enter a key <MUST BE ALL CAPS NO SPACES>: ");
            string key = Console.ReadLine();
            return key;
        }

        private int[] KeyConversion(string key)
        {
            int[] keyCount = new int[key.Length];
            int i = 0;

            foreach(char c in key)
            {
                keyCount[i] = ((int)c - 64);
                if (i < key.Length) { i++; }
            }

            return keyCount;
        }

        private string EncryptSanitizedInput(string SanitizedInput, int[] keyCount)
        {
            int counter = 0;
            string EncryptedOutput = "";

            foreach (char c in SanitizedInput)
            {
                bool iterateLoop = true;
                int number = ((int)c-64) + (keyCount[counter]);
                Console.WriteLine($"{number}");
                do
                {
                    if (number > 26) { number = number - 26; }
                    else { iterateLoop = false; }
                } while (iterateLoop);

                int result = number + 64;
                EncryptedOutput += (char)result;

                // Counter increment for key
                if (counter != (keyCount.Length-1)) { counter++; }
                else { counter = 0; }
            }

            return EncryptedOutput;
        }
    }


    class Decrypt
    {
        internal string ptMessage;
        internal string ctMessage;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Encryption encrypt = new Encryption();
            
        }
    }
}
