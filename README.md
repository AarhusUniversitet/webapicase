# Case - .NET applikation

I denne case vil vi gerne have dig til at kigge nærmere på en .NET-applikation, som indeholder et simpelt API, og gøre dig nogle overvejelser om, hvad der kunne forbedres i koden.

Koden indeholder en solution-fil, som du kan åbne i Visual Studio, VS Code eller lignende. Du kan også vælge at afvikle koden i en terminal med `dotnet run` – det eneste krav er, at du har .NET 10.0 SDK installeret på din computer: https://dotnet.microsoft.com/en-us/download

Når du starter projektet, vil der åbne en browser, hvor du kan navigere til `http://localhost:<PORT>/swagger`, hvor du vil se et Swagger-interface.

Applikationen indeholder to GET-endpoints (`/api/Products` og `/api/Products/{id}`), som begge læser indhold fra en database. Du kan afprøve dem begge via Swagger.

## Opgave

Kig koden igennem og gør dig nogle overvejelser om følgende:

- Ser du nogle potentielle sikkerhedshuller, og hvordan vil du udbedre dem?
- Hvilke ændringer vil du foretage i forhold til struktur, forretningslogik og lignende, så applikationen bliver lettere at vedligeholde og teste?
- Hvordan kunne en alternativ løsning til databasetilgang (læse/skrive) se ud?

Du må gerne foretage koderettelser, men det er ikke et krav. Til samtalen vil vi snakke om, hvad du har fundet frem til – der er ikke én korrekt løsning, det vigtige er, at du har gjort dig nogle tanker om ovenstående.

### Hvis du er på helt bar bund:

- API-kaldene er defineret i ```ProductsController.cs```
- ```IProductManager.cs``` er ikke i brug - men det kunne den måske komme?

