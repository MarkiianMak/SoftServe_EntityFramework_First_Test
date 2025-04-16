using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;


Console.OutputEncoding = System.Text.Encoding.UTF8;
var context = new AutoLandDbContext();

var Cars = context.Cars;
var AvailibleCars = from Car in Cars where Car.Status == "Доступна" select Car;


var Users = context.Users;

var Rents = context.Rents;

var Payments = context.Payments;

var Rewiews = context.Rewiews;

var Insurances = context.Insurances;


Console.WriteLine("---------- AUTOLAND ---------");
do
{
    Console.WriteLine("[1] Орендую авто");
    Console.WriteLine("[2] Здаю авто в оренду");
    Console.WriteLine("[3] Список всіх машин");
    Console.WriteLine("[4] Залишити відгук");
    Console.WriteLine("[5] Застрахувати авто");
    Console.WriteLine("[6] Меню розробника");
    Console.WriteLine("[В]ихід");
    string choice = Console.ReadLine();
    if (int.TryParse(choice, out int a))
    {
        if (a == 1)
        {

            if (AvailibleCars.Count() == 0)
            {
                Console.WriteLine("Немає доступних машин");
                continue;
            }
            string name, email, licence;
            decimal stateFee  =0;
            Console.WriteLine("Введіть ваше ім'я:");
            name = Console.ReadLine();
            var checkIfUserExists = Users.SingleOrDefault(x => x.Name == name);
            if (checkIfUserExists == null)
            {
                Console.WriteLine("Введіть ваш email:");
                email = Console.ReadLine();
                Console.WriteLine("Введіть ID водійського посвідчення");
                licence = Console.ReadLine();

                Users.Add(new User
                {
                    Name = name,
                    Type = "Орендар",
                    Email = email,
                    Licence = licence,

                });
            }
            else
            {
                Console.WriteLine($"Добрий день {name}!");
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("---  Список Доступних Машин  ---");

            foreach (var item in AvailibleCars)
            {

                Console.WriteLine($" {item.Id}. {item.Brand} {item.Model} {item.Year} {item.FuelType}  ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            a = int.Parse(Console.ReadLine());
            Cars.Find(a).Status = "В оренді";
            Console.WriteLine("На скільки днів хочете орендувати авто?");
            int days = int.Parse(Console.ReadLine());

            if(days > 15) stateFee = 150;
            

            Console.WriteLine($"Оренда буде коштувати {days * Cars.Find(a).Price + stateFee}$");

            context.SaveChanges();
            checkIfUserExists = Users.SingleOrDefault(x => x.Name == name);
            Rents.Add(new Rent
            {
                User = checkIfUserExists,
                Car = Cars.Find(a),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(days),
                Price = days * Cars.Find(a).Price + stateFee,
                Status = "Очікує Підтвердження"
            });
            Payments.Add(new Payment
            {
                User = checkIfUserExists,
                Amount = days * Cars.Find(a).Price + stateFee,
                Type = "Бронювання",
                Date = DateTime.Now
            });
            context.SaveChanges();
        }
        else if (a == 2)
        {

            string name, email, licence;
            Console.WriteLine("Введіть ваше ім'я:");
            name = Console.ReadLine();
            var checkIfUserExists = Users.SingleOrDefault(x => x.Name == name);
            if (checkIfUserExists == null)
            {
                Console.WriteLine("Введіть ваш email:");
                email = Console.ReadLine();
                Console.WriteLine("Введіть ID водійського посвідчення");
                licence = Console.ReadLine();

                Users.Add(new User
                {
                    Name = name,
                    Type = "Власник",
                    Email = email,
                    Licence = licence,

                });
            }
            else
            {
                Console.WriteLine($"Добрий день {name}!");
            }
            string brand, model, bodyType, fuelType, numberPlate;
            int year, mileage, price;

            Console.WriteLine("Вкажіть бренд: ");
            brand = Console.ReadLine();
            Console.WriteLine("Вкажіть модель: ");
            model = Console.ReadLine();
            Console.WriteLine("Тип кузова: ");
            bodyType = Console.ReadLine();
            Console.WriteLine("Тип пального: ");
            fuelType = Console.ReadLine();
            Console.WriteLine("Номерні знаки: ");
            numberPlate = Console.ReadLine();
            Console.WriteLine("Рік випуску:");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("Пробіг:");
            mileage = int.Parse(Console.ReadLine());
            Console.WriteLine("Вкажіть ціну за день: ");
            price = int.Parse(Console.ReadLine());

            Cars.Add(new Car
            {
                Brand = brand,
                Model = model,
                BodyType = bodyType,
                FuelType = fuelType,
                NumberPlate = numberPlate,
                Year = year,
                Mileage = mileage,
                Status = "Доступна",
                Price = price,

            });
            context.SaveChanges();
        }
        else if (a == 3)
        {

            Console.WriteLine("---  Список Машин  ---");
            foreach (var item in Cars)
            {
                Console.WriteLine($" {item.Id}. {item.Brand} {item.Model} {item.Year} {item.FuelType}  ");
            }
            context.SaveChanges();
        }
        else if (a == 4)
        {
            string name, email, coment, model, nameOfRatedUser;
            double r;
            Console.WriteLine("Введіть ваше ім'я:");
            name = Console.ReadLine();
            var checkIfUserExists = Users.SingleOrDefault(x => x.Name == name);
            if (checkIfUserExists != null)
            {
                Console.WriteLine("Рейтинг? (від 0 до 5)");
                r = double.Parse(Console.ReadLine());
                Console.WriteLine("Коментар:");
                coment = Console.ReadLine();
                Console.WriteLine("Кому хочете надіслати відгук? (Авто чи Користувач)");
                string type = Console.ReadLine();
                if (type == "Авто")
                {
                    Console.WriteLine("Вкажіть модель авто:");
                    model = Console.ReadLine();

                    var changeCarRaiting = Cars.SingleOrDefault(x => x.Model == model);
                    changeCarRaiting.Raiting = r;

                    Rewiews.Add(new Rewiew
                    {
                        Sender = checkIfUserExists,
                        Car = changeCarRaiting,
                        Raiting = r,
                        Comment = coment,
                    });

                }
                else if (type == "Користувач")
                {
                    Console.WriteLine("Вкажіть ім'я користувача:");
                    nameOfRatedUser = Console.ReadLine();

                    var changeUserRaiting = Users.SingleOrDefault(x => x.Name == nameOfRatedUser);
                    changeUserRaiting.Raiting = r;

                    Rewiews.Add(new Rewiew
                    {
                        Sender = checkIfUserExists,
                        Reciever = changeUserRaiting,
                        Raiting = r,
                        Comment = coment,
                    });
                }

            }
            context.SaveChanges();
        }else if(a == 5)
        {
           
            Console.WriteLine("Вкажіть модель авто яке хочете застрахувати:");
            string  model = Console.ReadLine();

            var insuringCar = Cars.SingleOrDefault(x => x.Model == model);
            Console.WriteLine("Вкажіть тип страхування:");
            string type = Console.ReadLine();


            Console.WriteLine("Кількість днів:");
            int period = int.Parse(Console.ReadLine());

            Insurances.Add(new Insurance
            {
                Car = insuringCar,
                Type = type,    
                Period = period,
                CompanyName = "НАША СТРАХОВА КОМПАНІ",

            });
            context.SaveChanges();

        }

        else if (a == 6)
        {
            Console.WriteLine("[1] Зробити всі машини доступними");
            Console.WriteLine("[2] Показати всіх користувачів");
            Console.WriteLine("[3] Показати всі платежі");
            Console.WriteLine("[В]ихід");



            if (int.TryParse(Console.ReadLine(), out int c))
            {
                if (c == 1)
                {
                    foreach (var item in Cars)
                    {
                        item.Status = "Доступна";
                    }
                }
                else if (c == 2)
                {
                    foreach (var item in Users)
                    {
                        Console.WriteLine($"{item.Id}. {item.Name} - {item.Email} - {item.Type}");
                    }
                }
                else if (c == 3)
                {
                    foreach (var item in Payments)
                    {
                        Console.WriteLine($"{item.Id}. {item.User.Id} - {item.User.Name} - {item.Amount} - {item.Date}");
                    }
                }
                else
                {
                    break;
                }
            }
            context.SaveChanges();
        }else
        {
            break;
        }


    }
    else
    {
        break;
    }
    //Console.Clear();
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    context.SaveChanges();
} while (true);





