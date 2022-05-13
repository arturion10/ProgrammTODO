using ProgrammTODO;

while (true)
{
    Console.WriteLine("Меню:\n 1 - Добавить новую задачу\n" +
                              " 2 - Посмотреть список всех задач\n" +
                              " 3 - Просматривать список активных задач\n" +
                              " 4 - Поменять статус задачи на выполнено\n" +
                              " 5 - Список задач за определенную дату\n" +
                              " 6 - Закрыть программу");
    var key = Console.ReadLine();
    if (key == "6")
        break;
    DoKey(key);
}

void DoKey(string? key)
{
    var task = new TaskDbLogic();
    switch (key)
    {
        case "1":
            task.AddNewTask();
            break;
        case "2":
            task.LookAllTask();
            break;
        case "3":
            task.LookAllActiveTask();
            break;
        case "4":
            task.ChangeTaskStatus();
            break;
        case "5":
            task.LookTasksInTime();
            break;
    }      
}