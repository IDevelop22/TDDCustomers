using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCustomers.API.Models;

namespace TDDCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {

        public static List<User> GetTestUsers()
        {
            return new List<User>(){

                  new User {
                         Name = "Test User 1",
                         Email= "test.user.1@example.com",
                         Address = new Address{
                                 Street="123 street",
                                 City = "Some City",
                                 ZipCode = "123"
                             }
                         },
                   new User {
                         Name = "Test User 2",
                         Email= "test.user.2@example.com",
                         Address = new Address{
                                 Street="124 street",
                                 City = "Some City",
                                 ZipCode = "123"
                             }
                         },
                    new User {
                         Name = "Test User 3",
                         Email= "test.user.3@example.com",
                         Address = new Address{
                                 Street="125 street",
                                 City = "Some City",
                                 ZipCode = "123"
                             }
                         }

                            };
        }
    }
}
