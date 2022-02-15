const fs = require('fs')
const path = require('path')
const util = require('util')

const pathToMaleNames = path.join(__dirname, 'data', 'male.json');
const pathToFemaleNames = path.join(__dirname, 'data', 'female.json');

fs.readFile(pathToMaleNames, 'utf8', (err, data) => {
    if (err) throw err;

    const names = JSON.parse(data);
    console.log(names);
    fs.readFile(pathToFemaleNames, 'utf8', (err, data) => {
        if (err) throw err;

        const names = JSON.parse(data);
        console.log(names);
    });
});

const readFilePromise = util.promisify(fs.readFile);

readFilePromise(pathToMaleNames, 'utf8')
    .then(data => {
        const names = JSON.parse(data);
        console.log(names);
        return readFilePromise(pathToFemaleNames, 'utf8')
    })
    .then(femaleNames => {
        const names = JSON.parse(femaleNames);
        console.log(names);
    })
    .catch(err => {
        console.error(err);
    })

async function getNames() {
    try {
        const maleNames = await readFilePromise(pathToMaleNames, 'utf8')
        const femaleNames = await readFilePromise(pathToFemaleNames, 'utf8')

        console.log(JSON.parse(maleNames));
        console.log(JSON.parse(femaleNames));
    } catch (err) {
        console.error(err);
    }
}

getNames();
