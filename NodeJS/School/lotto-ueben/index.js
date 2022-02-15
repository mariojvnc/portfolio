const lotto = require('./src/lotto')
const _ = require('lodash')
// 1. getLotteryNumbers
console.log('getLotteryNumbers')
console.log(_.join(lotto.getLotteryNumbers(), '; '))
console.log(lotto.createTips(1, 'outfile.json'))