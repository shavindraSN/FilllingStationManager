using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingStationManager.Classes.UserAuthentication
{
    class User
    {
        String username;
        String firstName;
        String lastName;
        String userType;
        String designation;

        /// <summary>
        /// This method allow users to be validated. This ensure user is registered and
        /// authorized to log in to the system.
        /// </summary>
        /// <param name="username">String variable that holds users entered username</param>
        /// <param name="password">String</param>
        /// <returns>
        /// Type User, instance of object or null
        /// if users credentials are correct user object is returned else null is returned.
        /// </returns>
 
        public User login(String username, String password)
        {
            
            /**
             * Note: Clear these comments after implementing the method
             * 1. Check user name and password whether they are empty or not
             * 2. Pass username and password as parameters to login DB function
             * 3. Check the returned values.
             * 4. If is returns not null set set member variables with users details
             * 5. Return User object
             * 6. If SQL function returned null set return null object
             */
            User user = new User();

            return user;
        }
    }
}
