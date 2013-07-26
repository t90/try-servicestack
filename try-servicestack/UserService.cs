using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace try_servicestack
{
    public class UserService : Service
    {

        public UserService()
        {
            // pretending we get everything from config and database
            DataSource = GetAllUsers();
            
        }


        public IEnumerable<User> DataSource;

        public List<User> Any(UserRequest request)
        {
            List<User> usersFilteredByRequestFields = FilterUsersByRequestFields(request).ToList();
            return usersFilteredByRequestFields;
        }

        public IEnumerable<User> FilterUsersByRequestFields(UserRequest request)
        {
            return (from user in DataSource
                    where 
                        !string.IsNullOrEmpty(request.Email) ? user.Email.ToLower() == request.Email.ToLower() : true
                        && !string.IsNullOrEmpty(request.Name) ? HasNameInFirstOrLast(request.Name, user) : true
                        && !string.IsNullOrEmpty(request.LastName) ? user.LastName.ToLower().Contains(request.LastName.ToLower()) : true
                        && !string.IsNullOrEmpty(request.FirstName) ? user.FirstName.ToLower().Contains(request.FirstName.ToLower()) : true
                    select 
                        user);
        }

        private bool HasNameInFirstOrLast(string name, User userRecrord)
        {
            name = name.ToLower();
            return (userRecrord.FirstName + " " + userRecrord.LastName).ToLower().Contains(name);
        }

        private IEnumerable<User> GetAllUsers()
        {
            return new[]
                       {
                           new User
                               {
                                   FirstName = "John",
                                   LastName = "Smith",
                                   Email = "jsmith@email.com"
                               }, 
                           new User()
                               {
                                   FirstName = "Bill",
                                   LastName = "McDonald",
                                   Email = "bmcdonald@email.com"
                               },
                           new User()
                               {
                                   FirstName = "George",
                                   LastName = "Augustinus",
                                   Email = "gaugustinus@email.com"
                               }
                       };
        }

    }
}