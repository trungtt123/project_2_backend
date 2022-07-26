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
        private readonly MyDbContext _dbcontext;

        public InputInfoRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public InputInfoEntity GetInputInfo(int inputInfoId)
        {
            try
            {
               
                var inputInfo = new InputInfoEntity();

                inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == inputInfoId);


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
                
                var arr = _dbcontext.ProductBatches.ToList().FindAll(o => o.InputInfoId == inputInfoId);

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
                
                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);
                if (productBatch == null) return false;


                if (productBatch.InputInfoId != 0 && productBatch.InputInfoId != null) return false;
                productBatch.InputInfoId = inputInfoId;
                _dbcontext.SaveChanges();

                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == inputInfoId);
                inputInfo.InputUpdateTime = DateTime.Now;
                _dbcontext.SaveChanges();

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
              
                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);
                
                if (productBatch == null) return false;

                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

                productBatch.InputInfoId = null;
                _dbcontext.SaveChanges();

                

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
                _dbcontext.InputInfo.Add(inputInfo);
                _dbcontext.SaveChanges();
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
                
                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == newInputInfo.InputInfoId);

                if (inputInfo != null)
                {
                    inputInfo.InputInfoName = newInputInfo.InputInfoName;
                    inputInfo.InputUpdateTime = newInputInfo.InputUpdateTime;
                    inputInfo.Shipper = newInputInfo.Shipper;
                    inputInfo.ReceiverUserId = newInputInfo.ReceiverUserId;
                    _dbcontext.SaveChanges();
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
               
                _dbcontext.InputInfo.Remove(inputInfo);

                _dbcontext.SaveChanges();

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
               
                var listInputInfo = new List<InputInfoEntity>();

                listInputInfo = _dbcontext.InputInfo.ToList();

                return listInputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
