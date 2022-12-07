import mysql.connector

mydb = mysql.connector.connect(
  host="localhost",
  user="alinares",
  password="Alinares94$",
  database="db"
)

mycursor = mydb.cursor()

sql = "INSERT INTO Measures (Date, Temperature, Humidity) VALUES (%s, %s, %s)"
val = ('2022/12/05 22:58', 8.56, 80)

mycursor.execute(sql, val)

mydb.commit()

print(mycursor.rowcount, "record inserted.")