using AndroidApi.Domain;
using AndroidApi.Domain.Models;
using AndroidApi.Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data
{
    public class DataInit
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInit(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User thomas = new User
                {
                    FirstName = "Thomas",
                    LastName = "Schuddinck",
                    Email = "thomas.schuddinck@mail.com"
                };
                User someUser = new User
                {
                    FirstName = "Some",
                    LastName = "User",
                    Email = "some.user@mail.com"
                };
                User anotherUser = new User
                {
                    FirstName = "Another",
                    LastName = "User",
                    Email = "another.user@mail.com"
                };
                User alsoAUser = new User
                {
                    FirstName = "Also",
                    LastName = "A User",
                    Email = "also.a.user@mail.com",
                };
                await CreateUser(thomas.Email, "P@ssword1");
                await CreateUser(someUser.Email, "P@ssword1");
                await CreateUser(anotherUser.Email, "P@ssword1");
                await CreateUser(alsoAUser.Email, "P@ssword1");
                _dbContext.users.Add(thomas);
                _dbContext.users.Add(someUser);
                _dbContext.users.Add(anotherUser);
                _dbContext.users.Add(alsoAUser);
                _dbContext.SaveChanges();
                //Tasks
                #region Tasks
                ToDoTask task1 = new ToDoTask
                {
                    TaskName = "bureau opruimen",
                    Description = "Opruimen van de bureau zodat er goed gestudeerd kan worden",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task2 = new ToDoTask
                {
                    TaskName = "planning opstellen",
                    Description = "Opstellen van een examenplanning voor periode 1",
                    TaskLabel = TaskLabel.ASAP,
                    IsCompleted = true,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task3 = new ToDoTask
                {
                    TaskName = "inplannen examen",
                    Description = "inplannen van een examen in januari",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = someUser.UserId
                };
                ToDoTask task4 = new ToDoTask
                {
                    TaskName = "voorzien examenlokaal",
                    Description = "voorzien lokaal mondelinge verdediging Naitive Apps 1: Android",
                    TaskLabel = TaskLabel.URGENT,
                    IsCompleted = false,
                    ResponsibleId = alsoAUser.UserId
                };
                ToDoTask task5 = new ToDoTask
                {
                    TaskName = "afnemen mondeling examen",
                    Description = "vragen geven en ondervragen van Naitive Apps 1: Android",
                    TaskLabel = TaskLabel.NOPRIOR,
                    IsCompleted = false,
                    ResponsibleId = anotherUser.UserId
                };
                ToDoTask task6 = new ToDoTask
                {
                    TaskName = "beoordelen mondeling examen",
                    Description = "beoordeling geven voor het examen van Naitive Apps 1: Android",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = anotherUser.UserId
                };

                ToDoTask task7 = new ToDoTask
                {
                    TaskName = "programmeren app",
                    Description = "programmeren van de android app",
                    TaskLabel = TaskLabel.URGENT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task8 = new ToDoTask
                {
                    TaskName = "pauzeren",
                    Description = "pauze nemen tussen het programmeren",
                    TaskLabel = TaskLabel.NOPRIOR,
                    IsCompleted = true,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task9 = new ToDoTask
                {
                    TaskName = "eten",
                    Description = "voldoende eten tussen het studeren",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };
                
                ToDoTask task10 = new ToDoTask
                {
                    TaskName = "scrum meeting",
                    Description = "meeting met projectleden voor daily scrum",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task11 = new ToDoTask
                {
                    TaskName = "trello opstellen",
                    Description = "Opstellen van het trello bord voor de volgende sprint",
                    TaskLabel = TaskLabel.ASAP,
                    IsCompleted = true,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task12 = new ToDoTask
                {
                    TaskName = "inplannen meeting klant",
                    Description = "inplannen van een meeting met de klant voor nabespreking van verleden sprint",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = someUser.UserId
                };
                ToDoTask task13 = new ToDoTask
                {
                    TaskName = "voorzien vergaderlokaal",
                    Description = "voorzien lokaal voor gesprek met klant",
                    TaskLabel = TaskLabel.URGENT,
                    IsCompleted = false,
                    ResponsibleId = alsoAUser.UserId
                };
                ToDoTask task14 = new ToDoTask
                {
                    TaskName = "testen voorzien",
                    Description = "schrijven van unit en ui testen voor android",
                    TaskLabel = TaskLabel.NOPRIOR,
                    IsCompleted = false,
                    ResponsibleId = anotherUser.UserId
                };
                ToDoTask task15 = new ToDoTask
                {
                    TaskName = "beoordelen teamwerking",
                    Description = "beoordeling geven aan teamleden voor de afgelopen sprint",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = anotherUser.UserId
                };

                ToDoTask task16 = new ToDoTask
                {
                    TaskName = "programmeren app",
                    Description = "programmeren van de android app",
                    TaskLabel = TaskLabel.URGENT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task17 = new ToDoTask
                {
                    TaskName = "organiseren teambuilding",
                    Description = "teambuilding organiseren om groepsgevoel de promoten",
                    TaskLabel = TaskLabel.NOPRIOR,
                    IsCompleted = true,
                    ResponsibleId = thomas.UserId
                };

                ToDoTask task18 = new ToDoTask
                {
                    TaskName = "presentatie voorbereiden",
                    Description = "dia presentatie voor klant voorbereiden",
                    TaskLabel = TaskLabel.IMPORTANT,
                    IsCompleted = false,
                    ResponsibleId = thomas.UserId
                };
                /*
                _dbContext.tasks.Add(task1);
                _dbContext.tasks.Add(task2);
                _dbContext.tasks.Add(task3);
                _dbContext.tasks.Add(task4);
                _dbContext.tasks.Add(task5);
                _dbContext.tasks.Add(task6);
                _dbContext.tasks.Add(task7);
                _dbContext.tasks.Add(task8);
                _dbContext.tasks.Add(task9);
                _dbContext.tasks.Add(task10);
                _dbContext.tasks.Add(task11);
                _dbContext.tasks.Add(task12);
                _dbContext.tasks.Add(task13);
                _dbContext.tasks.Add(task14);
                _dbContext.tasks.Add(task15);
                _dbContext.tasks.Add(task16);
                _dbContext.tasks.Add(task17);
                _dbContext.tasks.Add(task18);
                */
                #endregion

                //TaskTeams
                #region TaskTeams
                TaskTeam taskTeam1 = new TaskTeam
                {
                    TeamName = "Examen Native 1",
                    Description = "Taken te doen voor het examen van native 1",
                    OwnerId = thomas.UserId
                };
                taskTeam1.AddUser(thomas);
                taskTeam1.AddUser(anotherUser);
                taskTeam1.AddUser(someUser);
                taskTeam1.AddUser(alsoAUser);

                taskTeam1.AddTask(task1);
                taskTeam1.AddTask(task2);
                taskTeam1.AddTask(task3);
                taskTeam1.AddTask(task4);
                taskTeam1.AddTask(task5);
                taskTeam1.AddTask(task6);
                taskTeam1.AddTask(task7);
                taskTeam1.AddTask(task8);
                taskTeam1.AddTask(task9);

                TaskTeam taskTeam2 = new TaskTeam
                {
                    TeamName = "Sprint projecten 3",
                    Description = "sprint voor projecten 3 (andere owner)",
                    OwnerId = someUser.UserId
                };
                taskTeam2.AddUser(thomas);
                taskTeam2.AddUser(anotherUser);
                taskTeam2.AddUser(someUser);
                taskTeam2.AddUser(alsoAUser);

                taskTeam2.AddTask(task10);
                taskTeam2.AddTask(task11);
                taskTeam2.AddTask(task12);
                taskTeam2.AddTask(task13);
                taskTeam2.AddTask(task14);
                taskTeam2.AddTask(task15);
                taskTeam2.AddTask(task16);
                taskTeam2.AddTask(task17);
                taskTeam1.AddTask(task18);



                TaskTeam taskTeam3 = new TaskTeam
                {
                    TeamName = "Kamer opruimen",
                    Description = "Kamer opruimen",
                    OwnerId = thomas.UserId
                };

                TaskTeam taskTeam4 = new TaskTeam
                {
                    TeamName = "Nieuwe muis kopen",
                    Description = "Nieuwe vervangmuis nodig",
                    OwnerId = someUser.UserId
                };

                TaskTeam taskTeam5 = new TaskTeam
                {
                    TeamName = "Kleren kopen",
                    Description = "Het zijn nu solden",
                    OwnerId = anotherUser.UserId
                };

                TaskTeam taskTeam6 = new TaskTeam
                {
                    TeamName = "Bachelorproef voorbereiden",
                    Description = "spreekt voor zich",
                    OwnerId = thomas.UserId
                };

                TaskTeam taskTeam7 = new TaskTeam
                {
                    TeamName = "Stagecontract RealDolmen",
                    Description = "Ondertekenen voor stage",
                    OwnerId = someUser.UserId
                };

                TaskTeam taskTeam8 = new TaskTeam
                {
                    TeamName = "Inzenden Native Apps project",
                    Description = "Inzenden Android project Native Apps 1",
                    OwnerId = someUser.UserId
                };

                TaskTeam taskTeam9 = new TaskTeam
                {
                    TeamName = "Rusten na examens",
                    Description = "een welverdiende rust",
                    OwnerId = someUser.UserId
                };


                _dbContext.taskTeams.Add(taskTeam1);
                _dbContext.taskTeams.Add(taskTeam2);
                _dbContext.taskTeams.Add(taskTeam3);
                _dbContext.taskTeams.Add(taskTeam4);
                _dbContext.taskTeams.Add(taskTeam5);
                _dbContext.taskTeams.Add(taskTeam6);
                _dbContext.taskTeams.Add(taskTeam7);
                _dbContext.taskTeams.Add(taskTeam8);
                _dbContext.taskTeams.Add(taskTeam9);
                #endregion

                //Users
                _dbContext.SaveChanges();


            }
        }
    }
}
