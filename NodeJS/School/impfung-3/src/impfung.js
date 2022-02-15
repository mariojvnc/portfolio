const {readFileSync} = require('fs')
const moment = require('moment')
const _ = require('lodash')
const readFile = () => {
    try{
        return JSON.parse(readFileSync('./data/database.json'))
    } catch (e) {
        console.log(e)
        return {}
    }
}
const database = readFile()

const personenMitErstStich = () => {
    let result = []

    Object.keys(database).forEach(person => {
        if (database[person].impfungen.length >= 1)
            result.push(person)
    })

    return result
}

const filterOlderThan14 = () => {
    let result = []
/*
    Object.keys(database).forEach(key => {
        let person = database[key]
        let date = person.svn.toString().substring(4)
        // 01 11 98
        let beforeyear = date.substring(0, 4)
        let year = date.substring(4)
        let yearprefix
        if(parseInt(year) >= moment().year % 100)
            yearprefix = '20'
        else
            yearprefix = '19'
        let convertedDate = beforeyear + yearprefix + year
        convertedDate = moment(convertedDate, 'DDMMYYYY')
        if(moment().diff(convertedDate, 'years') >= 14)
            result.push(key)

    })
*/
    for(let key of Object.keys(database)){
        let person = database[key]
        let date = person.svn.toString().substring(4)
        // 01 11 98
        let beforeyear = date.substring(0, 4)
        let year = date.substring(4)
        let yearprefix
        if(parseInt(year) >= moment().year % 100)
            yearprefix = '20'
        else
            yearprefix = '19'
        let convertedDate = beforeyear + yearprefix + year
        convertedDate = moment(convertedDate, 'DDMMYYYY')
        if(moment().diff(convertedDate, 'years') >= 14)
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

            if(moment().diff(moment(database[person].impfungen[0].datum), 'months') >= 2)
                result.push(person)
        }
    })

    return result
}

module.exports = {
    personenMitErstStich,
    filterOlderThan14,
    erinnereAnImpfung
}