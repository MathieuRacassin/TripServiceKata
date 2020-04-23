using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private readonly ITripDAO _tripDao;

        public TripService(ITripDAO tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User.User user, User.User loggedUser = null)
        {
            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }
            if (user.IsFriendWith(loggedUser))
            {
                return _tripDao.RetrieveTrips(user);
            }
            return new List<Trip>();
        }
    }
}
