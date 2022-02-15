const impfung = require('./src/impfung')

// 1. personenMitErstStich
console.log('Personen mit Erststich')
console.log(impfung.personenMitErstStich())

// 2. filter older than 14
console.log('Older than 14')
console.log(impfung.filterOlderThan14())

// 3. erinnere an impfung
console.log('erinnere an impfung')
console.log(impfung.erinnereAnImpfung())

// 3. vakzinStatistik
console.log('vakzinStatistik')
console.log(impfung.vakzinStatistik())