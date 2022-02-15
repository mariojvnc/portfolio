const _ = require('lodash')
const moment = require('moment')
const fs = require('fs')

const readFile = () => {
    let filename = './data/database.json'
    try {
        return JSON.parse(fs.readFileSync(filename))
    } catch {
        return []
    }
}

const getAllTeams = () => {
    const data = readFile()
    let result = []

    data.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                result.push(spiel.heimmannschaft)
                result.push(spiel.gastmannschaft)
            })
        })
    })

    return _.uniq(result)
}

const getSaisonDetails = () => {
    const data = readFile()
    let result = {}

    data.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                let goals = spiel.endstand.split(':')
                let goalLeft = parseInt(goals[0])
                let goalRight = parseInt(goals[1])

                if (result[spiel.heimmannschaft] === undefined || result[spiel.gastmannschaft] === undefined) {
                    if(result[spiel.heimmannschaft] === undefined )
                        result[spiel.heimmannschaft] = {shot: goalLeft, got: goalRight}

                    if(result[spiel.gastmannschaft] === undefined )
                        result[spiel.gastmannschaft] = {shot: goalRight, got: goalLeft}
                } else {
                    result[spiel.heimmannschaft].shot += goalLeft
                    result[spiel.heimmannschaft].got += goalRight

                    result[spiel.gastmannschaft].shot += goalRight
                    result[spiel.gastmannschaft].got += goalLeft
                }
            })
        })
    })

    return result
}

const getGoalDifference = () => {
    const teamStatistics = getSaisonDetails()
    let result = []

    for(let key of Object.keys(teamStatistics)){
        // In key steht der Mannschaftsname
        // zb 'SK Rapid Wien'
        let shot = teamStatistics[key].shot
        let got = teamStatistics[key].got
        let value = shot / got
        value = Math.round(value * 100) / 100

        // `string text ${expression} string text`
        // https://developer.mozilla.org/de/docs/Web/JavaScript/Reference/Template_literals

        result.push( { team: key, statisik: `${shot}:${got}`, value: value} )
    }

    // list.sort((a, b) => (a.color > b.color) ? 1 : -1)
    // https://flaviocopes.com/how-to-sort-array-of-objects-by-property-javascript/

    return result.sort((a/*.value*/, b/*value*/) =>  /*compareValues(a.value, b.value)*/ (a.value < b.value) ? 1 : -1)
}

const getScore = () => {
    const data = readFile()
    let result = []
    const allTeams = getAllTeams()
    let objekt = {}
    data.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                let goals = spiel.endstand.split(':')
                let goalLeft = parseInt(goals[0])
                let goalRight = parseInt(goals[1])

                if(objekt[spiel.heimmannschaft] === undefined){
                    objekt[spiel.heimmannschaft] = 0
                }
                if(objekt[spiel.gastmannschaft] === undefined){
                    objekt[spiel.gastmannschaft] = 0
                }

                if(goalLeft > goalRight)
                    objekt[spiel.heimmannschaft] += 3
                else if (goalLeft < goalRight) {
                    objekt[spiel.gastmannschaft] += 3
                } else {
                    objekt[spiel.heimmannschaft] += 1
                    objekt[spiel.gastmannschaft] += 1
                }
           })
        })
    })

    for(let key of Object.keys(objekt)){
        let team = {
            team: key,
            score: objekt[key]
        }
        result.push(team)
    }

    return result.sort( (a, b) => (a.score < b.score) ? 1 : -1)
}

const compareValues = (a, b) => {
    if (a < b){
        return 1
    } else {
        return -1
    }
}

module.exports = {
    getAllTeams,
    getSaisonDetails,
    getGoalDifference,
    getScore
}