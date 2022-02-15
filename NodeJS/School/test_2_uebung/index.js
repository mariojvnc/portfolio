// Main file
// alle methoden hier aufrufen
const impfung = require('./src/impfung')

console.log(impfung.personenMitErststich())

console.log('Älter als 14', impfung.olderThan14())

console.log('Erinnerung', impfung.erinnereAnImpfung())