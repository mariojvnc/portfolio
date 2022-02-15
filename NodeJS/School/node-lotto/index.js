const fs = require('fs')

const _ = require('lodash')
const lotto = require('./src/lotto')

const numbers = lotto.getLotteryNumbers()
console.log(_.join(numbers, '; '))

lotto.createTips(1, 'output.json')

console.log(lotto.playTips(JSON.parse(fs.readFileSync('output.json'))))

