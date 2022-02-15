const qrcode = require('qrcode-terminal');

const { Client } = require('whatsapp-web.js');
const fs = require("fs");
const SESSION_FILE_PATH = './session.json';


let sessionData;
if(fs.existsSync(SESSION_FILE_PATH)) {
    sessionData = require(SESSION_FILE_PATH);
}

let HEY_COUNTER_PATH = './data/hey_cuonter.json'
let heycounter

try {
    heycounter = JSON.parse(fs.readFileSync(HEY_COUNTER_PATH))
} catch (e) {
    console.log(e)
    heycounter = {count: 0}
}

const client = new Client({
    session: sessionData
});

client.on('authenticated', (session) => {
    sessionData = session;
    fs.writeFile(SESSION_FILE_PATH, JSON.stringify(session), (err) => {
        if (err) {
            console.error(err);
        }
    });
});

client.on('qr', qr => {
    qrcode.generate(qr, {small: true});
});

client.on('ready', () => {
    console.log('Client is ready!');
});


client.on('message', msg => {
    console.log(`${msg.getInfo()}: ${msg.body}`)
    let message = msg.body.toLowerCase()
    let messageparts = message.split(' ')
    messageparts.forEach(part => {
        if (part.includes('hey')) {
            heycounter.count++
            msg.reply(`hey counter: ${heycounter.count}`)
            fs.writeFile(HEY_COUNTER_PATH, JSON.stringify(heycounter), (err) => {
                if (err) {
                    console.error(err);
                }
            });
        }
    })

});

client.initialize();
