using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace UsefulMethods
{
    public class InputCreator
    {
        /// <summary>
        /// Gets input for Advent of Code puzzles
        /// </summary>
        /// <param name="day">Indicates number of wanted input</param>
        /// <returns>String variable with inputs</returns>
        ///
        public static async Task<string> GetPuzzleInput(int day)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<InputCreator>().Build();
            string sessionKey = config["sessionKey"];
            if (!string.IsNullOrEmpty(sessionKey))
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Cookie", $"session={sessionKey}");
                var response = await client.GetAsync($"https://adventofcode.com/2022/day/{day}/input");
                var input = await response.Content.ReadAsStringAsync();

                return input;
            }

            return string.Empty;
        }
        public static IEnumerable<string> GetLines(string input, bool cutEmptyLines = true)
        {
            var lines = input.Split(new string[] { "\n" }, StringSplitOptions.None);
            return cutEmptyLines ? lines.Where(line => !string.IsNullOrEmpty(line)) : lines;
        }


    }


}