const express = require('express')
const app = express()

let heartRateHistory = {}
const HEART_RATE_MAX_HISTORY = 50

app.listen(3000, () => {
  console.log('HR Server started')
})

app.get('/submitHeartRate', function (req, res) {
  let heartRate = req.query.hr
  let uniqueId = req.query.id

  let history = heartRateHistory[uniqueId]
  if(!history) {
    history = []
  }
  history.unshift(heartRate)

  if(history.length > HEART_RATE_MAX_HISTORY) {
    history.length = HEART_RATE_MAX_HISTORY
  }

  heartRateHistory[uniqueId] = history

  console.log('Wrote heart rate: ' + heartRate + " for id: " + uniqueId)
  res.send()
})

app.get('/latest', function (req, res) {
  res.send(heartRateHistory)
})
