using MyFamilyManager.API.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface ITransactionService
    {
        TransactionDto GetTransaction(Guid Id);
        TransactionListDto GetTransactions();
        void SaveTransaction(TransactionDto transaction);
    }
}
