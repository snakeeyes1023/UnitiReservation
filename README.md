# API

## Procédure d'installation

1. Installer Visual Studio 2022 pour avoir asp.net core 6.0
2. Configurer le fichier APPSETTINGS.JSON avec les informations de la base de données


## Base de données

La base de données est gérée par MongoDB. Il faut donc installer MongoDB sur votre machine.

### Table User

Regroupe les informations de l'utilisateur avec c'est information d'authentification.

![image](dev/images/TableUser.png)

### Table Unit

Regroupe les informations d'un local. (Inclus les réservations)

![image](dev/images/TableUnit.png)

### Table RequestLogs

Regroupe tous les requêtes effectuées sur l'application.

![image](dev/images/TableRequestLogs.png)


#### Importer les données

##### Collection Users

1. Créer une collection nommée "Users" dans la base de données
2. Importer le fichier "dev/Units.json" dans la collection "Users"

##### Collection Units

1. Créer une collection nommée "Units" dans la base de données
2. Importer le fichier "dev/Units.json" dans la collection "Units"

## MongoDB
- user : jcote
- password : wmaFW5Gh4GCuhKhP


## Déploiement

URL : https://api.mesloc.com/swagger/index.html
