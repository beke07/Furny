using Furny.Common.Models;

namespace Furny.Model
{
    public class Notification : MongoEntityBase
    {
        public string Link { get; set; }

        public string Text { get; set; }

        public bool IsDone { get; set; }
    }
}
