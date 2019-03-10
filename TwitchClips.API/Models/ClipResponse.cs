using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchClips.API.Models
{
    public class ClipResponse
    {
        public List<Clip> data { get; set; }
        public Pagination pagination { get; set; }
    }
}
