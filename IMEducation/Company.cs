using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMEducation
{
    public class Company
    {
        public List<Order> _orders;

        public Company()
        {
            InicializeDefaultOrders();
        }

        private void InicializeDefaultOrders()
        {
            _orders = new List<Order>()
            {
                 new Order("Лiтарка", "Минск", "", 5),
                 new Order("БелКнига", "Минск", "", 9),
                 new Order("Книжный магазин", "Бобруйск", "", 3)
            };
        }

        public void Start()
        {
            Console.WriteLine("Выберите раздел: \r\n1. Зазказы \r\n2. Склад \r\n3. Сотрудники");

            string userChoice = Console.ReadLine();
                        
            bool isItNumber = int.TryParse(userChoice, out int userChoiceInt);

            if (!isItNumber)
            {
                Console.WriteLine("Введите число");
                Start();
                return;
            }

            switch (userChoiceInt)
            {
                case 1:
                    OrderProcessing();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    Start();
                    return;
            }
        }

        private void OrderProcessing()
        {
            Console.WriteLine("Выберите действие: \r\n1. Добавить заказ \r\n2. Закрыть заказ \r\n3. Просмотреть открытые заказы");

            string userChoice = Console.ReadLine();

            bool isItNumber = int.TryParse(userChoice, out int userChoiceInt);

            if (!isItNumber)
            {
                Console.WriteLine("Введите число");
                OrderProcessing();
                return;
            }

            switch (userChoiceInt)
            {
                case 1:
                    AddOrder();
                    break;
                case 2:
                    CloseOrder();
                    break;
                case 3:
                    ShowOrders();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    Start();
                    return;
            }

            OrderProcessing();
        }

        private void ShowOrders()
        {
            foreach (Order order in _orders)
            {
                int index = _orders.IndexOf(order);

                Console.WriteLine($"Заказ: {index + 1} \r\n" +
                    $"Название магазина: {order.ShopName} \r\n" +
                    $"Город: {order.City}\r\n" +
                    $"Название книги {order.BookName}\r\n" +
                    $"Количество {order.Amount}");

                Console.WriteLine();
            }
        }

        private void CloseOrder()
        {
            Console.WriteLine("Введите индекс заказа");

            string userChoice = Console.ReadLine();

            bool isItNumber = int.TryParse(userChoice, out int indexOrder);

            if (!isItNumber)
            {
                Console.WriteLine("Введите число");
                CloseOrder();
                return;
            }

            if (indexOrder > _orders.Count || indexOrder < 1)
            {
                Console.WriteLine("Неверно указан номер заказа");
                CloseOrder();
                return;
            }

            _orders.RemoveAt(indexOrder - 1);
        }

        private void AddOrder()
        {
            Console.WriteLine("Введите название магазина");

            string shopName = Console.ReadLine();

            Console.WriteLine("Введите город");

            string city = Console.ReadLine();

            Console.WriteLine("Укажите название книги");

            string bookName = Console.ReadLine();

            Console.WriteLine("Укажите количество");

            int amount = int.Parse(Console.ReadLine());

            Order newOrder = new Order(shopName, city, bookName, amount);

            _orders.Add(newOrder);
        }
    }
}
