namespace BoardGamesApp;

public class TicTacToeHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; }

    public TicTacToeHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            ConsoleHandler.WriteLine($"Joueur {(Symbol == PlayerSymbol.X ? 1 : 2)}, c'est à vous (symbole {Symbol}):");

            int position = ConsoleHandler.ReadIntInRange(1, 9);

            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board.IsCellEmpty(row, col))
            {
                board.SetCell(row, col, Symbol);
                return;
            }
            else
            {
                ConsoleHandler.WriteLine("La case est déjà occupée. Veuillez réessayer.");
            }
        } while (true);
    }
}
