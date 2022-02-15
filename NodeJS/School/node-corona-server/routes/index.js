var express = require('express');
var router = express.Router();

const statistik = require('../src/statistik')

router.get('/States', function(req, res, next) {
  res.send(statistik.getStates());
});

router.get('/AgeGroups', function(req, res, next) {
  res.send(statistik.getCategories());
});

router.get('/Sexes', function(req, res, next) {
  res.send(statistik.getSexes());
});

router.get('/ResultsForGroup', function(req, res, next) {
  const group = req.query.group;
  const state = req.query.state;
  const result = statistik.getResultsForAgeGroup(group, state)
  if (result.code !== 200)
    return res.status(result.code).send(result.message);

  res.status(result.code).send(result.data);
});

router.get('/TotalCount', function(req, res, next) {
  res.send(statistik.getTotalCount());
});

router.get('/SummaryByState', function(req, res, next) {
  res.send(statistik.getSummaryByState());
});

router.get('/InfectionRate', function(req, res, next) {
  res.send(statistik.getInfectionRate());
});

module.exports = router;
