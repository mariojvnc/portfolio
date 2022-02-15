const fs = require('fs')

function readData() {
    try {
        const data = fs.readFileSync('database.json', 'utf-8')
        const dataAsJSON = JSON.parse(data)
        return dataAsJSON
    } catch {
        console.error('Fehler!!!')
        return []
    }

}

function getNames() {
    const data = readData()

    const result = []
    for (let i=0; i < data.length; i++) {
        const obj = data[i]
        for (let name of Object.keys(obj)) {
            result.push(name)
        }
    }

    result.sort()

    return result
}

function getLastName() {
    const data = readData()

    const result = {}
    data.forEach(element => {
        let keys = Object.keys(element)

        for (let key of keys) {
            let person = element[key]
            let lastname = person.lastname
            let dateOfBirth = person.dateOfBirth

            // {
            //     "1985-10-24": []
            // }

            if (result[dateOfBirth] === undefined)
                result[dateOfBirth] = []

            result[dateOfBirth].push(`${key} ${lastname}`)
        }
    })

    return result
}

function somethingAboutBmi() {
    const data = readData()

    const result = {}
    data.forEach(element => {
        let keys = Object.keys(element)

        for (let key of keys) {
            let person = element[key]
            let bmi = person.bmi
            let gewicht = bmi.split('/')[0]
            let groesse = bmi.split('/')[1]

            let x = Number(gewicht)
            let y = Math.floor(gewicht)
            let z = parseInt(gewicht)
        }
    })
}

module.exports = {
    getNames,
    getLastName,
    somethingAboutBmi,
    readData
}