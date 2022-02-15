const express = require('express')
const {response, request} = require("express");
const app = express()
const port = 3000
const fs = require('fs')

app.get('/', (req, res) => {
    res.send('Hello World!')
})

app.get('/4ahif', (req, res) => {
    const params = req.query
    const headers = req.headers;
    console.log(headers)
    res.send('Hello from GET event handler!')
})

app.get('/index.html', (req, res) => {
    res.send(fs.readFileSync('./public/index.html', 'utf8'))
})

app.post('/4ahif', (req, res) => {
    res.send('Hello from POST event handler!')
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})