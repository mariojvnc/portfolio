const request = require('request')
const port = 80
const url = `http://nvs.freeddns.org:${port}/task/`
const key = require('./apikey').key

const options = {
    method:'GET',
    url: `${url}request/1`,
    headers:{
        'API-key': key
    }
};

const count_unique_char = (str1) => {
    var str=str1
    var uniql=""
    let count = 0
    for (var x=0;x < str.length;x++)
    {
        if(uniql.indexOf(str.charAt(x))===-1){
            uniql += str[x];
            count++;
        }
    }
    return count;
}

const runExercise = () => {
    request(options, (error, response_GET, body_GET) => {
        if(error) console.error(error);
        const data = JSON.parse(body_GET)
        // "task":"Wieviele unterschiedliche Zeichen hat der in 'sentence' definierte Satz?","description":"Sende deine Antwort an den in 'url' angegebenen Endpoint als POST request mit deinem 'API-Key' und deinem 'Result' im header.",

        const sentence = data.sentence
        const countOfUniqueLetters = count_unique_char(sentence)
        console.log(`Aufgabe 1 | Die Aufgabe lautet: ${data.task}`)

        const postOptions = {
            method:'POST',
            url:`${url}solve/1`,
            headers:{
                'API-key': key,
                'result': countOfUniqueLetters
            }
        };

        request(postOptions, (err, response_POST, body_POST) =>{
            if(err) console.error(err);
            body_POST = JSON.parse(body_POST);
            console.log('Aufgabe 1 | Satuscodes:',{GET: response_GET.statusCode, POST: response_POST.statusCode})
            console.log(`Aufgabe 1 | sentence: ${sentence}`)
            console.log(`Aufgabe 1 | Ergebnis: ${countOfUniqueLetters}`)
            console.log(`Aufgabe 1 | Die Antwort ist: ${body_POST.message}\n`)
        })
    })}

module.exports = {
    runExercise
};