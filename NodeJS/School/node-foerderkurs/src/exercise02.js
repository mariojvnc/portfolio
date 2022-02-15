const request = require('request');

const url =  'http://uebung.mywire.org/schule';

const options = {
    method: 'GET',
    json: true,
    url: `${url}/sentence`
};

request(options, function (error, response, body) {
    if (error) throw new Error(error);

    const sentence = body.data;
    console.log('Der Satz lautet:', sentence);

    request(`${url}/letter`, function (error, response, body) {
        const letter = JSON.parse(body).letter;
        console.log('Der Buchstabe lautet:', letter);

        const result = (sentence.split(letter).length - 1)

        const postOptions = {
            method: 'POST',
            url: `${url}/solution`,
            qs: {count: result},
            headers: {
                sentence: sentence,
                letter: letter,
                useQueryString: true
            }
        }
        request(postOptions, function (error, response, body) {
            console.log('Antwort vom Server:', body);
        })

    })


});