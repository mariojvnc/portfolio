function add(a, b) {
  const result = a + b
  return result
}

function sub(a, b) {
  return a - b
}

const mul = function (a, b) {
  return a * b
}

// Arrow Function
const div = (a, b) => {
  return a / b
}

const mod = (a, b) => a % b

module.exports = {
  plus: add,  // Different key/value
  sub,        // ES6
  mul: mul,   // Old: key = value
  div: div
}
