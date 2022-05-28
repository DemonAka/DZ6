using System;
using System.IO;
using System.Text;

namespace DZ6
{
    internal class Program
    {

        static void NoteCreate()
        {
            using (StreamWriter sw = new StreamWriter("employee.txt", true, Encoding.Unicode))
            {
                char key = 'д';

                do
                {
                    string note = string.Empty;

                    int id = 0;
                    Console.Write("\nВведите ID пользователя: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    note += $"{id}#";

                    note += $"{DateTime.Now}#";


                    Console.Write("\nВведите фамилию имя отчество автора записи: ");
                    note += $"{Console.ReadLine()}#";

                    int age = 0;
                    Console.Write("\nВведите возраст сотрудника: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    note += $"{age}#";

                    int heigh = 0;
                    Console.Write("\nВведите рост сотрудника: ");
                    heigh = Convert.ToInt32(Console.ReadLine());
                    note += $"{heigh}#";

                    Console.WriteLine($"\nЗапишите дату рождения Сотррудника в формате ДД.ММ.ГГГГ: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите место рождения сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    sw.WriteLine(note);
                    Console.Write("\nПродожить н/д"); key = Console.ReadKey(true).KeyChar;

                    sw.Flush();
                } while (char.ToLower(key) == 'д');
            }
        }

        static void NoteReader()
        {
            using (StreamReader sr = new StreamReader("employee.txt", Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"ID ",3} {"Время создания записи ",25} {"Фамилия Имя Отчество ",25} {"Возраст ",5} {"Рост ",5} {"Дата рождения ",12} {"Место рождения ",12}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],3} {data[1],25} {data[2],28} {data[3],5} {data[4],5} {data[5],13} {data[6],12}");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Для внесения данных в базу данных сотрудников нажмите 1 для просмотра баз данных нажмите 2");
            char chose = Console.ReadKey(true).KeyChar;
            {

                switch (chose)
                {
                    case '1':
                        NoteCreate();
                        break;
                    case '2':
                        NoteReader();
                        break;
                    default:
                        Console.WriteLine("Несуществующий вариант");
                        break;
                }
                Console.Write("\nПродожить н/д");


                Console.ReadKey();
            }

        }
    }
}