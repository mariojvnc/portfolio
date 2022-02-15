const os = require('os');
const fs = require('fs')

const filename = 'hello.txt';
const info = os.userInfo();

console.log(`Hello ${info.username}!`)
fs.writeFileSync(filename, `Hello ${os.userInfo().username}!`)