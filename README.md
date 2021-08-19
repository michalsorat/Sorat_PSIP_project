# Sorat_PSIP_project
Implementácia prepínaču (Switchu) zobrazujúca štatistické údaje prijatých/odoslaných paketov na 2-4 vrstve ISO/OSI modelu.

#Analýza riešenia
Prepínač (Switch) je pojem pre zariadenie v počítačovej sieti, ktoré prepája jednotlivé zariadenia 
v sieti (segmenty siete). Pracuje na druhej vrstve ISO/OSI modelu. Switch na rozdiel od Hub-u 
nerozosiela komunikáciu na všetky uzly počítačovej siete, ale smeruje iba na tie, kam majú byť dáta 
doručené. Na tento úkon využíva tzv. MAC tabuľku, ktorá obsahuje MAC adresy zariadení pripojených 
k daným portom.

Štatistické údaje, ktoré prepínač spracováva:
-Ethernet II
-ARP
-IP
-TCP
-UDP
-ICMP
-HTTP
