using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TestSessionsWebApp.Models;

namespace TestSessionsWebApp.Utils
{
    public class SignalRUserHub : Hub
    {
        public static List<string> UserIds = new List<string>();

        public void Send(string userId)
        {
            string foundUserId = UserIds.Where(u => u == userId).FirstOrDefault();

            if(foundUserId == null)
            {
                UserIds.Add(userId);

                Clients.All.onUpdateUserList();
            }
        }

        public void LogOut(string userId)
        {
            string foundUserId = UserIds.Where(u => u == userId).FirstOrDefault();

            if (foundUserId != null)
            {
                UserIds.Remove(foundUserId);
                Clients.All.onLogOut(userId);

                Clients.All.onUpdateUserList();
            }
            
        }
    }
}