function add(a, b, cb) {
    setTimeout(() => {
        if (typeof (a) !== "number" || typeof (b) !== "number") {
            cb("Both parameters must be numbers.")
            return;
        }
        cb(undefined, a+b)
    }, 1000)
}

// function onResult(ergebnis) {
//     add(ergebnis, 8, onResult2)
// }

// (((3+5)+8)+10)+2
add(3, 5, function (error, result) {
    if (error) {
        console.error(error)
        return;
    }
    add(result, 8, function (error, result2) {
        if (error) {
            console.error(error);
            return;
        }
        add(result2, 10, function (error, result3) {
            if (error) {
                console.error(error);
                return;
            }
            add(result3, 2, function (error, result4) {
                if (error) {
                    console.error(error);
                    return;
                }
                console.log("Endergebnis:", result4)
            })
        })
    })
})
// const result2 = add(result, 8)
// const result3 = add(result2, 10)
// const result4 = add(result3, 2)

// console.log("Ergebnis:", result)