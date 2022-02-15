const request = require('request')
const port = 80
const url = `http://nvs.freeddns.org:${port}/task/`
const key = require('./apikey').key
const moment = require('moment')
const {parse} = require("request/lib/cookies"); // what

const options = {
    method:'GET',
    url: `${url}request/2`,
    headers:{
        'API-key': key
    }
};

const findOldest = (array) => {
    var largest= 0;

    for (let i=0; i<=largest;i++){
        if (array[i]>largest) {
            largest=array[i];
        }
    }

    return largest
}

const findIndexOfOldest = (data, array) => {
    let indexCounter = 0
    const oldest = findOldest(array)
    data.people.forEach((person) =>{
        // var age = moment().diff(person.dateOfBirth, 'years')
        var age = array[indexCounter]
        if(age === oldest){
            return indexCounter // returns first in the array with the age of the oldest
        }
        indexCounter++
    })
    return array.indexOf(findOldest(array)) // else just returns index Of oldest person
}

const runExercise = () => {
    request(options, (error, response_GET, body_GET) => {
        if(error) console.error(error);
        const dataAsJSON = JSON.parse(body_GET)
        console.log(`Aufgabe 2 | Die Aufgabe lautet: ${dataAsJSON.task}`)
        // "Welche Person im Array 'people' ist die Älteste? Sende den INDEX als Antwort.
        //  Sollten mehrere Personen gleich jung sein, nimm die erste Person. (Hinweis: wir beginnen bei 0 zu zählen!)"

        peopleAge = []
        let indexCounter = 0
        dataAsJSON.people.forEach((person) =>{
            var age = moment().diff(person.dateOfBirth, 'years')
            peopleAge.push(age)
        })

        const oldest = findOldest(peopleAge)

        // Kurze Hilfe
        /*for(let i = 0; i < peopleAge.length; i++) {
            console.log(`${i}: ${peopleAge[i]}`)
        }*/

       const indexOfOldest = findIndexOfOldest(dataAsJSON, peopleAge)

        const postOptions = {
            method:'POST',
            url:`${url}solve/2`,
            headers:{
                'API-key': key,
                'result': indexOfOldest
            }
        };

        request(postOptions, (err, response_POST, body_POST) =>{
            if(err) console.error(err);
            body_POST = JSON.parse(body_POST);
            console.log('Aufgabe 2 | Satuscodes:',{GET: response_GET.statusCode, POST: response_POST.statusCode})
            console.log('Aufgabe 2 | people:')
            dataAsJSON.people.forEach((person) =>{
                console.log(person)
            })
            console.log(`Aufgabe 2 | indexOfOldest: ${indexOfOldest}`)
            console.log(`Aufgabe 2 | Die Antwort ist: ${body_POST.message}\n`)
        })
    })}

module.exports = {
    runExercise
};