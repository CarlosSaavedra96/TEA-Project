using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Models
{
    public class UserModel : ModelBase
    {
        public UserModel ()
        {
            name = "User";
        }

        public List<string[]> getUserByUserName (string username) {
            connection.Where("user_name ='"+ username+"'");
            return connection.Execute(name);
        }
    }
}