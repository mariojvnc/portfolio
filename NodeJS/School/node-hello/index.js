const os = require('os')
const fs = require('fs')

const info = os.userInfo()

// console.log('Hello World.')

console.log(`Hello, ${info.username}!`)
fs.writeFileSync('hello.txt', `Hello, ${info.username}!`)
