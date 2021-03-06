﻿
using NUnit.Framework;
using ProjectManager.Controllers;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Test
{

    [TestFixture]
    public class ProjectControllerTest
    {
        [Test]
        public void TestGetProjects_Success()
        {
            var context = new MockProjectManagerEntities();
            var projects = new TestDbSet<DAC.Project>();
            projects.Add(new DAC.Project()
            {
                Project_ID = 1234,
                Project_Name = "MyProject",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(5),
                Priority = 3
            });
            projects.Add(new DAC.Project()
            {
                Project_ID = 12345,
                Project_Name = "MyProject",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(5),
                Priority = 3
            });
            context.Projects = projects;

            var controller = new ProjectController(new BC.ProjectBC(context));
            var result = controller.RetrieveProjects() as JSendResponse;

            Assert.IsNotNull(result);                     
            Assert.IsInstanceOf(typeof(List<Project>),result.Data);
            Assert.AreEqual((result.Data as List<Project>).Count, 2);
        }

        [Test]
        public void TestUpdateProjects_Success()
        {
            var context = new MockProjectManagerEntities();
            var projects = new TestDbSet<DAC.Project>();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = 418220.ToString(),
                First_Name = "Emp1",
                Last_Name = "Test",
                Project_ID = 111,
                Task_ID = 222,
                User_ID = 333
            });
            projects.Add(new DAC.Project()
            {
                Project_Name = "TestProjectManager",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(5),
                Priority = 2,
                Project_ID = 111
            });
            context.Projects = projects;
            context.Users = users;
            var testProject = new Models.Project()
            {
                ProjectId = 111,
                Priority = 3,
                NoOfCompletedTasks = 2,
                NoOfTasks = 5,
                ProjectName = "ProjectTest",
                ProjectStartDate = DateTime.Now,
                ProjectEndDate = DateTime.Now.AddDays(10),
                User = new User()
                {
                    EmployeeId = 584598.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = 111,
                    UserId = 333
                }
            };

            var controller = new ProjectController(new BC.ProjectBC(context));
            var result = controller.UpdateProjectDetails(testProject) as JSendResponse;

            Assert.IsNotNull(result);
            Assert.AreEqual((context.Projects.Local[0]).Project_Name.ToUpper(), "PROJECTTEST");
        }

        [Test]
        public void TestDeleteProjects_Success()
        {
            var context = new MockProjectManagerEntities();
            var projects = new TestDbSet<DAC.Project>();
            projects.Add(new DAC.Project()
            {
                Project_ID = 123,
                Project_Name = "PROJTEST",
                Priority = 1,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(5)
            });
            projects.Add(new DAC.Project()
            {
                Project_ID = 456,
                Project_Name = "PROJTEST2",
                Priority = 2,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(10)
            });
            context.Projects = projects;
            var controller = new ProjectController(new BC.ProjectBC(context));

            var testProject = new Models.Project()
            {
                ProjectId = 123,
                Priority = 3,
                NoOfCompletedTasks = 2,
                NoOfTasks = 5,
                ProjectName = "ProjectTest",
                ProjectStartDate = DateTime.Now,
                ProjectEndDate = DateTime.Now.AddDays(10),
                User = new User()
                {
                    EmployeeId = 584598.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = 123,
                    UserId = 123
                }
            };

            var result = controller.DeleteProjectDetails(testProject) as JSendResponse;
            Assert.IsNotNull(result);
            Assert.AreEqual(context.Projects.Local.Count, 1);
        }

        [Test]        
        public void TestInsertProject_NoProjectAsParameter()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee1",
                Last_Name = "test",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = null;
            var controller = new ProjectController(new BC.ProjectBC(context));
            //var result = controller.InsertProjectDetails(testProject) as JSendResponse;
            var ex = Assert.Throws<ArgumentNullException>(() => controller.InsertProjectDetails(testProject)) ;
            Assert.That(ex.Message, Is.Not.Null);
        }

        [Test]
        public void TestInsertProject_NegativeProjectId()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Employee2",
                Last_Name = "Test2",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = -234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.InsertProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);

        }

        [Test]       
        public void TestInsertProject_UserNullInProject()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "456789",
                First_Name = "Rahul",
                Last_Name = "Raj",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 222,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = null
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentNullException>(() => controller.InsertProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
           
        }

        [Test]        
        public void TestInsertProject_NegativeProjectIdInUser()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Anup",
                Last_Name = "Mondal",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.InsertProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestInsertProject_CompletedTasksGreater()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Anup",
                Last_Name = "Mondal",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 10,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = 234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentException>(() => controller.InsertProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestUpdateProject_NoProjectAsParameter()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Anup",
                Last_Name = "Mondal",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = null;
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentNullException>(() => controller.UpdateProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestUpdateProject_NegativeProjectId()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Anup",
                Last_Name = "Mondal",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = -234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.UpdateProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestUpdateProject_UserNullInProject()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee3",
                Last_Name = "Test3",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 222,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = null
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentNullException>(() => controller.UpdateProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestUpdateProject_NegativeProjectIdInUser()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.UpdateProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestUpdateProject_CompletedTasksGreater()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "584598",
                First_Name = "Anup",
                Last_Name = "Mondal",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 10,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = 234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));

            var ex = Assert.Throws<ArgumentException>(() => controller.UpdateProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestDeleteProject_NoProjectAsParameter()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = null;
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentNullException>(() => controller.DeleteProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
           
        }

        [Test]        
        public void TestDeleteProject_NegativeProjectId()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = -234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.DeleteProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestDeleteProject_UserNullInProject()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 222,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = null
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentNullException>(() => controller.DeleteProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]        
        public void TestDeleteProject_NegativeProjectIdInUser()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 4,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Anup",
                    LastName = "Mondal",
                    ProjectId = -234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArithmeticException>(() => controller.DeleteProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }

        [Test]
        public void TestDeleteProject_CompletedTasksGreater()
        {
            var context = new MockProjectManagerEntities();
            var users = new TestDbSet<DAC.User>();
            users.Add(new DAC.User()
            {
                Employee_ID = "123456",
                First_Name = "Employee4",
                Last_Name = "Test4",
                User_ID = 123,
                Task_ID = 123
            });
            context.Users = users;
            Models.Project testProject = new Models.Project()
            {
                ProjectId = 234,
                NoOfCompletedTasks = 10,
                NoOfTasks = 5,
                Priority = 1,
                ProjectEndDate = DateTime.Now.AddDays(10),
                ProjectStartDate = DateTime.Now,
                ProjectName = "TEST",
                User = new User()
                {
                    EmployeeId = 123.ToString(),
                    FirstName = "Employee4",
                    LastName = "Test4",
                    ProjectId = 234,
                    UserId = 123
                }
            };
            var controller = new ProjectController(new BC.ProjectBC(context));
            var ex = Assert.Throws<ArgumentException>(() => controller.DeleteProjectDetails(testProject));
            Assert.That(ex.Message, Is.Not.Null);
            
        }
    }
}
