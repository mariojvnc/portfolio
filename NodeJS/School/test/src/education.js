const {readFileSync} = require('fs')

const _readFile = () => {
    try {
        return JSON.parse(readFileSync('./data/bildung.json', 'utf-8'))
    } catch (err) {
        console.log(err)
        return {}
    }
}
const database = _readFile()

const getTotalBySex = () => {
    let result = {}

    // Möglichkeit 1
    for(let sex of Object.keys(database)){
        for(let state of Object.keys(database[sex])){
            for(let education of Object.keys(database[sex][state])){

                if(result[sex] === undefined)
                    result[sex] = database[sex][state][education]
                else
                    result[sex] += database[sex][state][education]
            }

        }

    }

    // Möglichkeit 2
    Object.keys(database).forEach(sex => {
        Object.keys(database[sex]).forEach(state => {
            Object.keys(database[sex][state]).forEach(education => {
                if(result[sex] === undefined)
                    result[sex] = database[sex][state][education]
                else
                    result[sex] += database[sex][state][education]
            })
        })
    })

    return result
}

module.exports = {
    getTotalBySex,

}