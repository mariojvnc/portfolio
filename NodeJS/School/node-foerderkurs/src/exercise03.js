const util = require("util");
const fs = require("fs");
const path = require("path");
var axios = require("axios").default;
const _ = require('lodash')

const pathToMaleNames = path.join(__dirname, '..', 'data', 'male.json');
const pathToFemaleNames = path.join(__dirname, '..', 'data', 'female.json');

const readFilePromise = util.promisify(fs.readFile);

let maleNames
let femaleNames

function _getRandomEntries(data, count) {
    const shuffledArray = _.shuffle(data);
    const result = _.take(shuffledArray, count);

    return result;
}

async function getMatches(maleNames, femaleNames) {
    const result = []
    for (let male of maleNames) {
        for (let female of femaleNames) {
            var options = {
                method: 'GET',
                url: 'https://love-calculator.p.rapidapi.com/getPercentage',
                params: {sname: female, fname: male},
                headers: {
                    'x-rapidapi-host': 'love-calculator.p.rapidapi.com',
                    'x-rapidapi-key': '162925fc19msh3819722ce3f07f1p1bbf4bjsnabbce8997683'
                }
            };

            result.push(axios.request(options));
        }
    }

    return await Promise.all(result);
}

readFilePromise(pathToMaleNames, 'utf8')
    .then(data => {
        maleNames = JSON.parse(data);
        return readFilePromise(pathToFemaleNames, 'utf8')
    })
    .then(data => {
        femaleNames = JSON.parse(data);

        const pickedMaleNames = _getRandomEntries(maleNames, 3);
        const pickedFemaleNames = _getRandomEntries(femaleNames, 3);

        getMatches(pickedMaleNames, pickedFemaleNames)
            .then(result => {
                result.forEach(data => {
                    console.log(data.data);
                })
            })

    })
    .catch(err => {
        console.error(err);
    })

