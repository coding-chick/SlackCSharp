using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChick.SlackAPI.Data
{
    public class Login
    {
        public bool ok { get; set; }
        public Self self { get; set; }
        public Team team { get; set; }
        public List<Channel> channels { get; set; }
        public List<object> groups { get; set; }
        public List<Im> ims { get; set; }
        public List<User> users { get; set; }
        public List<Bot> bots { get; set; }
        public string svn_rev { get; set; }
        public int min_svn_rev { get; set; }
        public string url { get; set; }
    }
}
