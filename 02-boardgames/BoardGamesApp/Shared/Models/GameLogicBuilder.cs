namespace BoardGamesApp;

public class GameLogicBuilder
{
    private IPlayer? player1;
    private IPlayer? player2;
    private Func<GameBoard, IGameEvaluator>? evaluator;
    private int rows;
    private int columns;
    private int targetCount;

    public GameLogicBuilder SetPlayer1(IPlayer player1)
    {
        this.player1 = player1;
        return this;
    }

    public GameLogicBuilder SetPlayer2(IPlayer player2)
    {
        this.player2 = player2;
        return this;
    }

    public GameLogicBuilder SetEvaluator(Func<GameBoard, IGameEvaluator> evaluator)
    {
        this.evaluator = evaluator;
        return this;
    }

    public GameLogicBuilder SetRows(int rows)
    {
        this.rows = rows;
        return this;
    }

    public GameLogicBuilder SetColumns(int columns)
    {
        this.columns = columns;
        return this;
    }

    public GameLogicBuilder SetTargetCount(int targetCount)
    {
        this.targetCount = targetCount;
        return this;
    }

    public GameLogic Build()
    {
        Validate();

        return new GameLogic(player1!, player2!, rows, columns, targetCount, evaluator!);
    }

    private void Validate()
    {
        if (player1 == null || player2 == null)
        {
            throw new InvalidOperationException("Both players must be set before building the GameLogic object.");
        }

        if (evaluator == null)
        {
            throw new InvalidOperationException("Evaluator must be set before building the GameLogic object.");
        }

        if (rows <= 0 || columns <= 0)
        {
            throw new InvalidOperationException("Both rows and columns must be set before building the GameLogic object.");
        }

        if (targetCount <= 0)
        {
            throw new InvalidOperationException("Target count must be set before building the GameLogic object.");
        }
    }
}

