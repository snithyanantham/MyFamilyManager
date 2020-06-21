using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TransactionDto GetTransaction(Guid Id)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(Id);
            if (transaction != null)
            {
                return new TransactionDto
                {
                    FamilyId = transaction.FamilyId,
                    CategoryId = transaction.CategoryId,
                    SubCategoryId = transaction.SubCategoryId,
                    Amount = transaction.Amount
                };
            }
            return null;
        }

        public TransactionListDto GetTransactions()
        {
            var transactions = _unitOfWork.TransactionRepository.GetAll();
            TransactionListDto transactionList = new TransactionListDto
            {
                Transations = new List<TransactionDto>()
            };

            if (transactions != null)
            {
                foreach (var item in transactions)
                {
                    transactionList.Transations.Add(new TransactionDto
                    {
                        CategoryId = item.CategoryId,
                        FamilyId = item.FamilyId,
                        SubCategoryId = item.SubCategoryId,
                        Amount = item.Amount
                    });
                }
            }

            return transactionList;
        }

        public void SaveTransaction(TransactionDto transaction)
        {
            Transaction transactionEntity = new Transaction
            {
                FamilyId = transaction.FamilyId,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId,
                SubCategoryId = transaction.SubCategoryId
            };
            _unitOfWork.TransactionRepository.Insert(transactionEntity);
            _unitOfWork.Commit();
        }
    }
}
