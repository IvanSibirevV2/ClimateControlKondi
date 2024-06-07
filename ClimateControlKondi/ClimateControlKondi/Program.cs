//ClimateControlKondi
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CMD;
using System.CMD.NirCMD;
using System.Data.SQLite;


namespace ClimateControlKondi
{
    public static class SQLiteConfig
    {
        public static string _SQLiteFileName = "DB_Test.db";
        public static void Execute_SQLite(this string _this)
        {
            System.Data.SQLite.SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + _SQLiteFileName);
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = _this;
            connection.Open();
            _this.WriteLine();
            SQLiteDataReader _SQLiteDataReader = command.ExecuteReader();

            if (_SQLiteDataReader.HasRows) // если есть данные
            {
                while (_SQLiteDataReader.Read())   // построчно считываем данные
                {
                    for (int i = 0; i < _SQLiteDataReader.FieldCount; i++)
                        _SQLiteDataReader.GetValue(i).ToString().Write();
                    "".WriteLine();
                }
            }
            connection.Close();
        }
        public static void DropBD()
        {
            @"".del(SQLiteConfig._SQLiteFileName).CMDoor_Run();
        }
    }
    public class Program
    {
        public static void Main(params string[] args)
        {
            SQLiteConfig.DropBD();

            //Специалист
            @"CREATE TABLE Manager (
                Id       INTEGER PRIMARY KEY,
                Name     STRING,
                Phone    STRING,
                login    STRING,
                password STRING
            );"
            .Execute_SQLite();

            //Специалист
            @"INSERT INTO Manager(Id,Name,Phone,login,password) VALUES
            (1, 'Широков Василий Матвеевич', '89210563128', 'login1', 'pass1')
            ;"
            .Execute_SQLite();

            

            //Специалист
            @"CREATE TABLE Specialist (
                Id       INTEGER PRIMARY KEY,
                Name     STRING,
                Phone    STRING,
                login    STRING,
                password STRING
            );"
            .Execute_SQLite();

            //Специалист
            @"INSERT INTO Specialist(Id,Name,Phone,login,password) VALUES
            (2, 'Кудрявцева Ева Ивановна', '89535078985', 'login2', 'pass2')
            ,(3, 'Гончарова Ульяна Ярославовна', '89210673849', 'login3', 'pass3')
            ,(10, 'Беспалова Екатерина Даниэльевна', '89219567844', 'login10', 'pass10')
            ;"
            .Execute_SQLite();

            //Оператор
            @"CREATE TABLE Operator (
                Id       INTEGER PRIMARY KEY,
                Name     STRING,
                Phone    STRING,
                login    STRING,
                password STRING
            );"
            .Execute_SQLite();

            //Оператор
            @"INSERT INTO Operator(Id,Name,Phone,login,password) VALUES
            (4, 'Гусева Виктория Данииловна', '89990563748', 'login4', 'pass4')
            ,(5, 'Баранов Артём Юрьевич', '89994563847', 'login5', 'pass5')
            ;"
            .Execute_SQLite();
            
            //Заказчик
            @"CREATE TABLE Сlient (
                Id       INTEGER PRIMARY KEY,
                Name     STRING,
                Phone    STRING,
                login    STRING,
                password STRING
            );"
            .Execute_SQLite();

            //Заказчик
            @"INSERT INTO Сlient(Id,Name,Phone,login,password) VALUES
            (6, 'Овчинников Фёдор Никитич', '89219567849', 'login6', 'pass6')
            ,(7, 'Петров Никита Артёмович', '89219567841', 'login7', 'pass7')
            ,(8, 'Ковалева Софья Владимировна', '89219567842', 'login8', 'pass8')
            ,(9, 'Кузнецов Сергей Матвеевич', '89219567843', 'login9', 'pass9')
            ;"
            .Execute_SQLite();



            @"CREATE TABLE TypeEquipment(Id   INTEGER PRIMARY KEY,Name STRING);"
            .Execute_SQLite();

            @"CREATE TABLE ModelEquipment(
                Id              INTEGER PRIMARY KEY,
                Name            STRING,
                IdTypeEquipment INTEGER REFERENCES TypeEquipment(Id)
            );"
            .Execute_SQLite();

            @"CREATE TABLE StatusAction (
                Id   INTEGER PRIMARY KEY,
                Name STRING
            );
            "
           .Execute_SQLite();

            @"INSERT INTO StatusAction(Name) VALUES
            ('ЗаявкаОткрыта')     
            ,('ЗаявкаВПроцессеРемонта')
            ,('ЗаявкаЗавершена')  
            ;
            "
           .Execute_SQLite();

            @"CREATE TABLE [Action] (
                Id               INTEGER  PRIMARY KEY,
                Description      STRING,
                IdСlient         INTEGER  REFERENCES Сlient (Id),
                IdModelEquipment INTEGER  REFERENCES ModelEquipment (Id),
                IdStatusAction   INTEGER  REFERENCES StatusAction (Id),
                DateInsertUpdate DATETIME
            );"
            .Execute_SQLite();

            //            "CREATE TABLE Users(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Age INTEGER NOT NULL)"
            //          .Execute_SQLite();

            //    "SELECT * FROM sqlite_master;"
            //.Execute_SQLite();


            "echo qqw".CMDoor_Run();

            "fsfsd".WriteLine();
            "".ReadLine();
        }
    }
}
