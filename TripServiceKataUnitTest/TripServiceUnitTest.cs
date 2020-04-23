using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKataUnitTest
{
    [TestClass]
    public class TripServiceUnitTest
    {
        private User someone = new User();
        private Mock<ITripDAO> tripDao = new Mock<ITripDAO>();
        private User loggedUser = new User();


        [TestMethod]
        public void ShouldThrowExceptionWhenUserIsNotLogged()
        {
            //Arrange
            TripService tripService = new TripService(tripDao.Object);

            //Act
            Action action = () => { tripService.GetTripsByUser(someone, null); };

            //Assert
            action.Should().Throw<UserNotLoggedInException>();
        }

        [TestMethod]
        public void ShouldReturnEmptyTripListWhenUserHasNoFriend()
        {
            TripService tripService = new TripService(tripDao.Object);

            var result = tripService.GetTripsByUser(someone, loggedUser);

            result.Count.Should().Be(0);
        }

        [TestMethod]
        public void ShouldReturnEmptyTripListWhenUsersAreNotFriends()
        {
            var userWithFriends = new User();
            userWithFriends.AddFriend(new User());
            userWithFriends.AddFriend(new User());
            TripService tripService = new TripService(tripDao.Object);

            var result = tripService.GetTripsByUser(userWithFriends, loggedUser);

            result.Count.Should().Be(0);
        }

        [TestMethod]
        public void ShouldReturnUserTripListWhenUsersAreFriend()
        {
            var friend = new User();
            friend.AddFriend(loggedUser);
            friend.AddTrip(new Trip());
            friend.AddTrip(new Trip());

            tripDao.Setup(action => action.RetrieveTrips(friend)).Returns(friend.Trips());
            TripService tripService = new TripService(tripDao.Object);

            var result = tripService.GetTripsByUser(friend, loggedUser);

            result.Count.Should().Be(2);
        }
    }
}
