using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammTODO
{
    public class TaskDbLogic
    {
        public TaskDbLogic()
        { }
        public void AddNewTask()
        {
            Console.WriteLine("Дайте название задаче: ");
            var name = Console.ReadLine();
            Console.WriteLine("Опиишите задачу, ограничение в 200 символов: ");
            var description = Console.ReadLine();
            while (description.Length >= 200)
            {
                Console.WriteLine("Вы ввели слишком длинный текс для описания, сократите до 200 символов: ");
                description = Console.ReadLine();
            }
            SaveNewTask(name, description);
        }

        private void SaveNewTask(string name, string description)
        {            
            using(ApplicationContext db = new ApplicationContext())
            {
                var task = new TaskClass(name, description);
                db.Tasks.Add(task);
                db.SaveChanges();
                Console.WriteLine("Вы добавили новую задачу");
            }
        }

        public void LookAllTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList();
                Console.WriteLine("Список объектов:");
                foreach (TaskClass t in tasks)
                {
                    Console.WriteLine($"{t.Id} | {t.Name} | {t.IsCompleted} | {t.StartDateTime} | {t.Description}");
                }
            }
        }

        public void LookAllActiveTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList().Where(t => t.IsCompleted == false);
                Console.WriteLine("Список задач:");
                foreach (TaskClass t in tasks)
                {
                    Console.WriteLine($"{t.Id} | {t.Name} | {t.IsCompleted} | {t.StartDateTime} | {t.Description}");
                }
            }
        }

        public void ChangeTaskStatus()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Введите Id задачи: ");
                var isNum = int.TryParse(Console.ReadLine(), out int id);
                if(isNum == true)
                {
                    var tasks = db.Tasks.FirstOrDefault(p => p.Id == id);
                    if(tasks != null)
                    {
                        tasks.IsCompleted = true;
                        db.SaveChanges();
                        Console.WriteLine("Вы изменили статус задачи.");
                    }
                }
            }
        }

        internal void LookTasksInTime()
        {
            Console.Write("Введите год: ");
            var year = int.Parse(Console.ReadLine());
            Console.Write("Введите месяц: ");
            var month = int.Parse(Console.ReadLine());
            Console.Write("Введите день: ");
            var day = int.Parse(Console.ReadLine());

            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.Tasks.ToList().Where(p => p.StartDateTime.Year == year);
                if (tasks.Count() > 0)
                {
                    foreach (var t in tasks)
                    {
                        Console.WriteLine($"{t.Id} | {t.Name} | {t.IsCompleted} | {t.StartDateTime} | {t.Description}");
                    }
                }
                else
                    Console.WriteLine("В эту дату не запланированно никаких задач.");
            }
        }
    }
}
