namespace MorpionApp.Tests
{
    public class PuissanceQuatreTest
    {  
        [Fact]
        public void TestVerifVictoire()
        {
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

            puissanceQuatre.grille = new char[4, 7]
            {
                { 'O', 'O', 'O', 'O', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };

            bool victoire = puissanceQuatre.verifVictoire('O');

            Assert.True(victoire);
        }

        [Fact]
        public void TestVerifEgalite()
        {
            // Arrange
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
            char[,] grille = {
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X' }
            };
            puissanceQuatre.grille = grille;

            // Act
            bool result = puissanceQuatre.verifEgalite();

            // Assert
            Assert.True(result); // Assuming the provided grid leads to a tie
        }
    }
}
