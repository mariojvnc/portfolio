const soccer = require('./src/soccer')

// 1. Liste aller Mannschaften
console.log('Teams: ')
console.log(soccer.getAllTeams())
console.log()

// 2. Saison Details
console.log('Saison Details: ')
console.log(soccer.getSaisonDetails())
console.log()

// 3. Torverhältnis
console.log('Torverhältnis: ')
console.log(soccer.getGoalDifference())
console.log()

// 4. Punktestand
console.log('Punktestand: ')
console.log(soccer.getScore())