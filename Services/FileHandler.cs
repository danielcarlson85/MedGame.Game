using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public class FileHandler
    {
        public static async Task SavePlayerToFile(Player player, string fileName)
        {
            await Task.Run(() =>
            {
                try
                {
                    string json = JsonConvert.SerializeObject(player);
                    File.WriteAllText(fileName, json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not save player + {ex}");
                }
            });
        }

        public async static Task<Player> LoadPlayerFromFile(string fileName)
        {
            return await Task.Run(() =>
              {
                  try
                  {
                      string jsonPlayer = File.ReadAllText(fileName);
                      Player player = JsonConvert.DeserializeObject<Player>(jsonPlayer);

                      return player;
                  }
                  catch (Exception ex)
                  {
                      throw new Exception($"Could not load player {fileName} + {ex}");
                  }
              });
        }

        public static async Task<bool> RemoveUser(string fileName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    File.Delete(fileName);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not remove player {fileName} {ex}");
                }
            });
        }

        public static string GetFullFileNamePath(string fileName)
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot + fileName;
        }


    }

    public static class MyExtensions
    {
        public static string MakeFullFileName(this string file)
        {
            return $"{file}.json";
        }
    }
}