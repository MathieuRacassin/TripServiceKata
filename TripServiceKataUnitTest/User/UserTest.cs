using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.User;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace TripServiceKata.User.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ShouldReturnFalseWhenUserHasNoFriend()
        {
            User user = new User();
            User noFriendUser = new User();

            var result = user.IsFriendWith(noFriendUser);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueWhenUsersAreFriends()
        {
            User user = new User();
            User userFriend = new User();
            user.AddFriend(userFriend);

            var result = user.IsFriendWith(userFriend);

            result.Should().BeTrue();
        }
    }
}