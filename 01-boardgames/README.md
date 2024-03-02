# I Les difficult�s li�es � la validation

## Listez les �l�ments du logiciel qui sont des freins � la validation du logiciel dans son �tat actuel.

Les �l�ments du logiciel que dans la plupart des m�thodes de validations sont des freins sont les suivants :
	- Des boucles dans des boucles et dans des conditions
	- Les nombreuses conditions et switchs qui contiennent souvent plusieurs boucles dans chaque cas du switch, ce qui rend le code difficile � lire et � comprendre car il y a beaucoup de cas diff�rent � g�rer et donc � tester...
	- La taille de plusieurs m�thodes sont tr�s longues donc il est difficile de les tester enti�rement et de couvrir tous les cas possibles.

## A l�aide d�exemples issus du code, expliquez les soucis pos�s par les choix de design qui ont �t� effectu�s par le prestataire.
- Les m�thodes sont tr�s longues et contiennent beaucoup de conditions et de boucles imbriqu�es.
- Il y a des m�thodes tr�s similaires qui se r�p�tent dans la classe Morpion et PuissanceQuatre, il manque de la g�n�ralisation, par exemple dans la classe PuissanceQuatre, la m�thode `tourJoueur` et `tourJoueur2` sont exactement les m�mes, sauf une logique qui change, donc il y a 70 lignes de codes fois deux vu que c'est dupliqu�. Il a un gros manque de modularit� et de g�n�ralisation. Il faudrait cr�er une classe de base commune pour g�rer la logique du jeu, en �vitant la duplication de code.

# II. Les m�thodes de r�solution de ces probl�mes

## Expliquez les actions � mettre en place pour valider l�existant, et le cas �ch�ant, pour corriger les bugs �ventuels.
- Refactoring : eliminer tout les bouts de code redondants pour utiliser des m�thodes distinctes / g�n�rique pour am�liorer la lisibilit� et la maintenabilit� du code.
- Tests unitaires : pour valider le bon fonctionnement des m�thodes et des classes, il faudrait �crire des tests unitaires pour chaque m�thode et classe. N�anmois, il est extrement compliqu� de tester les m�thodes qui contiennent des boucles imbriqu�es et des conditions multiples, donc seulement les m�thodes les plus simples pourront �tre test�es. 

# III. Le d�veloppement des fonctionnalit�s manquantes

## Expliquez comment vous souhaitez proc�der pour � brancher � un joueur contr�l� par l�ordinateur ainsi qu�un syst�me permettant l�historisation et la persistance.
- Pour impl�menter ces nouvelles features, il faut d'abord refactoriser le code pour le rendre plus modulaire et g�n�rique. Ensuite, il faudra cr�er une nouvelle classe qui g�re la logique du jeu, et qui permettra de brancher un joueur contr�l� par l'ordinateur. Enfin, il faudra cr�er une classe qui permettra l'historisation et la persistance des donn�es.

> Gardez bien en t�te que les parties prenantes ont �norm�ment insist� sur la n�cessit� de process de qualit� robuste. Cette nouvelle fonctionnalit� doit donc �tre test�e