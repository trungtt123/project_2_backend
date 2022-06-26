using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;
using WareHouse.Repository.Interfaces;

namespace WareHouse.Repository.Implementations
{
    public class OutputInfoRepository : IOutputInfoRepository
    {
        public OutputInfoEntity GetOutputInfo(int outputInfoId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var outputInfo = new OutputInfoEntity();

                outputInfo = dbcontext.outputInfo.FirstOrDefault(o => o.OutputInfoId == outputInfoId);


                return outputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<OutputProductEntity> GetProductInOutputInfo(int outputInfoId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var arr = dbcontext.outputProduct.ToList().FindAll(o => o.OutputInfoId == outputInfoId);

                return arr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<OutputProductEntity> GetProductInOutputById(int productBatchProductId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var arr = dbcontext.outputProduct.ToList().FindAll(o => o.ProductBatchProductId == productBatchProductId);

                return arr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool OutputInfoAddProduct(OutputProductEntity outputProductEntity)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var outputProduct = dbcontext.outputProduct.Add(outputProductEntity);
                if (outputProduct == null) return false;
                dbcontext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool OutputInfoUpdateProduct(OutputProductEntity newOutputProduct)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var outputProduct = dbcontext.outputProduct
                    .FirstOrDefault(o => o.Id == newOutputProduct.Id);
                if (outputProduct == null) return false;
                outputProduct.ProductQuantity = newOutputProduct.ProductQuantity;
                outputProduct.ProductBatchProductId = newOutputProduct.ProductBatchProductId;
                dbcontext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool OutputInfoRemoveProduct(int id)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var outputInfo = dbcontext.outputProduct
                    .FirstOrDefault(o => o.Id == id);

                if (outputInfo == null) return false;

                dbcontext.outputProduct.Remove(outputInfo);

                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CreateOutputInfo(OutputInfoEntity outputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                dbcontext.outputInfo.Add(outputInfo);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateOutputInfo(OutputInfoEntity newOutputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var outputInfo = dbcontext.outputInfo.FirstOrDefault(o => o.OutputInfoId == newOutputInfo.OutputInfoId);

                if (outputInfo != null)
                {
                    outputInfo.OutputInfoName = newOutputInfo.OutputInfoName;
                    outputInfo.OutputUpdateTime = newOutputInfo.OutputUpdateTime;
                    outputInfo.PickerId = newOutputInfo.PickerId;
                    outputInfo.SignatorId = newOutputInfo.SignatorId;
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
        public bool DeleteOutputInfo(OutputInfoEntity outputInfo)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.outputInfo.Remove(outputInfo);

                dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<OutputInfoEntity> GetListOutputInfo()
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var listOutputInfo = new List<OutputInfoEntity>();

                listOutputInfo = dbcontext.outputInfo.ToList();

                return listOutputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
