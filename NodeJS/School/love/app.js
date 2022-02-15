const request = require('request');

const options = {
    method: 'GET',
    url: 'https://love-calculator.p.rapidapi.com/getPercentage',
    qs: {sname: 'Alice', fname: 'John'},
    headers: {
        'x-rapidapi-host': 'love-calculator.p.rapidapi.com',
        'x-rapidapi-key': 'da92b53bbamshecd2ab6466ca07fp12c0bfjsn78ae982e5e6f',
        useQueryString: true
    }
};

request(options, function (error, response, body) {
    if (error) throw new Error(error);

    console.log(body);
});