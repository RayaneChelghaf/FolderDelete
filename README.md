# Application de Suppression de Dossiers

## Description

Cette application en ligne de commande permet de supprimer des dossiers (et leurs contenus) créés depuis plus de **X jours** dans un répertoire distant ou local.

## Fonctionnalités

- Supprime les dossiers dont la date de création est supérieure à un nombre de jours spécifié.
- Prend en charge la suppression récursive des dossiers et de leur contenu.
- Affiche un message si aucun dossier à supprimer n'est trouvé pour la période indiquée.

## Prérequis

- **.NET SDK** installé.

## Installation et génération du .exe

Le fichier `.exe` n'est pas inclus dans ce dépôt. Pour générer l'exécutable, suivez ces étapes :

1. Clonez le dépôt sur votre machine locale.
2. Ouvrez la solution (`.sln`) avec Visual Studio.
3. Ouvrez le terminal dans Visual Studio (ou une invite de commandes) et exécutez la commande suivante depuis le répertoire racine du projet pour générer le fichier `.exe` :

```
dotnet publish -c Release -r win-x64 --self-contained
```

4. L'exécutable sera généré dans le dossier suivant :
   ```
   <répertoire_du_projet>\bin\Release\net6.0\win-x64\publish\
   ```

## Utilisation

### Commande pour exécuter l'application :
```
FolderDelete.exe <baseDir> <days>
```

- **`<baseDir>`** : Le répertoire de base dans lequel se trouvent les dossiers à supprimer.
- **`<days>`** : Le nombre de jours au-delà desquels les dossiers seront supprimés.

### Exemple :
Pour supprimer tous les dossiers créés il y a plus de 15 jours dans le répertoire `C:\Desktop\dépot\ModifyDate` :
```
FolderDelete.exe "C:\Desktop\dépot\ModifyDate" 15
```

### Comportement de l'application :
- Si des dossiers ont été créés il y a plus de 15 jours, ils seront supprimés avec tout leur contenu.
- Si aucun dossier ne correspond à cette période, un message informant qu'aucun dossier n'a été supprimé s'affichera.
- Si vous tentez de supprimer des dossiers créés le jour même (`days = 0`), un message d'erreur sera affiché.

## Gestion des erreurs

- **Nombre de jours invalide** : Si vous entrez un nombre de jours inférieur ou égal à 0, l'application renverra une erreur et ne procédera à aucune suppression.
- **Aucun dossier à supprimer** : Si aucun dossier ne correspond aux critères de suppression, un message l'indiquera.

## Exécution des tests unitaires

Les tests unitaires sont inclus dans le projet. Pour les exécuter, utilisez la commande suivante :
```
dotnet test
```

## Notes

- Cette application est conçue pour une utilisation sans interface graphique, uniquement via la ligne de commande.
