# I Les difficultés liées à la validation

## Listez les éléments du logiciel qui sont des freins à la validation du logiciel dans son état actuel.

Les éléments du logiciel que dans la plupart des méthodes de validations sont des freins sont les suivants :
	- Des boucles dans des boucles et dans des conditions
	- Les nombreuses conditions et switchs qui contiennent souvent plusieurs boucles dans chaque cas du switch, ce qui rend le code difficile à lire et à comprendre car il y a beaucoup de cas différent à gérer et donc à tester...
	- La taille de plusieurs méthodes sont très longues donc il est difficile de les tester entièrement et de couvrir tous les cas possibles.

## A l’aide d’exemples issus du code, expliquez les soucis posés par les choix de design qui ont été effectués par le prestataire.
- Les méthodes sont très longues et contiennent beaucoup de conditions et de boucles imbriquées.
- Il y a des méthodes très similaires qui se répètent dans la classe Morpion et PuissanceQuatre, il manque de la généralisation, par exemple dans la classe PuissanceQuatre, la méthode `tourJoueur` et `tourJoueur2` sont exactement les mêmes, sauf une logique qui change, donc il y a 70 lignes de codes fois deux vu que c'est dupliqué. Il a un gros manque de modularité et de généralisation. Il faudrait créer une classe de base commune pour gérer la logique du jeu, en évitant la duplication de code.

# II. Les méthodes de résolution de ces problèmes

## Expliquez les actions à mettre en place pour valider l’existant, et le cas échéant, pour corriger les bugs éventuels.
- Refactoring : eliminer tout les bouts de code redondants pour utiliser des méthodes distinctes / générique pour améliorer la lisibilité et la maintenabilité du code.
- Tests unitaires : pour valider le bon fonctionnement des méthodes et des classes, il faudrait écrire des tests unitaires pour chaque méthode et classe. Néanmois, il est extrement compliqué de tester les méthodes qui contiennent des boucles imbriquées et des conditions multiples, donc seulement les méthodes les plus simples pourront être testées. 

# III. Le développement des fonctionnalités manquantes

## Expliquez comment vous souhaitez procéder pour « brancher » un joueur contrôlé par l’ordinateur ainsi qu’un système permettant l’historisation et la persistance.
- Pour implémenter ces nouvelles features, il faut d'abord refactoriser le code pour le rendre plus modulaire et générique. Ensuite, il faudra créer une nouvelle classe qui gère la logique du jeu, et qui permettra de brancher un joueur contrôlé par l'ordinateur. Enfin, il faudra créer une classe qui permettra l'historisation et la persistance des données.

> Gardez bien en tête que les parties prenantes ont énormément insisté sur la nécessité de process de qualité robuste. Cette nouvelle fonctionnalité doit donc être testée