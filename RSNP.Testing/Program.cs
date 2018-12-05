using RSNP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RSNP.Testing {
    public class Program {
        public static void Main(string[] args) {
            new Program().Start().Wait().Dispose();
        }

        private bool Running = false;

        public Program Start() {
            LogManager.RegisterLogger(new Logger());
            Running = true;
            return this;
        }

        public class Logger : ILogger {
            public void Debug(Type type, object message) {
                ConsoleLogger.Log(LogLevel.Debug, $"[{type.FullName}] {message}");
            }

            public void Debug(Type type, object message, Exception exception) {
                ConsoleLogger.Log(LogLevel.Debug, $"[{type.FullName}] {message}", exception);
            }

            public void Debug(Type type, Exception exception) {
                ConsoleLogger.Log(LogLevel.Debug, exception);
            }

            public void Error(Type type, object message) {
                ConsoleLogger.Log(LogLevel.Error, $"[{type.FullName}] {message}");
            }

            public void Error(Type type, object message, Exception exception) {
                ConsoleLogger.Log(LogLevel.Error, $"[{type.FullName}] {message}", exception);
            }

            public void Error(Type type, Exception exception) {
                ConsoleLogger.Log(LogLevel.Error, exception);
            }

            public void Fatal(Type type, object message) {
                ConsoleLogger.Log(LogLevel.Fatal, $"[{type.FullName}] {message}");
            }

            public void Fatal(Type type, object message, Exception exception) {
                ConsoleLogger.Log(LogLevel.Fatal, $"[{type.FullName}] {message}", exception);
            }

            public void Fatal(Type type, Exception exception) {
                ConsoleLogger.Log(LogLevel.Fatal, exception);
            }

            public void Info(Type type, object message) {
                ConsoleLogger.Log(LogLevel.Info, $"[{type.FullName}] {message}");
            }

            public void Info(Type type, object message, Exception exception) {
                ConsoleLogger.Log(LogLevel.Info, $"[{type.FullName}] {message}", exception);
            }

            public void Info(Type type, Exception exception) {
                ConsoleLogger.Log(LogLevel.Info, exception);
            }

            public void Warn(Type type, object message) {
                ConsoleLogger.Log(LogLevel.Warn, $"[{type.FullName}] {message}");
            }

            public void Warn(Type type, object message, Exception exception) {
                ConsoleLogger.Log(LogLevel.Warn, $"[{type.FullName}] {message}", exception);
            }

            public void Warn(Type type, Exception exception) {
                ConsoleLogger.Log(LogLevel.Warn, exception);
            }
        }

        public Program Wait() {
            while(Running) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(">");
                Console.ForegroundColor = ConsoleColor.White;
                string rawCommand = Console.ReadLine();
                List<string> args = rawCommand.Split(' ').ToList();
                string cmd = args[0];
                args.RemoveAt(0);
                switch(cmd.ToLower()) {
                    case "connect":
                        if(args.Count == 2) {
                            IPAddress temp1;
                            int temp2;
                            if (IPAddress.TryParse(args[0], out temp1) && int.TryParse(args[1], out temp2) && temp2 > 0) {
                                RSNPClient client = new RSNPClient();
                                client.OnConnect += this.Client_OnConnect;
                                client.ConnectTask(new IPEndPoint(temp1, temp2));
                            } else {
                                ConsoleLogger.Log(LogLevel.Error, $"  [IP] must be a valid IP!");
                                ConsoleLogger.Log(LogLevel.Error, $"[Port] must be a valid Number(1-65535)!");
                            }
                        } else {
                            ConsoleLogger.Log(LogLevel.Info, $"How to Use:");
                            ConsoleLogger.Log(LogLevel.Info, $"connect [IP] [Port]");
                        }
                        break;
                    case "host":
                        if (args.Count == 5) {

                        } else {
                            ConsoleLogger.Log(LogLevel.Info, $"How to Use:");
                            ConsoleLogger.Log(LogLevel.Info, $"host [IP] [Port]");
                        }
                        break;
                    case "exit":
                        Running = false;
                        ConsoleLogger.Log(LogLevel.Info, $"Exiting...");
                        break;
                    default:
                        ConsoleLogger.Log(LogLevel.Warn, $"The command '{cmd}' can not be found.");
                        break;
                }
            }
            return this;
        }

        private void Client_OnConnect(object sender, bool connected) {
            ConsoleLogger.Log(LogLevel.Info, $"Connected with socket? {connected}");
        }

        public void Dispose() {
            Running = false;
        }
    }
}
