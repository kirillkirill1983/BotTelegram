using BotTelegram.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotTelegram.Service
{
    public class OperationService : IOperationServise
    {
        private readonly DataContex _contex;

        public OperationService(DataContex contex)
        {
            _contex = contex;
        }

        public async Task<Operation> GetLast(long userId)
        {
            return await _contex.Operations.OrderBy(x => x.dateTime).LastOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Operation>> GetOperations(long userId, DateTime date)
        {
            return await _contex.Operations.OrderBy(x => x.dateTime).Where(x => x.dateTime >= date).ToListAsync(); ;
        }
    }
}
