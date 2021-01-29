# Online_razmjena
Upute:
Pošto mi koristimo lokalnu bazu podataka trebaju se napraviti male izmjene u kodu prije pokretanja.
1. U package manager console napraviti migracije sa funkcijama Add-Migration i nakon toga Update-Database
2. Idete na Areas/Identity/Pages/Account/Register.cshtml/Register.cshtml.cs u njemu zakomentiramo liniju 81
3. Controllers/RoleController.cs  zakomentiramo liniju 14
4. U aplikaciji napravimo korisnika i nakon toga u url-u idemo na /role
5. Napravimo dvije uloge "Korisnik" i "Admin"
6. Dodamo sebi ulogu Admin.
7. Nakon toga možemo odkomentirati korak 2. i 3.
