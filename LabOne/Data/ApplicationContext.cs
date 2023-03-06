using LabOne.Data.Catalogs;
using LabOne.Data.MainEntities;
using Microsoft.EntityFrameworkCore;


namespace LabOne.Data
{ 
    /// <summary>Представляет контекст приложения для подключение к БД через EF. </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>Возвращает или задает набор школьников. </summary>
        public DbSet<Scholar> Scholars { get; set; } = null!;

        /// <summary>Возвращает или задает набор учителей. </summary>
        public DbSet<Teacher> Teachers { get; set; } = null!;

        /// <summary>Возвращает или задает набор классов. </summary>
        public DbSet<Course> Courses { get; set; } = null!;

        /// <summary>Возвращает или задает набор уровней обучения. </summary>
        public DbSet<Level> Levels { get; set; } = null!;

        /// <summary>Возвращает или задает набор учебных годов. </summary>
        public DbSet<Year> Years { get; set; } = null!;

        /// <summary>Возвращает или задает набор учебных параллелей. </summary>
        public DbSet<Catalogs.Parallel> Parallels { get; set; } = null!;


        /// <summary>Инициализирует новый экземпляр <see cref="ApplicationContext"/> </summary>
        /// <param name="options">Настройки</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        /// <summary>Возвращает объекты из БД состояние которых "не удален". </summary>
        /// <typeparam name="T">Тип объектов. </typeparam>
        /// <param name="set">Набор объектов. </param>
        /// <returns>Коллекция неудаленных объектов. </returns>
        public static IQueryable<T> GetNonRemoved<T>(IQueryable<T> set)
            where T : class, IDataObject
        {
            return set.Where(item => !item.IsRemoved);
        }

        /// <summary>Возвращает только удаленные объекты. </summary>
        /// <typeparam name="T">Тип объектов. </typeparam>
        /// <param name="set">Набор объектов. </param>
        /// <returns>Коллекция удаленных объектов. </returns>
        public static IQueryable<T> GetRemoved<T>(IQueryable<T> set)
            where T : class, IDataObject
        {
            return set.Where(item => item.IsRemoved);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Year> years = new()
            {  
                new Year()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "2022-2023"
                },
                new Year()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "2023-2024"
                }
            };


            List<Level> levels = new()
            {
                new Level()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Начальная школа"
                },
                new Level()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Средняя школа"
                },
                new Level()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Старшая школа"
                },
            };

            List<Catalogs.Parallel> parallels = new();

            for (int i = 1; i <= 11; i++)
            {
                parallels.Add(new Catalogs.Parallel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = i,
                    LevelId = levels[i / 5].Id ?? string.Empty
                });
            }

            List<Teacher> teachers = new()
            {
                new Teacher()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Елена",
                    SecondName = "Петрова",
                    Surname = "Ивановна"
                }
            };

            List<Course> courses = new()
            {
                new Course()
                {
                    Id = Guid.NewGuid().ToString(),
                    Letter = "а",
                    ParallelId = parallels[0].Id,
                    TeacherId = teachers[0].Id,
                    YearId = years[0].Id,
                }
            };

            List<Scholar> scholars = new()
            {
                new Scholar()
                {
                    Id = Guid.NewGuid().ToString(),
                    CourseId = courses[0].Id,
                    FirstName = "Иван",
                    SecondName = "Иванов",
                    Surname = "Иванович"
                }
            };

            modelBuilder.Entity<Year>().HasData(years);
            modelBuilder.Entity<Level>().HasData(levels);
            modelBuilder.Entity<Catalogs.Parallel>().HasData(parallels);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Scholar>().HasData(scholars);
        }
    } 
}
