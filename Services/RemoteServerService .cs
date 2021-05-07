using System;
using System.Text.RegularExpressions;
using LoggingLearning.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace LoggingLearning.Services
{
    public interface IRemoteServerService
    {
        void SendUsernameToRemoteServer(string username);
    }

    public class RemoteServerService : IRemoteServerService
    {
        public void SendUsernameToRemoteServer(string username)
        {
            throw new ConnectionAbortedException("Remote server aborted connection");
        }
    }
}