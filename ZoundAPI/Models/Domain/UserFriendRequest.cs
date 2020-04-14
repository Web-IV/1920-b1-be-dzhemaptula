using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoundAPI.Models.Domain
{
    public class UserFriendRequest
    {
        [ForeignKey(nameof(RequestedToID))]
        public User ReuqestedTo { get; set; }
        public int RequestedToID { get; set; }

        [ForeignKey(nameof(RequestedFromID))]
        public User RequestedFrom { get; set; }
        public int RequestedFromID { get; set; }
        public Guid Token { get; set; }

        public UserFriendRequest(User reuqestedTo, User requestedFrom)
        {
            ReuqestedTo = reuqestedTo;
            RequestedFrom = requestedFrom;
            //Generates a token like "65a10c6e-5fd5-4f04-8175-8601cdb5ffcd"
            Token = Guid.NewGuid();
            RequestedToID = reuqestedTo.UserId;
            RequestedFromID = requestedFrom.UserId;
        }

        public UserFriendRequest()
        {
        }
    }
}
