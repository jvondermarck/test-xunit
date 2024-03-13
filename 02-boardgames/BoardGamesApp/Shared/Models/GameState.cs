namespace BoardGamesApp;

[Serializable]
public class GameState
{
    public List<char> BoardState { get; set; } = new List<char>();
    public int Rows { get; set; } = 0;
    public int Columns { get; set; } = 0;
    public int TargetCount { get; set; } = 0;
    public string CurrentPlayer { get; set; } = "";
    public char CurrentPlayerSymbol { get; set; }
    public string Player1Type { get; set; } = "";
    public string Player2Type { get; set; } = "";
    public string Player1Symbol { get; set; } = "";
    public string Player2Symbol { get; set; } = "";
    public string EvaluatorType { get; set; } = "";
}