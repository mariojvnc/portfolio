const _ = require('lodash')

const Round = (number) => {
    return _.round(number, 2)
}

const RemoveFirst = (elements) => {
    // let result = []
    // for (let i=1; i < elements.length; i++) {
    //     result.push(elements[i])
    // }
    // return result
    return _.drop(elements, 1)
}

module.exports = {
    Round,
    RemoveFirst
}