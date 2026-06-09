using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
namespace PasswordManager
{
    class Program
    {
        /*
        [password manager]
        - list all passwords
        - add new password
        - delete password
        - update password
        - get password by name
        - save passwords to file
        - read passwords from file
        - password format:
        websitename=password
        */
        private static readonly Dictionary<string, string> _passwords = new();
        static void Main(string[] args)
        {
            ReadPasswordsFromFile();
            while(true)
            {
                Console.WriteLine("Password Manager");
                Console.WriteLine("1. List all passwords");
                Console.WriteLine("2. Add new password");
                Console.WriteLine("3. Delete password");
                Console.WriteLine("4. Update password");
                Console.WriteLine("5. Get password by name");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------");
                switch(choice)
                {
                    case 1:
                        ListPasswords();
                        break;
                    case 2:
                        AddPassword();
                        break;
                    case 3:
                        DeletePassword();
                        break;
                    case 4:
                        UpdatePassword();
                        break;
                    case 5:
                        GetPasswordByName();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("------------------------------");

            }
        }
private static void GetPasswordByName()
        {
            Console.Write("Enter website name: ");
            var websiteName = Console.ReadLine();
            if(!_passwords.ContainsKey(websiteName))
            {
                Console.WriteLine("Password for this website does not exist");
                return;
            }
            Console.WriteLine($"{websiteName}={_passwords[websiteName]}");
        }

        private static void UpdatePassword()
        {
            Console.Write("Enter website name: ");
            var websiteName = Console.ReadLine();
            if(!_passwords.ContainsKey(websiteName))
            {
                Console.WriteLine("Password for this website does not exist");
                return;
            }
            Console.Write("Enter new password: ");
            var password = Console.ReadLine();
            _passwords[websiteName] = password;
            SavePasswordsToFile();
            Console.WriteLine("Password updated successfully");
        }
        

        private static void DeletePassword()
        {
            Console.Write("Enter website name: ");
            var websiteName = Console.ReadLine();
            if(!_passwords.ContainsKey(websiteName))
            {
                Console.WriteLine("Password for this website does not exist");
                return;
            }
            _passwords.Remove(websiteName);
            SavePasswordsToFile();
            Console.WriteLine("Password deleted successfully");
        }

        private static void AddPassword()
        {
            Console.Write("Enter website name: ");
            var websiteName = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            if(_passwords.ContainsKey(websiteName))
            {
                Console.WriteLine("Password for this website already exists");
                return;
            }
            _passwords.Add(websiteName, password);
            SavePasswordsToFile();
            Console.WriteLine("Password added successfully");
        }

        private static void ReadPasswordsFromFile()
        {
            if(File.Exists("passwords.txt"))
            {
                var passwordsLines = File.ReadAllText("passwords.txt");
                foreach(var line in passwordsLines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var equelIndex = line.IndexOf('=');
                        var appName = line.Substring(0, equelIndex);
                        var password = line.Substring(equelIndex + 1);
                        _passwords.Add(appName, PasswordEncryptionUtility.Decrypt(password));
                    }
                }
                    
                    
            }
            
        }

        public static void ListPasswords()
            {
                foreach(var password in _passwords)
                {
                    Console.WriteLine($"{password.Key}={password.Value}");
                }
                
            }
        private static void SavePasswordsToFile()
        {
            var sb = new StringBuilder();
            foreach(var password in _passwords)
                sb.AppendLine($"{password.Key}={PasswordEncryptionUtility.Encrypt(password.Value)}");
            
            File.WriteAllText("passwords.txt", sb.ToString());
            
        }
    }
}