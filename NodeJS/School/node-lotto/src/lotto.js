const _ = require('lodash')
const moment = require('moment')

const fs = require('fs')
const path = require('path')

const _readDatabase = (filename) => {
    try {
        return JSON.parse(fs.readFileSync(filename, 'utf-8'))
    } catch (e) {
        console.error(e)
        return []
    }
}

const _olderThan18 = (person) => {
    const convertedDate = moment(person['dateOfBirth'], 'DD/MM/YYYY')
    const startOfTheYear = moment().startOf('year')
    const age = startOfTheYear.diff(convertedDate, 'years')
    return age >= 18
}

const getLotteryNumbers = () => {
    let numbers = []
    for (let i=1; i <= 45; i++) {
        numbers.push(i)
    }
    console.log(numbers)

    // Durchschütteln
    let shuffledNumbers = _.shuffle(numbers)
    console.log(shuffledNumbers)

    // Nimm die ersten 6 Stück
    return _.take(shuffledNumbers, 6)
}

const createTips = (numberOfTips, outfile) => {
    const database = _readDatabase(path.join('data', 'database.json'))

    const filteredPersons = database.filter(person => _olderThan18(person))

    // for (let p of filteredPersons) {
    //
    // }

    let allPeopleWithAllTheirTipps = []
    filteredPersons.forEach(p => {
        let name = `${p['lastname'].toUpperCase()}, ${p['firstname']}`
        let tips = []
        const tipsToPlay = numberOfTips || p.numberTips
        for (let i=1; i <= tipsToPlay; i++) {
            tips.push(getLotteryNumbers())
        }
        allPeopleWithAllTheirTipps.push({
            name: name,
            tips: tips
        })
    })

    if (outfile === undefined) {
        console.log(JSON.stringify(allPeopleWithAllTheirTipps, null, 2))
    } else {
        fs.writeFileSync(outfile, JSON.stringify(allPeopleWithAllTheirTipps, null, 2))//})
    }
}

const playTips = (tips) => {
    const drawnNumbers = getLotteryNumbers()
    console.log('Gezogene Zahlen:', drawnNumbers.join('; '))

    let result = {}
    for (let data of tips) {
        data.tips.forEach(tip => {
            const matchingNumbers = _.intersection(drawnNumbers, tip)
            if (result[_.size(matchingNumbers)] === undefined)
                result[_.size(matchingNumbers)] = []

            // result[_.size(matchingNumbers)].push({
            //     "Abgegebener Tipp:": JSON.stringify(tip),
            //     "Übereinstimmende Zahlen: ": JSON.stringify(matchingNumbers)
            // })
            result[_.size(matchingNumbers)].push(tip)
        })
    }
    return result
}

module.exports = {
    getLotteryNumbers: getLotteryNumbers,
    createTips: createTips,
    playTips: playTips
}
