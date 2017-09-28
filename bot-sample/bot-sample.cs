using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace bot_test
{
class Program
    {
        static void Main(string[] args)
        {
            bool b_input;
            bool get_latest=false;
            string requested_version="";
            string message;
            int message_length;
            
            if (args.Length == 0) 
            {
                get_latest=true;
                Console.WriteLine("Getting the latest release version of .NET Core and the SDK");
                Console.WriteLine("Enter a .NET Core version number if you need specific release information.");
            }
            else
            {
                b_input = true;
                requested_version = String.Join(" ",args);
            }

            //setting get_latest to true for initial default
            //get_latest=true;

            message =               " ______________________________________________________\n";
            message_length = message.Length;
            message = message + "\n | Welcome to .NET Core!                                |";
            
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/dotnet/core/master/release-notes/releases.json", @"releases.json");
            string filename = "releases.json";
            
            var serializer = new JsonSerializer();
            //Release[] release = JsonConvert.DeserializeObject<Release[]>(File.ReadAllText(@filename));

            //JArray experiment
            using (StreamReader reader = File.OpenText(@filename))
            {
                JArray release = (JArray)JToken.ReadFrom(new JsonTextReader(reader));
            }
            
                

            if (get_latest==true)
            {
                message = message + "\n | Here are the latest versions available for download: |";
                //string m_runtime_version = "\n | .NET Core - " + GetLatestRuntime(release);
                //string m_sdk_version = "\n | .NET Core SDK - " + GetLatestRuntime(release);
                //message = message + m_runtime_version.PadRight(message_length + 2,' ') + "|";
                //message = message + m_sdk_version.PadRight(message_length + 2,' ') + "|";
            }
            else
            {
                //parse and test version arg
                Console.WriteLine("Requesting version: " + requested_version);
                //query release for the value
                //return the entire section for now
            }
            
            //Console.WriteLine(GetBot(message));
            //
            // for (int i = 0; i < release.Length; i++)
            // {
            //    Console.WriteLine(release[i].Version_Runtime);
            //    Console.WriteLine(release[i].Version_SDK);
            // }
        }
        
        public static string GetLatestRuntime(JArray re)
        {
            string m_runtime = "";
            return m_runtime;
        }

        public static string GetLatestSDK(JArray re)
        {
            string m_sdk = "";
            return m_sdk;
        }

        public static string GetRuntime(JArray re, string ver)
        {
            string m_runtime = "";
            return m_runtime;
        }

        public static string GetSDK(JArray re, string ver)
        {
            string m_sdk = "";
            return m_sdk;
        }
        public static string GetBot(string message) 
            {
                string bot = $"\n {message}";
                bot += @"
  ______________________________________________________
                                      \
                                       \
                                          ....
                                          ....'
                                           ....
                                        ..........
                                    .............'..'..
                                 ................'..'.....
                               .......'..........'..'..'....
                              ........'..........'..'..'.....
                             .'....'..'..........'..'.......'.
                             .'..................'...   ......
                             .  ......'.........         .....
                             .                           ......
                            ..    .            ..        ......
                           ....       .                 .......
                           ......  .......          ............
                            ................  ......................
                            ........................'................
                           ......................'..'......    .......
                        .........................'..'.....       .......
                     ........    ..'.............'..'....      ..........
                   ..'..'...      ...............'.......      ..........
                  ...'......     ...... ..........  ......         .......
                 ...........   .......              ........        ......
                .......        '...'.'.              '.'.'.'         ....
                .......       .....'..               ..'.....
                   ..       ..........               ..'........
                          ............               ..............
                         .............               '..............
                        ...........'..              .'.'............
                       ...............              .'.'.............
                      .............'..               ..'..'...........
                      ...............                 .'..............
                       .........                        ..............
                        .....

                ";
                return bot;
            }
    }

    public class Release
    {
        public string Latest_Version_Runtime {get; set;}
        public string Latest_Version_SDK {get; set;}
        public string Version_Runtime {get; set;}
        public string Version_SDK {get; set;}
        public DateTime Date {get; set;}
        public Boolean Security {get; set;}
        public Boolean LTS_Runtime {get; set;}
        public Boolean LTS_SDK {get; set;}
        public string DLC_Runtime {get; set;}
        public string DLC_SDK {get; set;}
        public string Blob_Runtime {get; set;}
        public string Blob_SDK {get; set;}
        public string Runtime_Linux_x64 {get; set;}
        public string Runtime_Linux_x64_Checksum {get; set;}
        public string Runtime_OSX_x64 {get; set;}
        public string Runtime_OSX_x64_Checksum {get; set;}
        public string Runtime_Win_x64 {get; set;}
        public string Runtime_Win_x64_Checksum {get; set;}
        public string Runtime_Win_x86 {get; set;}
        public string Runtime_Win_x86_Checksum {get; set;}
        public string SDK_Linux_x64 {get; set;}
        public string SDK_Linux_x64_checksum {get; set;}
        public string SDK_OSX_x64 {get; set;}
        public string SDK_OSX_x64_Checksum {get; set;}
        public string SDK_Win_x86 {get; set;}
        public string SDK_Win_x86_Checksum {get; set;}
        public string SDK_Win_x64 {get; set;}
        public string SDK_Win_x64_Checksum {get; set;}
        public string Checksums_Runtime {get; set;}
        public string Checksums_SDK {get; set;}
   }
}
