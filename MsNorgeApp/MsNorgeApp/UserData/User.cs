using MsNorgeApp.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsNorgeApp.User
{
    class User
    {
        private Guid UserId { get; set; }
        private String UserName { get; set; }
        private IList<Trip> TripList { get; set; }
    }
}
