using System;
using System.Data.Entity;
using System.Linq;
using BEFLSPR.Models;

namespace BL
{
    public class DbContextBEFL : DbContext
    {
        // Your context has been configured to use a 'DbContextBEFL' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WFAdmin.DbContextBEFL' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContextBEFL' 
        // connection string in the application configuration file.
        public DbContextBEFL()
            : base("name=DbContextBEFL")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<BL.Emp> Emps { get; set; }
        public virtual DbSet<BL.Pos> Poss { get; set; }
        public virtual DbSet<BL.Dep> Deps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BL.Emp>()
                .Property(it => it.DepId)
                .IsOptional();

            modelBuilder.Entity<BL.Emp>()
                .Property(it => it.PosId)
                .IsOptional();
        }

        public DbSet<MC> MCs { get; set; }

        public DbSet<Comp> Comps { get; set; }
    }

    internal class dbInit : System.Data.Entity.MigrateDatabaseToLatestVersion<DbContextBEFL, BEFLSPR.Migrations.Configuration>
    //public class dbInit : System.Data.Entity.CreateDatabaseIfNotExists<DbContextBEFL>
    {
        //protected override void Seed(DbContextBEFL context)
        //{
        //    context.Deps.Add(new BL.Dep { Id = 1, Name = "Управление" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Административный отдел" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Бухгалтерия" });
        //    context.Deps.Add(new BL.Dep { Id = 1, Name = "Отдел аудита" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Отдел корпоративных процедур" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Отдел правовых услуг" });
        //    context.Deps.Add(new BL.Dep { Id = 1, Name = "Отдел оценки" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Отдел Отдел управления персоналом " });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Отдел охраны" });
        //    context.Deps.Add(new BL.Dep { Id = 1, Name = "Отдел информационных технологий" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Московский офис" });
        //    context.Deps.Add(new BL.Dep { Id = 2, Name = "Хозяйственный отдел" });
        //    context.Deps.Add(new BL.Dep { Id = 1, Name = "Отдел контроллинга" });


        //    context.Poss.Add(new BL.Pos { Id = 1, Name = "Управляющий директор" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Руководитель отдела" });
        //    context.Poss.Add(new BL.Pos { Id = 1, Name = "Переводчик" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Административный ассистент" });
        //    context.Poss.Add(new BL.Pos { Id = 1, Name = "Главный бухгалтер" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Заместитель главного бухгалтера" });
        //    context.Poss.Add(new BL.Pos { Id = 1, Name = "Заместитель директора по аудиту" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Старший специалист по финансовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 1, Name = "Специалист по финансовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Ассистент специалиста по финансовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Директор по консалтингу" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Старший специалист по корпоративным процедурам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Специалист по корпоративным процедурам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Ассистент cпециалиста по корпоративным процедурам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Заместитель директора по правовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Старший специалист по правовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Специалист по правовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Ассистент специалиста по правовым услугам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Заместитель директора по оценке" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Старший специалист по оценке" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Специалист по оценке" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Ассистент специалиста по оценке" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Инспектор по кадрам" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Охранник" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Системный администратор" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Бизнес-ассистент" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Курьер" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Механик-водитель" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Заместитель руководителя хозяйственного отдела по содержанию офиса" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Уборщик производственных и служебных помещений" });
        //    context.Poss.Add(new BL.Pos { Id = 2, Name = "Руководитель проектов" });



        //    //context.Emps.Add(new BL.Emp { Id = 1, LastName = "Анциферов", Name = "Константин", SName = "Олегович", DepId = 3, PosId = 2, Email = "antsiferov@befl.ru", EmailPass = "123" });
        //    //context.Emps.Add(new BL.Emp { Id = 2, LastName = "Кобзев", Name = "Дмитрий", SName = "", DepId = 3, PosId = 1, Email = "kobzev@befl.ru", EmailPass = "321" });


        //    base.Seed(context);
        //}

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
