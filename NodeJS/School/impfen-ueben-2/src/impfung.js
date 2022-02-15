const moment = require('moment')
const _ = require('lodash')
const fs = require('fs')
const Console = require("console");
const _readDatabase = () => {
    try{
        return JSON.parse(fs.readFileSync('./data/database.json'))
    } catch (e){
        console.log(e)
        return {}
    }
}
const database = _readDatabase()

const personenMitErstStich = () => {
    let counter = 0
    for(let key of Object.keys(database)){ // Immer bei Objekten, bei array forEach
        if(database[key].impfungen.length >= 1)
            counter++
    }
    return counter
}
/*
const olderThan14 = (person) => {
    const svn = database[person].svn
    // 1377 301088
    //      MMDDYY
    let dateofbirthRaw = svn.toString().substring(4) // 301088 (30.10.1988)
    let year = dateofbirthRaw.substring(4)
    let yearPrefix
    if(parseInt(year) > moment().year % 100) {
         yearPrefix = '19'
    } else {
        yearPrefix = '20'
    }
    year = yearPrefix + year
    let convertedBirthDate = dateofbirthRaw.substring(0, 4) + year

    if(moment().diff(moment(convertedBirthDate, 'DDMMYYY'), 'years' ) >= 14){
        return true;
    }
}

const filterOlderThan14 = () => {
    let result = []
    for (let key of Object.keys(database)){
        if(olderThan14(key))
            result.push(key)
    }
    return result
}
*/

const filterOlderThan14 = () => {

    let result = []

    for(let key of Object.keys(database)){
        let svn = database[key].svn
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

const erinnereAnImpfung = () => {
    let result = []
    const people = filterOlderThan14()
    people.forEach(person => {
        if(database[person].impfungen.length === 0 || database[person].impfungen.length === 1){
            if(database[person].impfungen.length === 0)
                result.push(person)

            if(moment().diff(database[person].impfungen[0].datum, 'months') >= 2)
                result.push(person)
        }
    })

    return result
}

const vakzinStatistik = () => {
    let result = {}

    for (let person of Object.keys(database)){
        database[person].impfungen.forEach(impfung => {
            if(result[impfung.impfstoff] === undefined){
                result[impfung.impfstoff] = []
            }
            result[impfung.impfstoff].push(person)
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