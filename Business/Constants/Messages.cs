using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddMusic = "Music Added successfully!";

        public static string DeleteMusic = "Music Deleted successfully!";

        public static string UpdateMusic = "Music Updated successfully!";

        public static string MaintenanceTime = "System maintenance!";

        public static string MusicCountOfGenreError = "You have reached the limit for this genre!";

        public  static string MusicNameAlreadyExists="There is already another product with the same name";
        public static string AuthorizationDenied="Error";
    }
}
