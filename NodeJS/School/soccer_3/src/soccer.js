const {readFileSync} = require('fs')
const moment = require('moment')
const _ = require('lodash')

const readFile = () => {
    try {
        return JSON.parse(readFileSync('./data/database.json'))
    } catch (e) {
        console.log(e)
        return []
    }
}
const data = readFile()

const getAllTeams = () => {
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
    let result = {}
    data.forEach(object => {
        object.details.forEach(detail => {
            detail.spiele.forEach(spiel => {
                let goal_left = parseInt(spiel.endstand.split(':')[0])
                let goal_right = parseInt(spiel.endstand.split(':')[1])

                if (result[spiel.heimmannschaft] === undefined)
                    result[spiel.heimmannschaft] = {shot: goal_left, got: goal_right}
                if (result[spiel.gastmannschaft] === undefined)
                    result[spiel.gastmannschaft] = {shot: goal_right, got: goal_left}
                else {
                    result[spiel.heimmannschaft].shot += goal_left
                    result[spiel.heimmannschaft].got += goal_right
                    result[spiel.gastmannschaft].shot += goal_right
                    result[spiel.gastmannschaft].got += goal_left
                }
            })
        })
    })


    return result
}

const getGoalDifference = () => {
    let result = []
    let teams = getSaisonDetails()

    Object.keys(teams).forEach(team => {
        let object = {
            team: team,
            statistik: `${teams[team].shot  }:${teams[team].got}`,
            value: Math.round( (teams[team].shot / teams[team].got) * 100)/100
        }
        result.push(object)
    })
    return result
}

module.exports = {
    getAllTeams,
    getSaisonDetails,
    getGoalDifference
}