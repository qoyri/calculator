# Calculatrice WPF

Cette application est une calculatrice basique développée avec WPF (.NET Framework).

## Fonctionnalités

- Addition, soustraction, multiplication et division
- Fonctionnement CLR pour la remise à zéro de l’écran
- Boutons de fermeture et de minimisation de l’application

## Technologies utilisées

- .NET Framework
- WPF
- MVVM (Model-View-ViewModel)

## Comment utiliser

Lancer `calculator.sln` dans Visual Studio ou JetBrains Rider. Construisez et exécutez l'application.

## Structure du projet

- `MainWindow.xaml`: le code de l'interface graphique de la calculatrice.
- `MainWindow.xaml.cs` : la logique derrière les interactions de l'interface graphique.
- `MainWindowViewModel.cs` : le ViewModel de la fenêtre principale, qui contrôle la logique de la calculatrice.
- `RelayCommand.cs` : une implementation de l'interface ICommand pour exécuter les commandes à partir de l'interface graphique.

## Contribution

Pour contribuer à ce projet, vous pouvez cloner le dépôt et soumettre une pull request.

Note: Ce projet a été créé pour des démonstrations et des fins d'apprentissage et n'est pas destiné à un usage commercial.