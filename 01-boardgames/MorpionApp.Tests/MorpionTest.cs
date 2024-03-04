using Xunit;

namespace MorpionApp.Tests
{
    public class MorpionTest
    {
        private Morpion morpion;
        private char symbol;

        public MorpionTest()
        {
            morpion = new Morpion();
            symbol = 'X'; // Either 'X' or 'O' for the tests
        }

        private void SetUp(char[,] grille)
        {
            morpion.grille = grille;
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireRows()
        {
            for (int i = 0; i < 3; i++)
            {
                char[,] grille = new char[3, 3];
                grille[i, 0] = symbol;
                grille[i, 1] = symbol;
                grille[i, 2] = symbol;
                SetUp(grille);
                Assert.True(morpion.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la ligne {i}");
            }
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                char[,] grille = new char[3, 3];
                grille[0, i] = symbol;
                grille[1, i] = symbol;
                grille[2, i] = symbol;
                SetUp(grille);
                Assert.True(morpion.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la colonne {i}");
            }
        }

        [Fact]
        [Trait("Category", "VictoryTests")]
        public void TestVerifVictoireDiagonals()
        {
            char[,] grille = new char[3, 3];
            grille[0, 0] = symbol;
            grille[1, 1] = symbol;
            grille[2, 2] = symbol;
            SetUp(grille);
            Assert.True(morpion.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la diagonale principale");

            grille = new char[3, 3];
            grille[0, 2] = symbol;
            grille[1, 1] = symbol;
            grille[2, 0] = symbol;
            SetUp(grille);
            Assert.True(morpion.verifVictoire(symbol), $"La vérification de la victoire a échoué pour le symbole {symbol} à la diagonale secondaire");
        }

        [Fact]
        [Trait("Category", "EqualityTests")]
        public void TestVerifEgalite()
        {
            char[,] grille = {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'O', 'X', 'O' }
            };
            SetUp(grille);
            Assert.True(morpion.verifEgalite(), "La vérification de l'égalité a échoué alors que la grille est complète");

            grille = new char[,] {
                { 'X', 'O', ' ' },
                { 'X', 'X', 'O' },
                { 'O', 'X', 'O' }
            };
            SetUp(grille);
            Assert.False(morpion.verifEgalite(), "La vérification de l'égalité a réussi alors que la grille n'est pas complète");
        }
    }
}
