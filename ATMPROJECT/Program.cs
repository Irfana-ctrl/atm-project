using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMPROJECT
{
    class User

    {
        public string CustId { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        

    }
   
    class Program
    {
        static void Main(string[] args)
        {

            List<User> users = new List<User>()
            {
                new User{CustId="12345",UserID="Irfana",Password="123",Balance=2000},
                new User{CustId="12346",UserID="Askar",Password="456",Balance=1000},
                new User{CustId="12347",UserID="Rayyan",Password="789",Balance=100},
            };
          
            Console.WriteLine("\tATM PROJECT");
            Login(users);
            Console.ReadLine();
        }
        public static void Login(List<User> users)
        {
            Console.Write("\nEnter Login ID: ");
            string login = Console.ReadLine();
            Console.Write("\nEnter Password: ");
            string pass = Console.ReadLine();
            var user = users.FirstOrDefault(p => p.UserID == login && p.Password == pass);
            
            if (user != null)
            {
                Console.WriteLine("Login Successful");
                Console.Clear();
                Console.WriteLine("\tHello " + login);

                Menu(user,users);

            }
            else
            {
                Console.WriteLine("Incorrect Details\nEnter correct details ");
                Login(users);
            }

        }
        public static void Menu(User user,List<User> users)
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("1.WITHDRAW CASH");
            Console.WriteLine("2.CASH TRANSFER");
            Console.WriteLine("3.DEPOSIT CASH");
            Console.WriteLine("4.DISPLAY BALANCE");
            Console.WriteLine("EXIT");
            Console.Write("\nEnter option: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Withdraw(user, users);
                
            }
            else if (input == "2")
                Transfer(users,user);
            else if (input == "3")
                Deposit(user,users);
            else if (input == "4")
                Balance(user);
            else
                Exit();

        }

        public static void Withdraw(User user,List<User> users)
        {
            Console.WriteLine("Current balance " + user.Balance);
            Console.WriteLine("Enter amount to withdraw");
            
            
            int withdrawAmount;
            bool isConversionSuccesfull = int.TryParse(Console.ReadLine(), out withdrawAmount);

            if (!isConversionSuccesfull)
            {
                Console.WriteLine("Please enter only numbers");
                Withdraw(user,users);
                return;
            }

            if(withdrawAmount <= user.Balance)
            {
                user.Balance = user.Balance - withdrawAmount;
                Console.WriteLine("Amount withdraw successfull\n\tNew Balance : " + user.Balance);
                Console.WriteLine("\nTransaction completed");
                Menu(user, users);
      
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
            

        }
        public static void Transfer(List<User> users,User user)
        {
            Console.WriteLine("Enter your Customer Id");
            string senderCustid = Console.ReadLine();
            Console.WriteLine("Enter the receiver's CustId");
            string receiverCustid = Console.ReadLine();
            var user1 = users.Exists(p =>p.CustId == receiverCustid);
            var user4=users.Exists(p => p.CustId == senderCustid);

            if (user1 != true || user4!=true)
                Console.WriteLine("Customer doesnot exist");
            else
            {
                Console.WriteLine("Enter the amount to transfer");
                int transferAmount;
                bool isConversionSuccesfull = int.TryParse(Console.ReadLine(), out transferAmount);
                if (!isConversionSuccesfull)
                {
                    Console.WriteLine("Please enter only numbers");
                    Transfer(users, user);
                }
                                  
               var user2 = users.FirstOrDefault(p =>p.CustId == senderCustid);
               var user3 = users.FirstOrDefault(p => p.CustId == receiverCustid);
                if (user2.Balance >= transferAmount)
                {
                    Console.WriteLine("You have sufficient balance");
                    user2.Balance -= transferAmount;
                    user3.Balance += transferAmount;
                    Console.WriteLine("Amount transfered successfully");
                    Console.WriteLine("Your Balance: " + user2.Balance);

                    Console.WriteLine("Receivers balance: " + user3.Balance);

                    Menu(user, users);
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                    Transfer(users, user);
                }
            }
        }
            

        
        public static void Deposit(User user,List<User> users)
        {
            Console.WriteLine("Current balance " + user.Balance);
            Console.WriteLine("\nEnter amount to deposit");
         
            int depositAmount;
            bool isConversionSuccesfull = int.TryParse(Console.ReadLine(), out depositAmount);

            if (!isConversionSuccesfull)
            {
                Console.WriteLine("Please enter only numbers");
                Deposit(user,users);
            }

                user.Balance = user.Balance + depositAmount;
                Console.WriteLine("Amount deposited successfully\n New Balance : " + user.Balance);
                Console.WriteLine("Transaction Completed");
                Menu(user, users);
            

        }
        public static void Balance(User user)
        {
            Console.WriteLine("Current balance in your account: " + user.Balance);

        }
        public static void Exit()
        {
            return;
           
        }

    }
}

