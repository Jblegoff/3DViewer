# 3DViewer

## Conception d'un viewer 3D simple utilisant un assetBundle

Pour réaliser ce projet j'ai utilisé le pack d'asset food fourni gratuietement par UnityTechnologies pour avoir une petite collection d'objet ( 7 au total).
Une fois les objets importés, on les ajoute à l'asset tag "food" et on compile tout les objet avec ce tag en assetbundle( ici pour WebGL).

On télécharge l'asset bundle depuis le serveur( ici firebase storage ) en ayant configuré correctement les règles de Cross Origin. 

Une fois téléchargé on charge l'asset bundle:
* on récupère le nombre d'élément de l'asset bundle. 
* on crée un tableau de la taille correspondante. 

On affiche le premier élément du tableau une fois chargé et on incrémente ou décrémente l'index du tableau en appuyant sur les touches flèches droite ou gauche respectivement.

Le projet étant déjà sur firebase il est déployé et accessible ici: https://dviewer-59182.web.app/
