using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder root = new Folder("root");
            CreateBaseFiles(root);

            menu(root);
        }

        static void CreateBaseFiles(Folder root)
        {
            Folder folder1 = new Folder("folder1");
            Folder folder2 = new Folder("folder2");
            TextFile textFile1 = new TextFile("Passwords");
            SomeFile file1 = new SomeFile("file1", 50000);
            SomeFile file2 = new SomeFile("newFile2", 34123);
            Folder folder3 = new Folder("newFolder3");
            TextFile textFile2 = new TextFile("newTextFile2");

            textFile1.text = "qwety1245\nMyPassword";
            textFile2.text = "some text in a text file";
            folder1.Add(textFile1);
            folder1.Add(file1);
            folder2.Add(textFile2);
            folder2.Add(file2);
            folder2.Add(folder3);
            root.Add(folder1);
            root.Add(folder2);
        }

        static void menu(Folder root)
        {
            Folder current = root;
            List<Folder> previous = new List<Folder>();

            Console.WriteLine(
                "1. Go to\n" +
                "2. Add\n" +
                "3. Back\n" +
                "4. Get size of\n" +
                "5. End program"
                );

            showContents(root);

            int choice = 0;
            bool choice_check;

            while (choice != 5)
            {
                do
                {
                    Console.Write("\nChoose a possible option: ");
                    string choice_input = Console.ReadLine();
                    choice_check = Int32.TryParse(choice_input, out choice);
                }
                while (choice_check == false || choice < 1 || choice > 5);
                try
                {
                    switch (choice)
                    {
                        case 1:
                            current = goTo(current, previous);
                            showContents(current);
                            break;

                        case 2:
                            add(current);
                            showContents(current);
                            break;

                        case 3:
                            current = previous.Last();
                            previous.RemoveAt(previous.Count-1);
                            showContents(current);
                            break;

                        case 4:
                            getSize(current);
                            break;

                        case 5:
                            return;
                    }
                }
                catch { }
            }
        }

        static Folder goTo(Folder root, List<Folder> previous)
        {
            Console.WriteLine("Enter destination folder");
            string name = Console.ReadLine();
            previous.Add(root);
            return (Folder)root.getChild(name);
        }

        static void add(Folder root)
        {
            Console.WriteLine("New Component type:");
            string newType = Console.ReadLine().ToLower();
            Console.WriteLine("Enter Component name:");
            string newName = Console.ReadLine();

            switch (newType)
            {
                case "folder":
                    root.Add(new Folder(newName));
                    break;

                case "textfile":
                    root.Add(new TextFile(newName));

                    Console.WriteLine("Enter TextFile contents");
                    root.getTextFile(newName).text = Console.ReadLine();
                    break;

                case "somefile":
                    Console.WriteLine("Enter Component size:");
                    int newSize = Int32.Parse(Console.ReadLine());
                    root.Add(new SomeFile(newName, newSize));
                    break;
            }
        }

        static void getSize(Folder root)
        {
            Console.WriteLine("Enter name of component");
            string name = Console.ReadLine();
            if (name == "root")
                Console.WriteLine(root.GetSize());
            Console.WriteLine(root.getChild(name).GetSize());
        }

        static void showContents(Folder root)
        {
            Console.WriteLine("\nContents:\n");
            foreach (var component in root.getAllChildren())
                Console.WriteLine(component.name + "." + component.GetType().Name);
        }
    }
}