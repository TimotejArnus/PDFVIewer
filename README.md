# PDFVIewer

Author: Timotej Arnus

1. Aplikacijo zaženemo z PDFViewer.exe, ki se nahaja na \PDFViewer\bin\Debug\netcoreapp3.1
2. Ko se aplikacija zažene imamo na voljo 2 zavihka "General" in "Printers".
3. V General lahko izberemo pot do PDF datoteke, to lahko storimo s pomočjo Gumba "..." na desni strani ali pa pot do datoteke vnesemo ročno v vnosno polje. 
3.1. Ko smo vnesli pot do datoteke, se v poljih spodaj pojavita še ime datoteke in velikost. Vnosnih polj ne moremo spreminjati.
4. V Printers lahko izbreremo želeni printer izmed vseh, ki so nam na voljo.
4.1. Če noben printer ne bo izbran bo program poskusil poiskati privzeti printer.
5. Pod zavihkoma se nahaja okno, ki prikazuje morebitne napake z pomočjo razreda " Logger " in je do prve napake skrito.
6. Ko je v vnosnem polju za pot do datoteke navedena pravilna pot za datoteko, ki dejansko obstaja na raćunalniku lahko pritisnemo na gumb "Preview", ki bo odprl PDF za predogled.
6.1.! Predogled ne bo deloval, če so v poti navedeni šumniki.
7. Ko so izpolnjeni vsi podatki, lahko pritisnemo na gumb "Print", ki bo preveril realnost podatkov in pričel tiskati.
8.! Če program ne bi odgkril nobenih tiskalnikov je potrbno zagnati servis v ozadju za tiskanje "Print Spooler", to lahko stori tudi program, vendar ga moramo zagnati z Admiinistrativnimi previcami.
