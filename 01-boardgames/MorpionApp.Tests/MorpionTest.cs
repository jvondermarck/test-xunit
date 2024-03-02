namespace MorpionApp.Tests
{
    public class MorpionTest
    {  
        [Fact]
        public void TestVerifVictoire()
        {
            // Arrange
            Morpion morpion = new Morpion();
            char symbol = 'X';
            bool expectedResult = true;

            char[,] grille = {
                { symbol, ' ', ' ' },
                { symbol, ' ', ' ' },
                { symbol, ' ', ' ' }
            };
            
            morpion.grille = grille;

            // Act
            bool result = morpion.verifVictoire(symbol);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestVerifEgalite()
        {
            // Arrange
            Morpion morpion = new Morpion();
            char[,] grille = {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'O', 'X', 'O' }
            };
            morpion.grille = grille;

            // Act
            bool result = morpion.verifEgalite();

            // Assert
            Assert.True(result);
        }
    }
}
