using System;
using Xunit;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Tests
{
    public class UserTest
    {
        private readonly User _user;
        public UserTest()
        {
            _user = new User();
        }

        [Fact]
        public void NewUserHasNoPostsFriendsEtc()
        {
            Assert.Equal(0, _user.Posts.Count);
            Assert.Equal(0, _user.Friends.Count);
            Assert.Equal(0, _user.FriendRequests.Count);
            Assert.Equal(0, _user.FavoriteRooms.Count);
        }

        [Fact]
        public void NewUserFirstNameTooLong()
        {
            Assert.Throws<ArgumentException>(() =>
                _user.Firstname =
                    "lasndljasndljsanldnasljdnsaljdnasljdnjlasndljasndjlsandjlansjldajsldnasljdnasljdnaljsndljasnjldnajl");
        }
        [Fact]
        public void NewUserEmailInvalid()
        {
            Assert.Throws<FormatException>(() =>
                _user.Email =
                    "aaa");
        }

        [Fact]
        public void NewUserLastNameTooLong()
        {
            Assert.Throws<ArgumentException>(() =>
                _user.Lastname =
                    "lasndljasndljsanldnasljdnsaljdnasljdnjlasndljasndjlsandjlansjldajsldnasljdnasljdnaljsndljasnjldnajl");
        }


    }
}
