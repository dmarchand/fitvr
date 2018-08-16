const express = require('express')
const app = express()

app.get('/', (req, res) => res.send('Hello World!'))

app.listen(3000, () => console.log('Example app listening on port 3000!'))

app.get('/submitHeartRate', function (req, res) {
  console.log(req.query.hr);
  res.send('hello world')
})
