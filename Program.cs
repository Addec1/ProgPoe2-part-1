using System;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();  // Plays greeting with sound

            ShowAsciiLogo();

            Console.Write("Hi! What's your name? ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome, {name}! I'm your Cybersecurity Awareness Bot.");
            Console.ResetColor();

            RunChatBot();
        }

        static void PlayVoiceGreeting()
        {
            const string greetingText = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(greetingText);
            Console.ResetColor();

            string audioFilePath = "Greetings ProgPoe1.wav";

            try
            {
                using (var audioFile = new AudioFileReader(audioFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100); // Wait while playing
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Could not play 'Greetings ProgPoe1.wav'. Ensure the file exists and is set to 'Copy if newer'.");
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
 | )(_o/  \o_)( |
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
                { "how are you", "I'm just code, but I'm functioning as expected! Ready to help you with cybersecurity advice." },
                { "what's your purpose", "I'm here to help you understand and navigate cybersecurity topics like VPNs, phishing, firewalls, and more!" },
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
                Console.Write("\nAsk me a question about cybersecurity (or type 'exit' to leave): ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a valid question. Examples: VPN, Firewall, Botnet.");
                    Console.ResetColor();
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                string lowerInput = input.ToLower();

                if (responses.TryGetValue(lowerInput, out string answer))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(answer);
                    Console.ResetColor();
                }
                else if (lowerInput.Contains("how are you"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("I'm doing great, thanks for asking! I'm always here to talk cybersecurity.");
                    Console.ResetColor();
                }
                else if (lowerInput.Contains("what") && lowerInput.Contains("purpose"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("My purpose is to help you become more aware of cybersecurity threats and how to stay safe online.");
                    Console.ResetColor();
                }
                else if (lowerInput.Contains("what can i ask") || lowerInput.Contains("help") || lowerInput.Contains("topics"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You can ask me about VPNs, phishing, malware, ransomware, firewalls, botnets, and many more cybersecurity topics!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("I didn't quite get that, could you please rephrase?");
                    Console.ResetColor();
                }
            }
        }
    }
}