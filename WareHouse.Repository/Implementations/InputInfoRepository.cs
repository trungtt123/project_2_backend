using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;
using WareHouse.Repository.Interfaces;

namespace WareHouse.Repository.Implementations
{
    public class InputInfoRepository : IInputInfoRepository
    {
        public InputInfoEntity GetInputInfo(int inputInfoId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var inputInfo = new InputInfoEntity();

                inputInfo = dbcontext.inputInfo.FirstOrDefault(o => o.InputInfoId == inputInfoId);


                return inputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductBatchEntity> GetProductBatchInInputInfo(int inputInfoId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var arr = dbcontext.productBatches.ToList().FindAll(o => o.InputInfoId == inputInfoId);

                return arr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool InputInfoAddProductBatch(int productBatchId, int inputInfoId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatch = dbcontext.productBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);
                if (productBatch == null) return false;


                if (productBatch.InputInfoId != 0 && productBatch.InputInfoId != null) return false;
                productBatch.InputInfoId = inputInfoId;
                dbcontext.SaveChanges();

                var inputInfo = dbcontext.inputInfo.FirstOrDefault(o => o.InputInfoId == inputInfoId);
                inputInfo.InputUpdateTime = DateTime.Now;
                dbcontext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InputInfoRemoveProductBatch(int productBatchId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatch = dbcontext.productBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);
                
                if (productBatch == null) return false;

                var inputInfo = dbcontext.inputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    dbcontext.SaveChanges();
                }

                productBatch.InputInfoId = null;
                dbcontext.SaveChanges();

                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CreateInputInfo(InputInfoEntity inputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                dbcontext.inputInfo.Add(inputInfo);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateInputInfo(InputInfoEntity newInputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var inputInfo = dbcontext.inputInfo.FirstOrDefault(o => o.InputInfoId == newInputInfo.InputInfoId);

                if (inputInfo != null)
                {
                    inputInfo.InputInfoName = newInputInfo.InputInfoName;
                    inputInfo.InputUpdateTime = newInputInfo.InputUpdateTime;
                    inputInfo.Shipper = newInputInfo.Shipper;
                    inputInfo.ReceiverUserId = newInputInfo.ReceiverUserId;
                    dbcontext.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteInputInfo(InputInfoEntity inputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.inputInfo.Remove(inputInfo);

                dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<InputInfoEntity> GetListInputInfo()
        {
            try
            {
                using var dbcontext = new MyDbContext();


                var listInputInfo = new List<InputInfoEntity>();

                listInputInfo = dbcontext.inputInfo.ToList();

                return listInputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
