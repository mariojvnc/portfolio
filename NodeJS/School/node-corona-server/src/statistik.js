const fs = require('fs')

const _ = require('lodash')

const database = './data/statistik.json'

function _getData() {
    try {
        return JSON.parse(fs.readFileSync(database))
    } catch {
        return {}
    }
}

function getStates() {
    const data = _getData();

    let result = []
    for (let group of Object.keys(data)) {
        const states = Object.keys(data[group]);
        result = _.uniq(_.union(result, states));
    }

    return result
}

function getCategories() {
    const data = _getData();

    return Object.keys(data)
}

function getSexes() {
    const data = _getData();

    let result = []
    for (let group of Object.keys(data)) {
        for (let state of Object.keys(data[group])) {
            result = _.uniq(_.union(Object.keys(data[group][state])))
        }
    }
    return result
}

function getResultsForAgeGroup(group, state) {
    const data = _getData();

    if (!data[group])
        return { code: 404, message: `Invalid group: ${group}` }

    if (!state)
        return { code: 200, data: data[group]}

    if (!data[group][state])
        return { code: 404, message: `Invalid state: ${state}` }

    return { code: 200, data: data[group][state] }
}

function getTotalCount() {
    const data = _getData();

    const result = {}
    for (let group of Object.keys(data)) {
        for (let state of Object.keys(data[group])) {
            for (let sex of Object.keys(data[group][state])) {
                if (result[sex] === undefined)
                    result[sex] = 0

                result[sex] += parseInt(data[group][state][sex].einwohner)
            }
        }
    }

    return result
}

function getSummaryByState() {
    const data = _getData();

    const result = {}
    for (let group of Object.keys(data)) {
        for (let state of Object.keys(data[group])) {
            if (result[state] === undefined) {
                result[state] = {
                    infiziert: 0,
                    einwohner: 0
                }
            }
            for (let sex of Object.keys(data[group][state])) {
                let content = data[group][state][sex];

                result[state].infiziert += parseInt(content.infiziert);
                result[state].einwohner += parseInt(content.einwohner);
            }
        }
    }

    return result
}

function getInfectionRate(count) {
    const data = getSummaryByState();

    const result = []
    for (let state of Object.keys(data)) {
        let percentage = data[state].infiziert / data[state].einwohner;
        result.push({
            state,
            infected: Math.round(percentage * 100 * 100) / 100
        })
    }

    result.sort((a, b) => {
        return b.infected - a.infected
    })

    if (!count)
        return result;

    return _.take(result, count)
}


module.exports = {
    getStates,
    getCategories,
    getSexes,
    getResultsForAgeGroup,
    getTotalCount,
    getSummaryByState,
    getInfectionRate
}