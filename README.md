
# Metode i tehnike testiranja programske podrške - Projekt

## Sadržaj

- Opis projekta
- Korištene tehnologije i aplikacije
- Testni slučajevi

## 1. Opis projekta

Ovaj projekt je usmjeren na stvaranje funkcionalnog sustava za automatizirano testiranje web aplikacija. Testovi programske podrške napravljeni su korištenjem NUnit-a i Selenium WebDrivera u .NET okruženju. NUnit je okvir za testiranje koji omogućuje pisanje, izvršavanje i organizaciju testova u .NET-u, dok je Selenium alat za automatizaciju testiranja web aplikacija koji omogućuje kontrolu web preglednika radi pri testiranju.

## 2. Korištene tehnologije

### 2.1 Selenium 

Selenium je open-source alat koji se koristi za automatizaciju testiranja web aplikacija. Omogućuje programerima simuliranje korisničkih interakcija na web stranicama, poput klikanja, unošenja teksta i provjere stanja elemenata. Ovaj alat pruža programerima mogućnost pisanja testova u različitim programskim jezicima, uključujući C#, te se često koristi za automatizaciju funkcionalnih i integracijskih testova radi poboljšanja kvalitete web aplikacija.

#### 2.1.1 JavaScriptExecutor
Za izvršavanje JavaScript koda između WebDrivera i preglednika koristio sam IJavaScriptExecutor, sučelje u Seleniumu. Ova funkcionalnost omogućuje manipulaciju web stranicama putem izvršavanja JavaScript-a, što može biti korisno za razne interakcije i testiranje koje nisu direktno podržane standardnim Selenium metodama. JavaScriptExecutor se često koristi za izvođenje akcija poput skrolovanja na određenu poziciju, promjene vrijednosti elemenata ili dohvaćanja informacija koje nisu dostupne na drugi način.

### 2.2 Visual Studio 2022
Za razvoj projekta koristio sam Visual Studio 2022, integrirano razvojno okruženje razvijeno od strane Microsofta. Ono pruža alate za razvoj softvera, alate za debugiranje, alate za upravljanje kodom te isto tako alate za testiranje. 

## 3. Testni slučajevi


### 3.1 Text explorer

Na slici je prikazan Text Explorer Visual Studia. Putem istoga možemo pokretati testove. Možemo ih pokretati na 2 načina, svaki test zasebno ili sve testove redom. Ovdje vidimo kako su svi testovi zadovoljili.

![App Screenshot](https://i.postimg.cc/8zN5JMwx/dokaz-testiranja.jpg)




### 3.2 Prvi testni slučaj - automatizirano ispunjavanje forme (prijava)

![prviTest](https://i.postimg.cc/wj2BhMGM/test1.jpg)

Ovaj kod se odnosi na prvi testni slučaj nazvan "ChessLoginTest", koji testira funkcionalnost prijave na web stranicu chess.com. U metodi Setup(), prije samog testiranja, inicijalizira se novi Chrome web driver kako bi se postavio početni uvjet za testiranje. Također, ta inicijalizacija se obavlja i u svakom idućem testu, pa da ju ne moram svaki puta objašnjavati.

Glavna metoda TestLoginAsync obuhvaća korake samog testa. Prvo, navigiramo na stranicu za prijavu (https://www.chess.com/login_and_go). Zatim unesemo korisničko ime i lozinku, pronađemo odgovarajuće elemente na stranici (korisničko ime - username, lozinka - password) te ih popunimo unesenim podacima. Nakon toga, klikom na gumb za prijavu (login), potvrđujemo prijavu.

Nakon prijave, provjeravamo je li URL stranice sadrži "home". Ako da, to znači da je prijava uspjela. U suprotnom, ispisuje se poruka koja obavještava da prijava nije uspjela.
Ovim testom osiguravamo da korisnik može uspješno pristupiti početnoj stranici nakon prijave na chess.com.
### 3.2 Drugi testni slučaj - proces kupovine

![drugiTest](https://i.postimg.cc/cCfx6L3s/test2.jpg)

U drugom testnom slučaju testira se metoda TestZalandoPurchase koja simulira proces kupovine na web stranici zalando.hr.
Prvo, navigiramo na početnu stranicu za mušku odjeću (https://www.zalando.hr/muskarci-home/). Zatim, unosimo pojam "nike patike" u pretraživač te ga potvrđujemo pritiskom tipke Enter. Nakon toga, čekamo neko vrijeme (3 sekunde) kako bismo osigurali da se rezultati pretrage učitaju.

Nakon učitavanja, pronalazimo prvi proizvod koji se prikazuje na stranici i klikamo na njega. To radimo pomoću JavaScriptExecutora kako bismo osigurali da klikne na element bez obzira na moguće preklapanje drugih elemenata.

Nakon otvaranja proizvoda, odabiremo veličinu proizvoda (u ovom slučaju veličina 40) i dodajemo proizvod u košaricu klikom na gumb "Add to Cart".

Ovaj testni slučaj osigurava da korisnik može uspješno pretražiti, odabrati proizvod i dodati ga u košaricu na web stranici zalando.hr.
### 3.2 Treci testni slučaj - test performanse

![treciTest](https://i.postimg.cc/Pqq5KHg4/test3.jpg)

Ova metoda PerformanceTest predstavlja testni slučaj za mjerenje performansi, odnosno brzine učitavanja web stranice. 

Prvo, započinjemo mjerenje vremena izvođenja testa koristeći Stopwatch klasu i metodu stopwatch.Start(). Zatim, navigiramo na ciljanu web stranicu https://www.zalando.hr/muskarci-home/ pomoću driver.Navigate().GoToUrl().

Nakon kratkog čekanja od 1 sekunde (1000 ms), pronalazimo element koji predstavlja link za obuću na web stranici. Nakon što pronađemo taj element, klikamo na njega pomoću metode shoes.Click().

Nakon što se stranica učita, zaustavljamo mjerenje vremena pomoću stopwatch.Stop(). Zatim ispisujemo vrijeme učitavanja stranice u milisekundama pomoću Console.WriteLine().

Na kraju, koristimo Assert kako bismo provjerili je li vrijeme učitavanja stranice manje od 7000 ms (7 sekundi). Ako vrijeme učitavanja prelazi 7 sekundi, test će propasti s odgovarajućom porukom.
Ovaj testni slučaj omogućuje nam da pratimo performanse web stranice zalando.hr i provjerimo ispunjava li ona naše zahtjeve za brzinu učitavanja.
### 3.2 Četvrti testni slučaj - filtriranje 

![cetvrtiTest](https://i.postimg.cc/pThXbZX5/test4.jpg)

Ova metoda FilterSearchTest predstavlja testni slučaj za filtriranje rezultata pretrage na web stranici zalando.hr.

Prvo, navigiramo na početnu stranicu https://www.zalando.hr/muskarci-home/ pomoću driver.Navigate().GoToUrl().
Nakon kratkog čekanja od 2 sekunde (2000 ms), pronalazimo element koji predstavlja link za obuću na web stranici. Nakon što pronađemo taj element, klikamo na njega pomoću shoes.Click().

Zatim čekamo još 2 sekunde (2000 ms) prije nego što pristupimo elementu za filtriranje po brandu. Nakon što pristupimo tom elementu, klikamo na njega.

Nakon toga, čekamo dodatnih 2 sekunde (2000 ms) prije nego što pristupimo elementu za odabir branda adidas. Pronalazimo element koji sadrži tekst "adidas (Sve)" pomoću XPath putanje, te ga kliknemo.

Nakon što odaberemo adidas brand, čekamo još 2 sekunde (2000 ms) prije nego što pristupimo elementu za spremanje postavljenih filtera. Pronalazimo element koji sadrži tekst "Spremi" pomoću XPath putanje, te ga kliknemo.
Ovaj testni slučaj provjerava funkcionalnost filtriranja rezultata pretrage po brandu na web stranici zalando.hr.
### 3.2 Peti testni slučaj - automatizirano ispunjavanje formi

![petiTest](https://i.postimg.cc/xCwj0zcx/test5dio1.jpg)

![petTest2](https://i.postimg.cc/rpYFPbcL/test5dio2.jpg)

Ovaj testni slučaj FillingFormsTest provjerava automatizirano popunjavanje web obrasca na stranici "https://demoqa.com/automation-practice-form".

Nakon što se navigira na navedenu web stranicu pomoću driver.Navigate().GoToUrl(), slijedi čekanje od 1 sekunde prije početka popunjavanja obrasca, što se postiže pomoću await Task.Delay(1000).

Zatim se redom popunjavaju različita polja obrasca:

Ime (firstName) <br>
Prezime (lastName)  <br>
Email adresa (userEmail) <br>
Spol (gender-radio-1) <br>
Broj telefona (userNumber) <br>
Datum rođenja (dateOfBirthInput), gdje se odabire godina i mjesec pomoću padajućih izbornika (SelectElement) <br>
Nakon odabira godine i mjeseca, odabire se i datum rođenja (31. prosinac 2000.) <br>
Predmeti (subjectsInput) <br>
Hobiji (hobbies-checkbox-1) <br>
Trenutna adresa (currentAddress) <br>
Nakon što su sva polja ispravno popunjena, klikne se na gumb za slanje obrasca (submit), čiji element je pronađen pomoću XPath putanje, i to pomoću JavaScriptExecutora, čime se simulira klik na gumb.

Ovim testom provjerava se funkcionalnost popunjavanja i slanja obrasca na web stranici.
