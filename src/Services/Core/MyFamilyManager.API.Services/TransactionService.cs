using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public TransactionResponseDto GetTransaction(Guid Id)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(Id);
            if (transaction != null)
            {
                return new TransactionResponseDto
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
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            var subcategories = _unitOfWork.SubCategoryRepository.GetAll().ToList();

            TransactionListDto transactionList = new TransactionListDto
            {
                Transations = new List<TransactionResponseDto>()
            };

            if (transactions != null)
            {
                foreach (var item in transactions)
                {
                    transactionList.Transations.Add(new TransactionResponseDto
                    {
                        CategoryId = item.CategoryId,
                        FamilyId = item.FamilyId,
                        SubCategoryId = item.SubCategoryId,
                        CategoryName = categories.Where(x => x.Id.Equals(item.CategoryId)).Select(y => y.Name).FirstOrDefault(),
                        SubCategoryName = subcategories.Where(x => x.Id.Equals(item.SubCategoryId)).Select(y => y.Name).FirstOrDefault(),
                        TransactionDate = item.CreatedAt,
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
