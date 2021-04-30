Le but de l'application est de fournir une API qui sera consommé à la fois par un site Web et une application console.
Vous devez créer l'architecture de solution suivante :
  - Libraire de classe contenant tout les éléments commun aux autres projet
  - Projet ASP API qui utilise la libraire de classe pour les éléments commun
  - Projet ASP MVC qui utilise la libraire de classe pour les éléments commun
  - Projet console qui utilise la libraire de classe pour les éléments commun


Le projet doit permettre de gérer les objets suivant :
  - Entreprise :
    - Numéro de siret
    - Nom
    - Adresse
  - TypeArticle :
    - Nom
    - Prix standard (prix moyen des articles vendu sur les 3 derniers mois)
    - Delai de livraison standard (delai de livraison moyen en jour recensé sur les 3 derniers mois)
    - Liste des articles en stock
    - Liste des articles vendu
  - Article :
    - Nom
    - Prix de vente
    - Date de commande
    - Date de livraison
    - Type d'article dont il est issu


Pour communiquer entre les différentes applications vous devez utiliser la librairie NuGet "Refit"
L'application ASP MVC doit représenter le magazin en ligne permettant d'acheter des articles :
  - On ne gérera pour l'instant qu'une seule entreprise
  - Vous devez afficher la liste des articles de l'entreprise
  - Pour un article donné dans son détail on affichera les informations :
    - Nombre d'élément
    - Delai de livraison standard
    - Prix de vente
    - Bouton d'achat
  - Lors de l'achat d'un article :
    - L'article doit être transféré dans la liste des articles vendu pour le type d'article au quel il est lié
    - Une date de livraison réel est créé (elle doit être aléatoire avec au délais minimum de un jour et maximum de 15 jours


L'application console doit permettre d'alimenter une entreprise en article et en type d'article :
  - Dans la console on demandera via des menus (1-2-3-...) les actions que l'utilisateur veut réaliser
  - On doit pouvoir sélectionner une entreprise pour y ajouter un nouveau type d'article
  - On doit pouvoir sélectionner une entreprise puis un type d'article pour rajouter des articles
    - On devra pouvoir sélectionner la quantité d'article à créer
  - Les données affichées dans la console doivent l'être au format JSON

L'application ASP API doit permettre de récupérer et gérer tout les éléments nécessaire aux autre applications
Un jeu de données initial doit être fourni à l'API afin de pouvoir manipuler les applications

Aucune authentification utilisateur est nécessaire pour la réalisation du TP