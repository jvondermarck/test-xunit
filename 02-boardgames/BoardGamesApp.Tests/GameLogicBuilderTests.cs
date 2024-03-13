namespace BoardGamesApp.Tests;

public class GameLogicBuilderTests
{
    [Fact]
    public void Build_ThrowsException_WhenPlayer1NotSet()
    {
        var builder = new GameLogicBuilder();
        
        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ThrowsException_WhenPlayer2NotSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>());

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ThrowsException_WhenEvaluatorNotSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>())
            .SetPlayer2(Mock.Of<IPlayer>());

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ThrowsException_WhenRowsNotSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>())
            .SetPlayer2(Mock.Of<IPlayer>())
            .SetEvaluator(_ => Mock.Of<IGameEvaluator>());

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ThrowsException_WhenColumnsNotSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>())
            .SetPlayer2(Mock.Of<IPlayer>())
            .SetEvaluator(_ => Mock.Of<IGameEvaluator>())
            .SetRows(3);

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ThrowsException_WhenTargetCountNotSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>())
            .SetPlayer2(Mock.Of<IPlayer>())
            .SetEvaluator(_ => Mock.Of<IGameEvaluator>())
            .SetRows(3)
            .SetColumns(3);

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void Build_ReturnsGameLogic_WhenAllParametersSet()
    {
        var builder = new GameLogicBuilder()
            .SetPlayer1(Mock.Of<IPlayer>())
            .SetPlayer2(Mock.Of<IPlayer>())
            .SetEvaluator(_ => Mock.Of<IGameEvaluator>())
            .SetRows(3)
            .SetColumns(3)
            .SetTargetCount(3);

        var gameLogic = builder.Build();

        Assert.NotNull(gameLogic);
    }
}