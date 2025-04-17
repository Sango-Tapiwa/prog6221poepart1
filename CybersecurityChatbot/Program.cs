using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //Needed for reading the ASCII art file
using System.Media;         
using System.Threading;     

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            PlayVoiceGreeting("greeting.wav");

            ShowAsciiArt("ascii_art.txt");

            //Ask the user for their name – adds a personal touch
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHello! What's your name?");
            Console.ResetColor();
            Console.Write("> ");
            string name = Console.ReadLine();

            // Will keep asking until user actually types something – no blank names allowed
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a valid name:");
                Console.Write("> ");
                name = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome, {name}! I'm your Cybersecurity Awareness Assistant.\n");
            PrintWithTypingEffect("You can ask me about:\n- Password safety\n- Phishing\n- Safe browsing\n\nType a question or say 'exit' to leave.\n");

            //Cchat begins 
            while (true)
            {
                //Shows a prompt in yellow so it's clear where to type
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                //Read what the user typed and convert it to lowercase to keep things simple
                string input = Console.ReadLine().ToLower();

                //If they just hit enter or typed nothing, ask them to try again
                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintWithTypingEffect("I did not quite understand that. Could you please rephrase?");
                    continue;
                }

                //If they type exit end the chat
                if (input.Contains("exit")) break;

                //Bot's response labeled in green for clarity
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Bot: ");
                Console.ResetColor();

                //What the user is asking and respond accordingly
                if (input.Contains("how are you"))
                {
                    PrintWithTypingEffect("I'm just a bot, but I'm here to help you stay cyber safe!");
                }
                else if (input.Contains("purpose"))
                {
                    PrintWithTypingEffect("I'm here to teach you about online safety and cybersecurity.");
                }
                else if (input.Contains("password"))
                {
                    PrintWithTypingEffect("Create strong, unique passwords that are at least 16 characters long and include a mix of uppercase and lowercase letters, numbers, and symbols.");
                }
                else if (input.Contains("phishing"))
                {
                    PrintWithTypingEffect("Phishing is when scammers try to trick you into giving up private info by pretending to be someone you trust. Be cautious and never click suspicious links!");
                }
                else if (input.Contains("browsing"))
                {
                    PrintWithTypingEffect("Safe browsing means avoiding dangerous websites and downloads. Stick to secure sites (those starting with https), and be mindful of pop-ups or weird downloads.");
                }
                else if (input.Contains("what can i ask"))
                {
                    PrintWithTypingEffect("You can ask me about password safety, phishing, or safe browsing tips.");
                }
                else
                {
                    //If the bot didn’t understand the question – promps the user for clearer wording
                    PrintWithTypingEffect("I didn't quite understand that. Could you rephrase?");
                }
            }

            //Wraps up things with a friendly goodbye
            PrintWithTypingEffect($"\nGoodbye {name}, stay safe online!");
        }

        //Method handles the audio greeting – plays a WAV file when the bot starts
        static void PlayVoiceGreeting(string path)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(path))
                {
                    player.PlaySync(); //Waits for the audio to finish before moving on
                }
            }
            catch (Exception ex)
            {
                //If something goes wrong it shows an error
                Console.WriteLine($"Could not play audio greeting: {ex.Message}");
            }
        }

        //Method displays an ASCII image – adds some fun visuals to the console
        static void ShowAsciiArt(string path)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                string art = File.ReadAllText(path); // Read the whole file as a string
                Console.WriteLine(art);              // Print it out
                Console.ResetColor();
            }
            catch
            {
                //If the file isn’t found, it does not crash it just tells the user
                Console.WriteLine("ASCII art file not found.");
            }
        }

        //This method types out text character by character to mimic a typing effect
        static void PrintWithTypingEffect(string text, int delay = 25)
        {
            foreach (char c in text)
            {
                Console.Write(c);       //Shows one letter at a time
                Thread.Sleep(delay);    //Pauses briefly to create that typewriter feel
            }
            Console.WriteLine();        //Goes to the next line
        }
    }
}
