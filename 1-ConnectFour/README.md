# I Les difficult�s li�es � la validation

## Listez les �l�ments du logiciel qui sont des freins � la validation du logiciel dans son �tat actuel.

Les �l�ments du logiciel que dans la plupart des m�thodes de validations sont des freins sont les suivants :
	- Des boucles dans des boucles et dans des conditions
	- Les nombreuses conditions et switchs qui contiennent souvent plusieurs boucles dans chaque cas du switch, ce qui rend le code difficile � lire et � comprendre car il y a beaucoup de cas diff�rent � g�rer et donc � tester...
	- La taille de plusieurs m�thodes sont tr�s longues donc il est difficile de les tester enti�rement et de couvrir tous les cas possibles.

## A l�aide d�exemples issus du code, expliquez les soucis pos�s par les choix de design qui ont �t� effectu�s par le prestataire.
- Les m�thodes sont tr�s longues et contiennent beaucoup de conditions et de boucles imbriqu�es.
- Il y a des m�thodes tr�s similaires qui se r�p�tent dans la classe Morpion et PuissanceQuatre, il manque de la g�n�ralisation, par exemple dans la classe PuissanceQuatre, la m�thode `tourJoueur` et `tourJoueur2` sont exactement les m�mes, sauf une logique qui change, donc il y a 70 lignes de codes fois deux vu que c'est dupliqu�.

# II Les m�thodes de r�solution de ces probl�mes

## Expliquez les actions � mettre en place pour valider l�existant, et le cas �ch�ant, pour corriger les bugs �ventuels.

# III Le d�veloppement des fonctionnalit�s manquantes

1. Expliquez comment vous souhaitez proc�der pour � brancher � un joueur contr�l� par l�ordinateur ainsi qu�un syst�me permettant l�historisation et la persistance.
2. Gardez bien en t�te que les parties prenantes ont �norm�ment insist� sur la n�cessit� de process de qualit� robuste. Cette nouvelle fonctionnalit� doit donc �tre test�e