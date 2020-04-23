using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public interface ITripDAO
    {
        List<Trip> RetrieveTrips(User.User user);
    }

    public class TripDAO : ITripDAO
    {
        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }

        public List<Trip> RetrieveTrips(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

    }
}
