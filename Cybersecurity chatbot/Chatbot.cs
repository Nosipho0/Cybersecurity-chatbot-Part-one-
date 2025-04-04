using System;
using System.Collections;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private static readonly List<string> keywords = new List<string>();
        private static readonly List<string> replies = new List<string>();

        public Chatbot()
        {
            InitializeRepliesAndKeywords();
            ShowWelcomeBanner();

            string userName;

            do
            {
                Console.Write("Please enter your name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    ShowErrorMessage("Please enter a valid name.");
                }
            } while (string.IsNullOrWhiteSpace(userName));

            ShowInfoMessage($"Hello, {userName}! Welcome to the Cybersecurity Chatbot!");
            StartChat();
            ShowGoodbyeMessage();
        }

        private void StartChat()
        {
            string userInput;
            do
            {
                ShowChatPrompt();
                userInput = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ShowErrorMessage("Please enter a valid question.");
                }
                else if (userInput == "exit")
                {
                    break;
                }
                else
                {
                    ProcessUserInput(userInput);
                }
            } while (true);
        }

        private static void InitializeRepliesAndKeywords()
        {
            replies.Add("Password should be strong and unique. Use a mix of letters, numbers, and symbols.");
            replies.Add("Phishing emails often ask for sensitive information. Always verify the sender.");
            replies.Add("Attacking phones often involves phishing.");
            replies.Add("Safe browsing includes avoiding suspicious links and ensuring websites use HTTPS.");
            replies.Add("Install antivirus software and keep it updated to protect against malware.");
            replies.Add("My purpose is to help you stay safe online.");

            keywords.Add("password");
            keywords.Add("phishing");
            keywords.Add("phone");
            keywords.Add("safe browsing");
            keywords.Add("malware");
            keywords.Add("what is your purpose");
        }

        private void ProcessUserInput(string userInput)
        {
            string[] words = userInput.Split(new char[] { ' ', ',', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            bool found = false;

            for (int i = 0; i < keywords.Count; i++)
            {
                foreach (string word in words)
                {
                    if (string.Equals(word, keywords[i], StringComparison.OrdinalIgnoreCase))
                    {
                        ShowInfoMessage(replies[i]);
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                ShowInfoMessage("I'm not sure how to answer that. Try asking about cybersecurity, AI, or general knowledge.");
            }
        }

        private static void ShowWelcomeBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("      WELCOME TO THE CYBERSECURITY CHATBOT       ");
            Console.WriteLine("==========================================");
            Console.ResetColor();
        }

        private static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {message}");
            Console.ResetColor();
        }

        private static void ShowInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ShowChatPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ask me something (or type 'exit' to quit): ");
            Console.ResetColor();
        }

        private static void ShowGoodbyeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Goodbye! Stay safe and take care.");
            Console.ResetColor();
        }
    }
}
