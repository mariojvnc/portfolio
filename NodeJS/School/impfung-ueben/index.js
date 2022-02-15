const impfung = require('./src/impfung')

// 1. Impfstatistik: Erst-Stich
console.log('Personen mit Erststich: ')
console.log(impfung.personenMitErstStich())
console.log()

// 2. Personen filtern
console.log('Älter als 14: ')
console.log(impfung.filterOlderThan14())
console.log()

// 3. Erinnerung: Impftermin vereinbaren
console.log('Erinnere an Impfung: ')
console.log(impfung.erinnereAnImpfung())
console.log()

// 4. Vakzin-Statistik
console.log('Vakzin-Statistik: ')
console.log(impfung.vakzinStatistik())
console.log()