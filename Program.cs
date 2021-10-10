using System;
using System.Collections.Generic;
enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetListPersons
}

namespace HWHW
{
    class Program
    {
        static PersonList personList;
        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("----------------------------------------------------");
        }

        static void PrintListMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Get List Persons.");
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }

            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();

            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }



        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
            InputExitFromKeyboard();
        }

        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.WriteLine("Input: ");
                text = Console.ReadLine();
            }

            Console.Clear();
            PrintMenuScreen();
        }



        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisterStudent();

                Student student = CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static Student CreateNewStudent()
        {
            return new Student(InputName(),
             InputAddress(),
             InputCitizenID(),
             InputStudentID());
        }



        static string InputName()
        {
            Console.Write("Your_Name: ");

            return Console.ReadLine();
        }

        static string InputStudentID()
        {
            Console.Write("Student_ID: ");

            return Console.ReadLine();
        }

        static string InputAddress()
        {
            Console.Write("Your_Address: ");

            return Console.ReadLine();
        }

        static string InputCitizenID()
        {
            Console.Write("Citizen_ID: ");

            return Console.ReadLine();
        }



        static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");

            return int.Parse(Console.ReadLine());
        }

        static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");

            return int.Parse(Console.ReadLine());
        }

        static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }



        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }

    }

    class Student : Person
    {
        private string student_ID;

        public Student(string name, string address, string citizenID, string studentID)
        : base(name, address, citizenID)
        {
            this.student_ID = studentID;
        }

    }
    class Person
    {
        protected string Your_name;
        protected string address;
        protected string citizen_ID;

        public Person(string name, string address, string citizenID)
        {
            this.Your_name = name;
            this.address = address;
            this.citizen_ID = citizenID;
        }

        public string GetName()
        {
            return this.Your_name;
        }

    }

    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("---------------------");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Your_Name: {0} \nType: Student \n", person.GetName());
                }

            }
        }
    }
}