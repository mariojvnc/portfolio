const _ = require('lodash')
const moment = require('moment')
const fs = require('fs')

const readFile = () => {
    try{
        return JSON.parse(fs.readFileSync('./data/database.json'))
    } catch {
        return []
    }
}

// 1. Impfstatistik: Erst-Stich
const personenMitErstStich = () => {
    const data = readFile()
    let counter = 0

    for(let key of Object.keys(data)){
        if (data[key].impfungen.length >= 1)
            counter ++
    }

    return counter
}

// 2. Personen filtern
const filterOlderThan14 = () => {
    const data = readFile()
    let result = []

    for(let key of Object.keys(data)){
        let svn = data[key].svn
        // 1377 30.10.88
        let svnAsString = svn.toString().substring(4)
        let year = svnAsString.substring(4)
        let prefixYear
        if (parseInt(year) > moment().year() % 100){
            prefixYear = '19'
        } else {
            prefixYear = '20'
        }
        let convertedyear = prefixYear + year;
        let dateAsString = svnAsString.substring(0,4) + convertedyear.toString()
        let dateAsMoment = moment(dateAsString, 'DDMMYYYY')
        if(moment().diff(dateAsMoment, 'years') >= 14)
            result.push(key)
    }

    return result
}

// 3. Erinnerung: Impftermin vereinbaren
const erinnereAnImpfung = () => {
    const personsOlderThan14 = filterOlderThan14()
    const data = readFile()
    let result = []

    personsOlderThan14.forEach(person => {
        if (data[person].impfungen.length === 0 || data[person].impfungen.length === 1){
            if (data[person].impfungen.length === 0)
                result.push(person)
            if(moment().diff(data[person].impfungen[0].datum, 'months') >= 2)
                result.push(person)
        }
    })

    return result
}

// 4. Vakzin-Statistik
const vakzinStatistik = () => {
    const data = readFile()
    let result = {}

    for (let key of Object.keys(data)){
        data[key].impfungen.forEach(impfung => {
           const impfstoff = impfung.impfstoff
            if(result[impfstoff] === undefined)
                result[impfstoff] = []
            result[impfstoff].push(key)
        })
    }

    for(let key of Object.keys(result)){
        result[key] = _.uniq(result[key])
    }
    return result
}

module.exports = {
    personenMitErstStich,
    filterOlderThan14,
    erinnereAnImpfung,
    vakzinStatistik
}