

// ADO.NET (Usere Management)

using UsersManagement.Repositories;

var userRepository = new UsersRepository();
var usersCount = userRepository.Count;
// فاز اول یوزر وجود داره یا نه
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

// اکر یوزرنیم پسورد درست بود اجازه ادامه عملیات بده
while (true)
{
    Console.Clear();
    Console.Write("Username: ");
    var username = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();

    if (userRepository.ValidateUser(username, password))
    {
        Console.WriteLine("Welcome to Accounting Application");
        break;
    }
    else
    {
        Console.WriteLine("Invalid username or password! Press any key to continue");
		Console.ReadKey();
	}
}

while (true)
{
    Console.Clear();
    Console.WriteLine("Users Management");
    Console.WriteLine("-----------------------");
    Console.WriteLine("1. Add user");
	Console.WriteLine("2. Change password");
	Console.WriteLine("3. Delete user");
	Console.WriteLine("4. List user");
	Console.WriteLine("5. Exit");

    Console.WriteLine();
    Console.WriteLine("Select an option: ");
    var option = Console.ReadLine();

    if (int.TryParse(option, out var parsedOption))
    {
        switch (parsedOption)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("");
                var newUsername = Console.ReadLine();
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}

Console.ReadKey();
