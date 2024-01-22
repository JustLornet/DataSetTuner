var testTask = new Task(() => Console.WriteLine("test"));

// var task1 = testReturnAsyncTaskConsole();

var task = testReturnTask();
Console.WriteLine(11);
Console.WriteLine(12);
task.Wait();






Console.ReadLine();

void testReturnVoid ()
{
    return;
}

Task testReturnTask()
{
    Console.WriteLine(nameof(testReturnTask));
    var task = new Task(() => Console.WriteLine("test2"));

    return task;
}


Task testReturnAsyncTask()
{
    Console.WriteLine(1);
    Console.WriteLine(nameof(testReturnAsyncTask));

    var task = Task.Delay(1000000);

    Console.WriteLine(2);
    Console.WriteLine(nameof(testReturnAsyncTask));

    return task;
}

async Task testReturnAsyncTaskConsole()
{
    Console.WriteLine(111);
    await Task.Run(() => Console.WriteLine("test2"));
    Console.WriteLine(112);
}


