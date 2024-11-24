

// ADO.NET (Usere Management)

using UsersManagement.Repositories;

var userRepository = new UsersRepository();
var usersCount = userRepository.Count;

if (usersCount == 0)
{
    // بعد از کرفتن این دو باید یوز جدید رو به سیستم اضافه بکنم
    Console.WriteLine("Create user");
    Console.WriteLine("----------------------");
    Console.Write("Username: ");
    var newUsername = Console.ReadLine();
	Console.Write("Password: ");
	var newPassword = Console.ReadLine();

    var result = userRepository.CreateUser(newUsername, newPassword);
}

while (true)
{
    Console.Clear();
    Console.Write("Username: ");
    var username = Console.ReadLine();
    Console.WriteLine("Password: ");
    var password = Console.ReadLine();

    if (userRepository.ValidateUser(username, password))
    {
        Console.WriteLine("Welcome to Accounting Application");
    }
    else
    {
        Console.WriteLine("Invalid username or password! Press any key to continue");
		Console.ReadKey();
	}
}

Console.ReadKey();
