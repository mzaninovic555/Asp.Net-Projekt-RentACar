# Asp.Net-Projekt-RentACar

Završni projekt za TVZ kolegij "Razvoj web aplikacija u ASP.NET MVC tehnologiji".

# Migracijske skripte
Stvaranje nove skripte:
- dotnet ef migrations add imeSkripte --startup-project ..\RentACar --context RentACarDbContext

Ažuriranje baze sa novim skriptama
- dotnet ef database update --startup-project ..\RentACar --context RentACarDbContext

#Dodati role u tablicu
- admin - Admin - ADMIIN
- user - User - USER
