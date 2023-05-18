const express = require('express');
const cors = require('cors');
const mysql = require('mysql2');

const app = express();
app.use(cors());

const db = mysql.createConnection({
  host: 'localhost',
  user: 'rcs_platform',
  password: 'rootpassword',
  database: 'rcsp_webapp_db'
});

db.connect((err) => {
  if (err) {
    throw err;
  }
  console.log('MySQL Connected...');
});

app.get('/api/data', (req, res) => {
  let sql = 'SELECT * FROM your_table_name';
  let query = db.query(sql, (err, results) => {
    if(err) throw err;
    res.send(results);
  });
});

app.listen(5000, () => console.log('Server started on port 5000'));
