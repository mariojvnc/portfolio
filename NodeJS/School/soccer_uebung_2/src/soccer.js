const _ = require('lodash')
const {readFileSync} = require('fs')
const _readDatabase = () =>{
    try{
        return JSON.parse(readFileSync('./data/database.json'))
    }catch (e) {
        console.log(e)
        return []
    }
}
const database = _readDatabase()

const getAllTeams = () => {
    let result = []

    database.forEach(object => {
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
    let result = {}
    database.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                let endstand = spiel.endstand.split(':')
                let goals_heim = parseInt(endstand[0])
                let goals_gast = parseInt(endstand[1])

                if( result[spiel.heimmannschaft] === undefined)
                    result[spiel.heimmannschaft] = {shot: goals_heim, got: goals_gast}
                else{
                    result[spiel.heimmannschaft].shot+= goals_heim
                    result[spiel.heimmannschaft].got+= goals_gast
                }
                if( result[spiel.gastmannschaft] === undefined)
                    result[spiel.gastmannschaft] = {shot: goals_gast, got: goals_heim}
                else{
                    result[spiel.gastmannschaft].shot+= goals_gast
                    result[spiel.gastmannschaft].got+= goals_heim
                }
            })
        })
    })
    return result
}

const getGoalDifference = () => {
    const result = []
    const statistics = getSaisonDetails()

    Object.keys(statistics).forEach( object => {
        let team = {
            team: object,
            statistik: `${statistics[object].shot}:${statistics[object].got}`,
            value: Math.round((statistics[object].shot/statistics[object].got) * 100)/100
        }
        result.push(team)
    })

    /*
    for(let key of Object.keys(statistics)){
        let team = {
            team: key,
            statistik: `${statistics[key].shot}:${statistics[key].got}`,
            value: Math.round((statistics[key].shot/statistics[key].got) * 100)/100
        }
        result.push(team)
    }
    */
    return result.sort((a, b) => (a.value > b.value) ? -1:1)
}

const getScore = () => {
    let result = []
    let teamToScore = {}
    database.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                let endstand = spiel.endstand.split(':')
                let goals_left = parseInt(endstand[0])
                let goals_right = parseInt(endstand[1])

                if (teamToScore[spiel.heimmannschaft] === undefined){
                    teamToScore[spiel.heimmannschaft] = 0
                }
                if (teamToScore[spiel.gastmannschaft] === undefined){
                    teamToScore[spiel.gastmannschaft] = 0
                }

                if(goals_left > goals_right){
                    teamToScore[spiel.heimmannschaft]+= 3
                } else if(goals_left < goals_right){
                    teamToScore[spiel.gastmannschaft]+= 3
                } else {
                    teamToScore[spiel.heimmannschaft]+= 1
                    teamToScore[spiel.gastmannschaft]+= 1
                }
            })
        })
    })

    Object.keys(teamToScore).forEach(team =>{
        result.push({
            team: team,
            score: teamToScore[team]
        })
    })
    /*
    for(let key of Object.keys(teamToScore)){
        result.push({
            team: key,
            score: teamToScore[key]
        })
    }
*/
    return result.sort( (a, b) => (a.score > b.score)? -1:1)
}

module.exports = {
    getAllTeams,
    getSaisonDetails,
    getGoalDifference,
    getScore
}