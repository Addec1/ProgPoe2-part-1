﻿using System;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            ShowAsciiLogo();

            Console.Write("Hi! What's your name? ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText($"Welcome, {name}! I'm your Cybersecurity Awareness Bot.");
            Console.ResetColor();

            RunChatBot();
        }

        static void PlayVoiceGreeting()
        {
            const string greetingText = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(greetingText);
            Console.ResetColor();

            string audioFilePath = "Greetings ProgPoe1.wav";

            try
            {
                using (var audioFile = new AudioFileReader(audioFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    Thread.Sleep(200); 
                    outputDevice.Play();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }

                    outputDevice.Stop();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not play the audio. Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        static void ShowAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
      ______
   .-'      '-.
  /            \
 |              |
 |,  .-.  .-.  ,|
 | )(_0/  \0_)( |
 |/     /\     \|
 (_     ^^     _)
  \__|IIIIII|__/
   | \IIIIII/ |
   \          /
    `--------`               
");
            Console.ResetColor();
        }

        static void RunChatBot()
        {
            var responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "vpn", "A VPN (Virtual Private Network) encrypts your internet connection and hides your IP address, enhancing privacy online." },
                { "firewall", "A firewall is a network security device that monitors and filters incoming and outgoing network traffic." },
                { "botnet", "A botnet is a network of infected devices used by hackers to perform tasks like sending spam or launching attacks." },
                { "phishing", "Phishing is a type of cyber attack where attackers trick you into revealing personal information through fake emails or websites." },
                { "malware", "Malware is malicious software designed to harm, exploit, or otherwise compromise a computer or network." },
                { "ransomware", "Ransomware is a type of malware that encrypts your files and demands payment for the decryption key." },
                { "2fa", "2FA (Two-Factor Authentication) adds an extra layer of security by requiring a second form of verification after your password." },
                { "encryption", "Encryption is the process of converting information into code to prevent unauthorized access." },
                { "antivirus", "Antivirus software helps detect and remove malicious software to protect your devices from threats." },
                { "social engineering", "Social engineering is the use of psychological manipulation to trick people into giving up confidential information." },
                { "spyware", "Spyware is software that secretly gathers information from your device and sends it to a third party without your consent." },
                { "password manager", "A password manager is a tool that helps you generate, retrieve, and store complex passwords securely." },
                { "zero-day", "A zero-day vulnerability is a software flaw unknown to the vendor that hackers can exploit before it's patched." },
                { "patching", "Patching means applying updates to software to fix bugs or security vulnerabilities." },
                { "identity theft", "Identity theft is when someone steals your personal information to commit fraud or other crimes." },
                { "cyber hygiene", "Cyber hygiene refers to the practices and steps that users take to maintain system health and improve online security." },
                { "ddos", "A DDoS (Distributed Denial of Service) attack overwhelms a system with traffic, making it inaccessible to users." },
                { "breach", "A breach is an incident where sensitive, protected, or confidential data is accessed or disclosed without authorization." }
            };

            while (true)
            {
                Console.Write("\nAsk me a question about cybersecurity (type 'info' to see topics, or 'exit' to leave): ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeText("Please enter a valid question. Examples: VPN, Firewall, Botnet.");
                    Console.ResetColor();
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeText("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                if (input.Equals("info", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Here are the topics I can help with:");
                    foreach (var keyword in responses.Keys)
                    {
                        Console.WriteLine("- " + keyword);
                    }
                    Console.ResetColor();
                    continue;
                }

                string lowerInput = input.ToLower();

                if (lowerInput.Contains("how are you"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeText("I'm just code, but I'm functioning as expected! Ready to help you with cybersecurity advice.");
                    Console.ResetColor();
                }
                else if (lowerInput.Contains("what") && lowerInput.Contains("purpose"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeText("I'm here to help you understand and navigate cybersecurity topics like VPNs, phishing, firewalls, and more!");
                    Console.ResetColor();
                }
                else if (responses.TryGetValue(lowerInput, out string answer))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeText(answer);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeText("I didn't quite get that, could you please rephrase?");
                    Console.ResetColor();
                }
            }
        }

        static void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
    }
}
