function add(a, b, callback) {
    setTimeout(() => {
        callback(a + b)
    }, 1000)
}

function onResult(ergebnis) {
    console.log('Mein Ergebnis: ', ergebnis)
}

// (((3+5)+8)+10)+2
const result = add(3, 5, onResult)
/*const result2 = add(result, 8)
const result3 = add(result2, 10)
const result4 = add(result3, 2)*/

console.log('Ergebnis: ' + result)