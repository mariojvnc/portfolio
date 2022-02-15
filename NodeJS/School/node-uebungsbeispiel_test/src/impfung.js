const _ = require('lodash')
const moment = require('moment')
const fs = require('fs')

const databasePath = 'database.json'

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
    for(let key of Object.Keys(data)){
        if(data[key].impfungen.length > 0){
            counter++;
        }
    }
    return counter
}

module.exports = {
    personenMitErststich
}