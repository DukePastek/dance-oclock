# Dance O'Clock

Site web de l'école de bachata Dance O'Clock (Kean Derr & Laura).

## Stack

- **Backend** : C# / ASP.NET Core 10 Web API (`Development/backend`), ouvert avec JetBrains Rider
- **Frontend** : Angular 22 (`Development/frontend/dance-oclock-web`), ouvert avec VS Code
- **Base de données** : PostgreSQL hébergé sur Supabase

## Configuration initiale

### Backend

1. Copier `Development/backend/src/DanceOClock.Api/appsettings.Development.json.example` vers `appsettings.Development.json` dans le même dossier (déjà ignoré par git).
2. Renseigner :
   - `ConnectionStrings:Default` avec la chaîne de connexion Postgres du projet Supabase (Project Settings > Database > Connection string, pooler de session recommandé).
   - `Jwt:SigningKey` avec une chaîne aléatoire d'au moins 32 caractères.
   - `AdminAccounts` avec les comptes de Kean et Laura (email + mot de passe temporaire, à changer ensuite).
3. Appliquer les migrations et lancer l'API :

   ```bash
   cd Development/backend/src/DanceOClock.Api
   dotnet run
   ```

   En environnement de développement, les migrations EF Core s'appliquent automatiquement au démarrage et les comptes admin sont créés s'ils n'existent pas encore.

### Frontend

```bash
cd Development/frontend/dance-oclock-web
npm install
npm start
```

Le site est accessible sur http://localhost:4200, l'API sur http://localhost:5000 (voir `src/environments/environment.development.ts`).

## Docker (optionnel)

```bash
cp Development/.env.example Development/.env
# renseigner SUPABASE_DB_CONNECTION_STRING et JWT_SIGNING_KEY dans Development/.env
cd Development
docker compose --env-file .env up --build
```

## État actuel

Fondations posées + fonctionnalité "Actus" complète (CRUD admin, page publique, flux RSS) pour valider l'architecture de bout en bout. Les autres fonctionnalités (Galerie, Cours + carte + formulaire de contact, pages Bachata/Qui sommes-nous, Settings) suivront le même patron.
