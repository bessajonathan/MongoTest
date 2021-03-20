using MongoDB.Driver;
using MongoTest.Context;
using MongoTest.Entities;
using System;
using System.Collections.Generic;

namespace MongoTest.Service
{
    public class UserService
    {
        private readonly MongoDbContext _context;

        public UserService()
        {
            var context = new MongoDbContext();
            _context = context;
        }
        public  void CreateUsers()
        {
            var users = new[]{
                new User("Steve", new DateTime(1812, 10, 8), new[] { "Administrator", "Manager" }),
                new User("Diana", new DateTime(1745, 09, 12), new[] { "Manager" }),
                new User("Helena", new DateTime(2016, 06, 18), new[] { "Administrator", "Manager" }),
                new User("Rubens", new DateTime(2006, 11, 6), new[] { "Administrator" }),
                new User("Creuza", new DateTime(1985, 04, 7), new[] { "Administrator" }),
                new User("Clóvis", new DateTime(1995, 01, 12), new[] { "Administrator" }),
            };

            _context.Users.InsertMany(users);
        }

        public User GetUserRandom(User user)
        {
            return _context.Users.Find(x => x.Id == user.Id).FirstOrDefault();
        }

        public int GetRandomNumber(int maxValue)
        {
            return new Random().Next(1, maxValue);
        }

        public void DeleteFirstUser(User user)
        {
            _context.Users.DeleteOne(x => x.Id == user.Id);
        }

        public void WriteUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.ToJson());
            }
        }

        public void UpdateFirstUser(User user)
        {
            user.Name = $"{user.Name} - updated";
            user.BirthDate.AddMinutes(2);

            _context.Users.ReplaceOne(x => x.Id == user.Id, user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Find(x => true).ToList();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
