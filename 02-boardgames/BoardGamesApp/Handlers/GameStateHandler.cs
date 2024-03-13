using System.Text.Json;

namespace BoardGamesApp
{
    public static class GameStateHandler
    {
        private static string filePath = "savegame.json";
        public static GameState GameState = new GameState(); 

        public static void SaveGame()
        {
            string json = JsonSerializer.Serialize(GameState);
            File.WriteAllText(filePath, json);
        }

        public static void LoadGame()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                GameState = JsonSerializer.Deserialize<GameState>(json, options)!;
            }
            catch (Exception)
            {
                ConsoleHandler.WriteLine("No saved game found. Start a new game to be able to open a save.");
            }
        }
    }
}