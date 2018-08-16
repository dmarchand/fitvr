const express = require('express'),
                fs = require('fs')
const app = express()

const HR_HISTORY_PATH = '../common/heartRateHistory'
var writer

app.listen(3000, () => {
  console.log('Example app listening on port 3000!')
  cleanUp()
  writer = fs.createWriteStream(HR_HISTORY_PATH, {
            flags: 'a+'
        })
})

app.get('/submitHeartRate', function (req, res) {
  let heartRate = req.query.hr
  console.log('Got heart rate: ' + heartRate)
  writer.write(heartRate + '\n')
  res.send('Success!')

})

function cleanUp() {
  console.log('Process terminating.')
  fs.truncate(HR_HISTORY_PATH, 0, function(){
    console.log('Cleaned up HR history')
    process.exit()
  })
}

process.on('exit', cleanUp)
process.on('SIGTERM', cleanUp)
process.on('SIGINT', cleanUp)
