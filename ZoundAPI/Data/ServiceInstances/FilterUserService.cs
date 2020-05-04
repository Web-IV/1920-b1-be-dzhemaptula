using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZoundAPI.DTOs;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.ServiceInstances
{
    public class FilterUserService
    {
        public UserDto ConvertToDto(User user)
        {
            return new UserDto(user.UserId, user.Email, user.Username, user.Firstname, user.Lastname);
        }

        public List<UserDto> ConvertMultipleUsersToDtoList(ICollection<User> users)
        {
            List<UserDto> result = new List<UserDto>();
            foreach (var user in users)
            {
                result.Add(new UserDto(user.UserId, user.Email, user.Username, user.Firstname, user.Lastname));
            }

            return result;
        }
    }
}
