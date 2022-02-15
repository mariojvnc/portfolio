
const fs = require('fs');

function readFile (filename) {
    return JSON.parse(fs.readFileSync(filename))
}

const data = readFile("data.json")


const calculateCountVowels = (name) => (name.match(/[aeiou]/gi) || []).length

let sum = 0;
data.forEach(person => {
    const name = person.name
    const age = parseInt(person.age)
    const countVowels = calculateCountVowels(name)

    if(countVowels <= 2 && name.length > 5){
        sum += age
    }
})

console.log(sum)