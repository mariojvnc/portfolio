// 1

const s = 'Hallo'
var message = 'Welt'
let text = '4AHIF'

console.log(s + message + text)

// 2

let stringArray = ['Markus', 'Mario', 'Felix', 'Jakob']

console.log(stringArray)
stringArray.forEach(element => console.log(element));

// 3
const person1 = {
  firstname: 'Hans',
  lastname: 'Huber',
  zipCode: 1220,
  address: 'Alte Donau 2',
  dateOfBirth: '1965-12-05'
}

const person2 = {
  firstname: 'Franz',
  lastname: 'Meier',
  zipCode: 1120,
  address: 'Meidlinger Hauptstrasse 4',
  dateOfBirth: '1972-03-30'
}

const person3 = {
  firstname: 'Hubert',
  lastname: 'Müller',
  zipCode: 1070,
  address: 'Neubaugasse 12',
  dateOfBirth: '1983-11-19'
}

const persons = [person1, person2, person3]

const personsV2 = [
  {
    firstname: 'Franz',
    lastname: 'Meier',
    zipCode: 1120,
    address: 'Meidlinger Hauptstrasse 4',
    dateOfBirth: '1972-03-30'
  },
  {
    firstname: 'Hans',
    lastname: 'Huber',
    zipCode: 1220,
    address: 'Alte Donau 2',
    dateOfBirth: '1965-12-05'
  },
  {
    firstname: 'Hubert',
    lastname: 'Müller',
    zipCode: 1070,
    address: 'Neubaugasse 12',
    dateOfBirth: '1983-11-19'
  }
]

// 4
personsV2.forEach((object) => {
  console.log(`${object.lastname}, ${object.firstname}`)
});

// 5
const sortedPeople = personsV2.sort(function (a, b) {
  if (a.lastname < b.lastname)
    return -1
  if (b.lastname < a.lastname)
    return 1

  return 0
})

console.log(personsV2)

// 6
const fs = require('fs');
const content = fs.readFileSync('persons.db', 'utf-8')
const contentAsJS = JSON.parse(content)
console.log(contentAsJS)

// 7
console.log('---------- 7 --------')

const moment = require('moment')

const foundPeople = []
contentAsJS.forEach((person) => {
  const myDate = person.dateOfBirth
  const dateAsMoment = moment(myDate, 'MMM DD, YYYY')
  const now = moment()
  const age = now.diff(dateAsMoment, 'years')
  if (age >= 18) {
    foundPeople.push(person)
  }
})

console.log(foundPeople)

// Filter Function

const numbers = [3, 5, 2, 65, 342, 25, 65, 23, 11]
const evenNumbers = numbers.filter(number => number % 2 == 0)

console.log(evenNumbers)

// 7 (alternativ)
const adults = contentAsJS.filter(person => {
  const myDate = person.dateOfBirth
  const dateAsMoment = moment(myDate, 'MMM DD, YYYY')
  const now = moment()
  const age = now.diff(dateAsMoment, 'years')
  return (age >= 18)
})

console.log(adults)

// 8
adults.forEach(p => {
  console.log(`${p.lastname}, ${p.firstname}`)
})
