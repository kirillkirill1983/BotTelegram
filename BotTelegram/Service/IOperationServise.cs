using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotTelegram.Model;

namespace BotTelegram.Service
{
    public interface IOperationServise
    {
        Task<Operation> GetLast(long userId);
        Task<List<Operation>> GetOperations(long userId, DateTime dateTime);
    }
}
