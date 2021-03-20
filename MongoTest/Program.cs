using MongoDB.Driver;
using MongoTest.Entities;
using MongoTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();

            var users = userService.GetUsers();

            if (users.Count() == 0) 
            {
                userService.CreateUsers();
                users = userService.GetUsers();

                userService.WriteLine("Created users");

                userService.WriteUsers(users);
            }

            userService.WriteUsers(users);

            userService.UpdateFirstUser(users.First());
            users = userService.GetUsers();

            userService.WriteLine("Updated first user");

            userService.WriteUsers(users);

            userService.DeleteFirstUser(users.First());
            users = userService.GetUsers();

            userService.WriteLine("Deleted first user");

            userService.WriteUsers(users);

            var randomNumber = userService.GetRandomNumber(users.Count());

            var randomUser = userService.GetUserRandom(users.Where((x, index) => index.Equals(randomNumber)).First());

            userService.WriteLine("Random user");
            userService.WriteUsers(new List<User> { randomUser });

            Console.ReadKey();
        }
    }
}
