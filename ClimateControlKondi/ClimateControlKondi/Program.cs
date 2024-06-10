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
        public static List<List<System.String>> Execute_SQLite(this string _this)
        {
            System.Data.SQLite.SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + _SQLiteFileName);
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = _this;
            connection.Open();
            _this.WriteLine();
            SQLiteDataReader _SQLiteDataReader = command.ExecuteReader();

            List<List<System.String>> _Resalt = new List<List<System.String>>();
            if (_SQLiteDataReader.HasRows) // если есть данные
            {
                while (_SQLiteDataReader.Read())   // построчно считываем данные
                {
                    List<System.String> _ResaltRow = new List<System.String>();
                    for (int i = 0; i < _SQLiteDataReader.FieldCount; i++)
                    { _ResaltRow.Add(_SQLiteDataReader.GetValue(i).ToString().Write()); "; ".Write(); }
                    _Resalt.Add(_ResaltRow);
                    "".WriteLine();
                }
            }
            connection.Close();
            return _Resalt;
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

            //Менеджер
            @"CREATE TABLE Manager (
                Id       INTEGER PRIMARY KEY,
                Name     STRING,
                Phone    STRING,
                login    STRING,
                password STRING
            );"
            .Execute_SQLite();

            //Менеджер
            @"INSERT INTO Manager(Id,Name,Phone,login,password) VALUES
            (1, 'Широков Василий Матвеевич', '89210563128', 'login1', 'pass1')
            ;"
            .Execute_SQLite();

            //Можно шифровать, но это отдельные трудозатраты...
            //Тесты аутентификации менеджера
            @"select Count(Manager.login) from Manager 
                where Manager.login = 'login1' and Manager.password ='pass1'
                GROUP BY Manager.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 1, _f1: a => true, _f0: a => false).ToString().Add(" - результат успешной аутентификации менеджера").WriteLine();

            //Тесты аутентификации менеджера
            @"select Count(Manager.login) from Manager 
                where Manager.login = 'login1__' and Manager.password ='pass1__'
                GROUP BY Manager.login
            ;".Execute_SQLite().GetIf(_fBool: a=>a.Count==0, _f1: a => false, _f0: a => true).ToString().Add(" - результат не успешной аутентификации менеджера").WriteLine();

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

            //Тесты аутентификации Специалиста
            @"select Count(Specialist.login) from Specialist 
                where Specialist.login = 'login3' and Specialist.password ='pass3'
                GROUP BY Specialist.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 1, _f1: a => true, _f0: a => false).ToString().Add(" - результат успешной аутентификации специалиста").WriteLine();

            //Тесты аутентификации Специалиста
            @"select Count(Specialist.login) from Specialist 
                where Specialist.login = 'login3___' and Specialist.password ='pass3'
                GROUP BY Specialist.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 0, _f1: a => false, _f0: a => true).ToString().Add(" - результат не успешной аутентификации специалиста").WriteLine();
            
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

            //Тесты аутентификации Оператора
            @"select Count(Operator.login) from Operator 
                where Operator.login = 'login4' and Operator.password ='pass4'
                GROUP BY Operator.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 1, _f1: a => true, _f0: a => false).ToString().Add(" - результат успешной аутентификации Оператора").WriteLine();

            //Тесты аутентификации Оператора
            @"select Count(Operator.login) from Operator 
                where Operator.login = 'login4__' and Operator.password ='pass4'
                GROUP BY Operator.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 0, _f1: a => false, _f0: a => true).ToString().Add(" - результат не успешной аутентификации Оператора").WriteLine();

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

            //Тесты аутентификации Заказчик
            @"select Count(Сlient.login) from Сlient 
                where Сlient.login = 'login7' and Сlient.password ='pass7'
                GROUP BY Сlient.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 1, _f1: a => true, _f0: a => false).ToString().Add(" - результат успешной аутентификации Заказчик").WriteLine();

            //Тесты аутентификации Заказчик
            @"select Count(Сlient.login) from Сlient 
                where Сlient.login = 'login7____' and Сlient.password ='pass7'
                GROUP BY Сlient.login
            ;".Execute_SQLite().GetIf(_fBool: a => a.Count == 0, _f1: a => false, _f0: a => true).ToString().Add(" - результат не успешной аутентификации Заказчик").WriteLine();

            //@"".ReadLine();

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

            "echo Скрипты выполнены без ошибок! (CMD)".CMDoor_Run();
            "Скрипты выполнены без ошибок! (C#)".WriteLine();
            "База данных развернута и протестированна".WriteLine();
            "".ReadLine();
        }
    }
}
