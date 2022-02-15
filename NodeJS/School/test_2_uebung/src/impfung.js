const _ = require('lodash')
const moment = require('moment')
const fs = require('fs')

const databasePath = './database.json'

const readFile = (filepath) => {
    try{
        return JSON.parse(fs.readFileSync(filepath));
    }
    catch (e) {
        console.error(e)
        return []
    }
}

const personenMitErststich = () => {
    const data = readFile(databasePath)
    let counter = 0
    for(let key of Object.keys(data)){
        if(data[key].impfungen.length > 0){
            counter++;
        }
    }
    return counter
}

const olderThan14 = (person) => {
    const data = readFile(databasePath)

    const svn = data[person].svn
    const datum = svn.toString().substring(4);
    const datumAsMoment = moment(datum, 'YYYY-MM-DD')

    const age = moment().diff(datumAsMoment)

    if(age >= 14)
        return person;
}

const filterOlderThan14 = () => {
    const data = readFile(databasePath)
    let names = []

    for(let key of Object.keys(data)){
        if(olderThan14(data[key])){
            names.push(data[key])
        }
    }

    return names
}

const erinnereAnImpfung = () => {
    const data = readFile(databasePath)
    let names = []

    let people = filterOlderThan14();

    people.forEach(person => {
        if(data[person].impfungen.length === 0){
            names.push(person)
            return
        }

        if(data[person].impfungen.length === 1) {
            const impfungAsMoment = moment(data[person].impfungen[0].datum, 'YYYY-MM-DD')
            if (moment().diff(impfungAsMoment, 'months') >= 2){
                names.push(person)

            }
        }
    })

    return names
}

module.exports = {
    personenMitErststich,
    olderThan14,
    erinnereAnImpfung
}