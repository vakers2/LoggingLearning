using System;
using System.IO;
using System.Text.RegularExpressions;
using LoggingLearning.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace LoggingLearning.Services
{
    public interface IBusinessTransactionService
    {
        BusinessTransactionResultViewModel ProcessSubmit(string username);
    }

    public class BusinessTransactionService : IBusinessTransactionService
    {
        private IHttpContextAccessor httpContextAccessor;
        private IRemoteServerService remoteServerService;

        public BusinessTransactionService(IHttpContextAccessor httpContextAccessor, IRemoteServerService remoteServerService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.remoteServerService = remoteServerService;
        }

        public BusinessTransactionResultViewModel ProcessSubmit(string username)
        {
            if (!Regex.IsMatch(username, "[a-zA-Z]+$"))
            {
                Log.ForContext("UserId", "123").Warning("User with ip {A} tried to submit username \"{B}\"", httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(), username);
                // Log.Warning($"User with ip {httpContextAccessor.HttpContext.Connection.RemoteIpAddress} tried to submit username \"{username}\"");
                return new BusinessTransactionResultViewModel("Your username contains restricted symbols, it should contain only letters!");
            }

            Log.Information("Sending newly submitted username \"{username}\" to remote server", username);

            try
            {
                remoteServerService.SendUsernameToRemoteServer(username);
                Log.Information("Submitting username \"{username}\" to remote server is successfully completed",
                    username);
                return new BusinessTransactionResultViewModel();
            }
            catch (Exception e)
            {
                //Log.Error(e, "Error while sending submitted username \"{A}\" to remote server", username);
                throw new OutOfMemoryException("Not enough memory", e);
            }
        }
    }
}