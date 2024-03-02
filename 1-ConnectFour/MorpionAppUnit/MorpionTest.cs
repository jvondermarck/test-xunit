namespace MorpionAppUnit;
using MorpionApp;

public class MorpionTest
{
        [Fact]
        public void TestTourJoueur()
        {
            // Créez une instance de Morpion
            Morpion morpion = new Morpion();

            // Appelez la méthode tourJoueur
            morpion.tourJoueur();

            // Ajoutez des assertions pour vérifier le comportement attendu
            Assert.True(morpion.grille[0, 0] == 'X');
        }

        [Fact]
        public void TestVerifVictoire()
        {
            // Créez une instance de Morpion
            Morpion morpion = new Morpion();

            // Modifiez la grille pour simuler une victoire
            morpion.grille = new char[3, 3]
            {
                { 'X', 'X', 'X' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Appelez la méthode verifVictoire
            bool victoire = morpion.verifVictoire('X');

            // Ajoutez une assertion pour vérifier que la victoire a été détectée
            Assert.True(victoire);
        }
}
