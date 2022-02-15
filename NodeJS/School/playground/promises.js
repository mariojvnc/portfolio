function add(a, b) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (typeof (a) !== "number" || typeof (b) !== "number") {
                reject("Both parameters must be numbers.")
                return;
            }
            resolve(a+b)
        }, 1000)
    })
}

// (((3+5)+8)+10)+2
const promise = add(3, 5);
promise
    .then(function (result) {
        return add(result, 8)
    })
    .then(function (result2) {
        return add(result2, 10)
    })
    .then(function (result3) {
        return add(result3, 2)
    })
    .then(function (result4) {
       console.log("Finally:", result4)
    })
    .catch(function (error) {
        console.error(error)
    })
