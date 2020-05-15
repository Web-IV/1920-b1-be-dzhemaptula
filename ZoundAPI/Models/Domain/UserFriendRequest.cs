using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoundAPI.Models.Domain
{
    public class UserFriendRequest
    {
        [ForeignKey(nameof(RequestedToId))]
        public User RequestedTo { get; set; }
        public int RequestedToId { get; set; }

        [ForeignKey(nameof(RequestedFromId))]
        public User RequestedFrom { get; set; }
        public int RequestedFromId { get; set; }
        public Guid Token { get; set; }

        public UserFriendRequest(User requestedTo, User requestedFrom)
        {
            RequestedTo = requestedTo;
            RequestedFrom = requestedFrom;
            //Generates a token like "65a10c6e-5fd5-4f04-8175-8601cdb5ffcd"
            Token = Guid.NewGuid();
            RequestedToId = requestedTo.UserId;
            RequestedFromId = requestedFrom.UserId;
        }

        public UserFriendRequest()
        {
        }
    }
}
