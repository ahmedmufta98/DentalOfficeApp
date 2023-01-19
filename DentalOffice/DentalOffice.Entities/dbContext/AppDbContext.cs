using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Entities.dbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<DentistOffice> DentistOffices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DentistOffice>().HasData(
                new DentistOffice
                {
                    Id = 1,
                    Name = "Ordinacija Gudić",
                    Address = "Vrbaska 55, Gornji Vakuf-Uskoplje",
                    Email = "ordinacija_gudic@gmail.com",
                    Phone = "030225883",
                    Description = "Ordinacija Gudić uspješno posluje već 20 godina na teritoriji Gornjeg Vakufa-Uskoplja. U našem tim se sastoji od vrhunskih stomatologa, gdje nudimo razne usluge od operacija do običnih popravki zubi."
                }
            );

            modelBuilder.Entity<Dentist>().HasData(
                new Dentist
                {
                    Id = 1,
                    FirstName = "Armin",
                    LastName = "Gudić",
                    BirthDate = new DateTime(1990, 02, 20),
                    Phone = "030257520",
                    Email = "armin@gmail.com",
                    Active = true,
                    DentistOfficeId = 1,
                    Address = "Adresa1",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Image = File.ReadAllBytes("Images/dentist1.jpg")
                },
                 new Dentist
                 {
                     Id = 2,
                     FirstName = "Amina",
                     LastName = "Gudić",
                     BirthDate = new DateTime(1990, 01, 01),
                     Phone = "030257720",
                     Email = "amina@gmail.com",
                     Active = true,
                     DentistOfficeId = 1,
                     Address = "Adresa2",
                     Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                     Image = File.ReadAllBytes("Images/dentist2.jpg")
                 },
                  new Dentist
                  {
                      Id = 3,
                      FirstName = "Harun",
                      LastName = "Hodžić",
                      BirthDate = new DateTime(1993, 02, 28),
                      Phone = "030251520",
                      Email = "harun@gmail.com",
                      Active = true,
                      DentistOfficeId = 1,
                      Address = "Adresa3",
                      Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                      Image = File.ReadAllBytes("Images/dentist3.jpg")
                  },
                   new Dentist
                   {
                       Id = 4,
                       FirstName = "Ahmed",
                       LastName = "Muftić",
                       BirthDate = new DateTime(1980, 03, 21),
                       Phone = "030259520",
                       Email = "ahmed@gmail.com",
                       Active = true,
                       DentistOfficeId = 1,
                       Address = "Adresa4",
                       Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                       Image = File.ReadAllBytes("Images/dentist4.jpg")
                   }
                );

            modelBuilder.Entity<Treatment>().HasData(
                new Treatment
                {
                    Id = 1,
                    Name = "Popravka zuba",
                    Price = 20,
                    TimeRequiredInMinutes = 20,
                    Image = File.ReadAllBytes("Images/teethfixing.jpg")
                },
                new Treatment
                {
                    Id = 2,
                    Name = "Vađenje zuba",
                    Price = 30,
                    TimeRequiredInMinutes = 30,
                    Image = File.ReadAllBytes("Images/teethremoval.jpg")
                },
                new Treatment
                {
                    Id = 3,
                    Name = "Operacija zuba",
                    Price = 400,
                    TimeRequiredInMinutes = 90,
                    Image = File.ReadAllBytes("Images/teethoperation.jpg")
                },
                new Treatment
                {
                    Id = 4,
                    Name = "Postavljanje fiksne proteze",
                    Price = 2000,
                    TimeRequiredInMinutes = 45,
                    Image = File.ReadAllBytes("Images/fixator.jpg")
                },
                new Treatment
                {
                    Id = 5,
                    Name = "Hollywood smile",
                    Price = 10000,
                    TimeRequiredInMinutes = 120,
                    Image = File.ReadAllBytes("Images/hollywoodsmile.jpg")
                }
                );

            User admin = new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Username = "admin",
                Email = "admin@gmail.com",
                Phone = "-",
                Address = "-",
                Gender = Enums.Gender.Male,
                Role = Enums.Role.Admin
            };
            admin.PasswordSalt = HashGenerator.HashGenerator.GenerateSalt();
            admin.PasswordHash = HashGenerator.HashGenerator.GenerateHash(admin.PasswordSalt, "Admin1234!");

            User client1 = new()
            {
                Id = 2,
                FirstName = "Client1",
                LastName = "Client1",
                Username = "client1",
                Email = "client1@gmail.com",
                Phone = "030224421",
                Address = "Test",
                Gender = Enums.Gender.Male,
                Role = Enums.Role.Client
            };
            client1.PasswordSalt = HashGenerator.HashGenerator.GenerateSalt();
            client1.PasswordHash = HashGenerator.HashGenerator.GenerateHash(client1.PasswordSalt, "Client11234!");

            User client2 = new()
            {
                Id = 3,
                FirstName = "Client2",
                LastName = "Client2",
                Username = "client2",
                Email = "client2@gmail.com",
                Phone = "030224422",
                Address = "Test1",
                Gender = Enums.Gender.Female,
                Role = Enums.Role.Client
            };
            client2.PasswordSalt = HashGenerator.HashGenerator.GenerateSalt();
            client2.PasswordHash = HashGenerator.HashGenerator.GenerateHash(admin.PasswordSalt, "Client21234!");

            User client3 = new()
            {
                Id = 4,
                FirstName = "Client3",
                LastName = "Client3",
                Username = "client3",
                Email = "client3@gmail.com",
                Phone = "030224452",
                Address = "Test2",
                Gender = Enums.Gender.Male,
                Role = Enums.Role.Client
            };
            client3.PasswordSalt = HashGenerator.HashGenerator.GenerateSalt();
            client3.PasswordHash = HashGenerator.HashGenerator.GenerateHash(client3.PasswordSalt, "Client31234!");

            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<User>().HasData(client1);
            modelBuilder.Entity<User>().HasData(client2);
            modelBuilder.Entity<User>().HasData(client3);

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment
               {
                   Id = 1,
                   Start = new DateTime(2023, 01, 05, 13, 00, 00),
                   End = new DateTime(2023, 01, 05, 13, 20, 00),
                   TreatmentId = 1,
                   UserId = 2,
                   DentistId = 1
               },
               new Appointment
               {
                   Id = 2,
                   Start = new DateTime(2023, 01, 10, 12, 00, 00),
                   End = new DateTime(2023, 01, 10, 12, 30, 00),
                   TreatmentId = 2,
                   UserId = 2,
                   DentistId = 2
               },
               new Appointment
               {
                   Id = 3,
                   Start = new DateTime(2023, 01, 13, 13, 00, 00),
                   End = new DateTime(2023, 01, 13, 14, 30, 00),
                   TreatmentId = 3,
                   UserId = 3,
                   DentistId = 3
               },
                new Appointment
                {
                    Id = 4,
                    Start = new DateTime(2023, 01, 14, 14, 00, 00),
                    End = new DateTime(2023, 01, 14, 16, 00, 00),
                    TreatmentId = 5,
                    UserId = 4,
                    DentistId = 4
                },
                 new Appointment
                 {
                     Id = 5,
                     Start = new DateTime(2023, 01, 15, 14, 00, 00),
                     End = new DateTime(2023, 01, 15, 14, 45, 00),
                     TreatmentId = 4,
                     UserId = 3,
                     DentistId = 4
                 }
               );

            modelBuilder.Entity<Payment>().HasData(
              new Payment
              {
                  Id = 1,
                  Date = new DateTime(2023, 01, 14, 16, 15, 00),
                  Amount = decimal.Parse("10000"),
                  CardNumber = "1293810284902028",
                  TreatmentId = 5,
                  UserId = 4
              },
              new Payment
              {
                  Id = 2,
                  Date = new DateTime(2023, 01, 13, 14, 45, 00),
                  Amount = decimal.Parse("400"),
                  CardNumber = "1293810254132028",
                  TreatmentId = 3,
                  UserId = 3
              },
              new Payment
              {
                  Id = 3,
                  Date = new DateTime(2023, 01, 15, 15, 00, 00),
                  Amount = decimal.Parse("2000"),
                  CardNumber = "1293810254132028",
                  TreatmentId = 4,
                  UserId = 3
              }
               );

            modelBuilder.Entity<Rating>().HasData(
               new Rating
               {
                   Id = 1,
                   Rate = 5,
                   Comment = "Bezbolna usluga, svaka čast i sve pohvale!",
                   Date = new DateTime(2023, 01, 20, 11, 45, 00),
                   UserId = 2,
                   DentistId = 1
               },
                new Rating
                {
                    Id = 2,
                    Rate = 4,
                    Comment = "Sve u redu, stomatolog malo grub, ali ništa strašno!",
                    Date = new DateTime(2023, 01, 20, 11, 47, 00),
                    UserId = 2,
                    DentistId = 2
                },
                 new Rating
                 {
                     Id = 3,
                     Rate = 5,
                     Comment = "Operacija urađena bez ikakavih problema, svaka čast za tim!",
                     Date = new DateTime(2023, 01, 21, 12, 23, 00),
                     UserId = 3,
                     DentistId = 3
                 },
                 new Rating
                 {
                     Id = 4,
                     Rate = 3,
                     Comment = "Proces jako bolan, stomatolog nije imao razumijevanja prilikom rada za bol!",
                     Date = new DateTime(2023, 01, 21, 11, 13, 00),
                     UserId = 4,
                     DentistId = 4
                 },
                  new Rating
                  {
                      Id = 5,
                      Rate = 2,
                      Comment = "Stomatolog jako nekulturan, ali rad je solidno urađen!",
                      Date = new DateTime(2023, 01, 21, 11, 15, 00),
                      UserId = 3,
                      DentistId = 4
                  }
               );
        }
    }
}
