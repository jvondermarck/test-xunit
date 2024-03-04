namespace MorpionApp.Tests
{
    public class PuissanceQuatreTest
    {
        private PuissanceQuatre puissanceQuatre;
        private char symbol;

        public PuissanceQuatreTest()
        {
            puissanceQuatre = new PuissanceQuatre();
            symbol = 'X'; // Soit 'X' ou 'O' pour les tests
        }

        private void SetUp(char[,] grille)
        {
            puissanceQuatre.grille = grille;
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireRows()
        {
            for (int i = 0; i < 4; i++)
            {
                char[,] grille = new char[4, 7];
                for (int j = 0; j < 4; j++)
                {
                    grille[i, j] = symbol;
                }
                SetUp(grille);
                Assert.True(puissanceQuatre.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la ligne {i}");
            }
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireColumns()
        {
            for (int j = 0; j < 7; j++)
            {
                char[,] grille = new char[4, 7];
                for (int i = 0; i < 4; i++)
                {
                    grille[i, j] = symbol;
                }
                SetUp(grille);
                Assert.True(puissanceQuatre.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la colonne {j}");
            }
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireDiagonals()
        {
            char[,] grille = new char[4, 7];
            for (int i = 0; i < 4; i++)
            {
                grille[i, i] = symbol;
            }
            SetUp(grille);
            Assert.True(puissanceQuatre.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la diagonale principale");

            grille = new char[4, 7];
            for (int i = 0; i < 4; i++)
            {
                grille[i, 3 - i] = symbol;
            }
            SetUp(grille);
            Assert.True(puissanceQuatre.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la diagonale secondaire");
        }

    [Fact]
    [Trait("Category", "EqualityTests")]
    public void TestVerifEgalite()
    {
        // Arrange
        char[,] grille = new char[4, 7];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                grille[i, j] = 'X'; // Fill all cells
            }
        }
        SetUp(grille);

        // Act
        bool result = puissanceQuatre.verifEgalite();

        // Assert
        Assert.True(result, "La vérification de l'égalité a échoué alors que toutes les cellules sont remplies");
    }
    }
}
