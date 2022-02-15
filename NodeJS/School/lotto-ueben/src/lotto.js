const _ = require('lodash')
const moment = require('moment')
const fs = require('fs')

const readFile = () => {
    try {
        return JSON.parse(fs.readFileSync('database.json'))
    } catch {
        return []
    }
}

const  getLotteryNumbers = () => {
    let result = []
    for (let i = 1; i <= 45; i++) {
        result.push(i)
    }
    result = _.shuffle(result)
    result = _.take(result, 6)
    return result
}

const filterOlderThan18 = () => {
    const data = readFile()
    let result = []
    for(let key of Object.keys(data)){
        //let dateOfBirthAs
        const dateOfBirthAsMoment = moment(data[key].dateOfBirth, 'DD/MM/YYYY')
        if(moment().startOf('year').diff(dateOfBirthAsMoment, 'years') >= 18)
            result.push(data[key])
    }
    return result
}

const createTips = (numberOftips, outfile) => {
    const data = readFile()
    const personsOlderThan18 = filterOlderThan18()
    let result = []
    personsOlderThan18.forEach(person => {
        let lastname = person.lastname.toUpperCase()
        let firstname = person.firstname
        let fullname = `"${lastname}, ${firstname}"`
        const tipsToPlay = numberOftips || person.numberTips
        let tips = []
        for (let i = 0; i < tipsToPlay; i++) {
            tips.push(getLotteryNumbers())
        }
        result.push({
            name: fullname,
            tips: tips
        })

    })

    if( outfile === undefined) {
        console.log(JSON.stringify(result, null, 2))
    } else {
        fs.writeFileSync(outfile, JSON.stringify(result, null, 2))
    }

    return result
}



module.exports = {
    getLotteryNumbers,
    filterOlderThan18,
    createTips
}