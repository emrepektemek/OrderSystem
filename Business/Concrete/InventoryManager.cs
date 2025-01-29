using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InventoryManager : IInventoryService
    {
        IInventoryDal _inventoryDal;


        public InventoryManager(IInventoryDal inventoryDal)
        {
            _inventoryDal = inventoryDal;
        }

        public IDataResult<List<InventoryReportDto>> GetInventoryReports()
        {
           return new SuccessDataResult<List<InventoryReportDto>> (_inventoryDal.GetInventoryReports());
        }


    }
}
