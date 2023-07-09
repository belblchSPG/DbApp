
using DbApp.DAL.Context;
using DbApp.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DbApp.Data
{

    // Класс для заполнения базы данных тестовыми данными
    class DbInitializer
    {
        // Класс запоминает базу данных 
        private readonly AppDB _db;
        private readonly ILogger<DbInitializer> _Logger;

        
        public DbInitializer(AppDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }


        // Работа с БД у EF должно являться асинхронным процессом, так как процесс запросов к БД может быть
        // достаточно длительным, поэтому он не должен протекать в основном потоке
        public void Initialize()
        {
            _db.Database.Migrate();

            InitializeStudents();
        }

        private const int __StudentsCount = 5;

        private Student[] _Students;
        private void InitializeStudents()
        {
            _Students = new Student[__StudentsCount];
            Student Andrey = new Student("Andrey", "Timofeev", "Sergeevich", 3.9);
            _Students[Andrey.Id] = Andrey;

            this._db.Students.AddRange(_Students);
            this._db.SaveChanges();
        }
    }
}
