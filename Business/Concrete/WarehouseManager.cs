using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        IWarehouseDal _warehouseDal;

        public WarehouseManager(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;   
        }
        public Warehouse GetWarehouseById(int id)
        {
            return _warehouseDal.Get(w => w.Id == id);
        }
    }
}
