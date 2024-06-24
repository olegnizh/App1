using App1.Models;
using Microsoft.EntityFrameworkCore;

AddUsers();

// Создаем контекст для выбора данных
using (var db = new App1.AppContext())
{
    /*var usersQuery =
        from user in db.Users
        where user.CompanyId == 2
        select user;

    var users = usersQuery.ToList();*/

    var users = db.Users.Include(u => u.Company).Where(u => u.CompanyId == 2);

    foreach (var user in users)
    {
        // Вывод Id пользователей
        Console.WriteLine($"{user.Id} - {user.Name} {user.CompanyId} - {user.Company.Name}");
    }
    Console.ReadKey();

}

Console.ReadKey();

static void AddUsers()
{
    // Использование EF
    using (var db = new App1.AppContext())
    {
        db.Database.EnsureCreated();

        // Заполняем данными
        var company1 = new Company { Name = "SF" };
        var company2 = new Company { Name = "VK" };
        var company3 = new Company { Name = "FB" };
        db.Companies.AddRange(company1, company2, company3);

        var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
        var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
        var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
        var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

        db.Users.AddRange(user1, user2, user3, user4);

        db.SaveChanges();
    }
}