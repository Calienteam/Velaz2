using Hackathon_VideoSharing_Platform.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hackathon_VideoSharing_Platform.Server.Hubs
{
    public class NotifucationHub : Hub
    {
        public async Task BroadcastNewVideoInfo(VideoMetaData videoMetaData)
        {
            await Clients.Others.SendAsync("OnBroadcastNewVideoInfo", videoMetaData);
            Debug.WriteLine("Send video: VideoMetaData:  \nTitle:{0}, \nPrice{1}, \n Address:{2}", videoMetaData.Title, videoMetaData.Price, videoMetaData.AddressAuthor);
        }
    }
}
