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
        private readonly MyDbContext _dbcontext;

        public OutputInfoRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public OutputInfoEntity GetOutputInfo(int outputInfoId)
        {
            try
            {
                var outputInfo = new OutputInfoEntity();

                outputInfo = _dbcontext.OutputInfo.FirstOrDefault(o => o.OutputInfoId == outputInfoId);


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
                var arr = _dbcontext.OutputProduct.ToList().FindAll(o => o.OutputInfoId == outputInfoId);

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
                
                var arr = _dbcontext.OutputProduct.ToList().FindAll(o => o.ProductBatchProductId == productBatchProductId);

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
               
                var outputProduct = _dbcontext.OutputProduct.Add(outputProductEntity);
                if (outputProduct == null) return false;
                _dbcontext.SaveChanges();

                var outputInfo = _dbcontext.OutputInfo.FirstOrDefault(o => o.OutputInfoId == outputProductEntity.OutputInfoId);
                if (outputInfo != null)
                {
                    outputInfo.OutputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }


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
                
                var outputProduct = _dbcontext.OutputProduct
                    .FirstOrDefault(o => o.Id == newOutputProduct.Id);
                if (outputProduct == null) return false;
                outputProduct.ProductQuantity = newOutputProduct.ProductQuantity;
                outputProduct.ProductBatchProductId = newOutputProduct.ProductBatchProductId;
                _dbcontext.SaveChanges();

                var outputInfo = _dbcontext.OutputInfo.FirstOrDefault(o => o.OutputInfoId == outputProduct.OutputInfoId);
                if (outputInfo != null)
                {
                    Console.WriteLine("abc");
                    outputInfo.OutputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

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
               
                var outputInfo = _dbcontext.OutputProduct
                    .FirstOrDefault(o => o.Id == id);

                if (outputInfo == null) return false;

                var outputInfoTmp = _dbcontext.OutputInfo.FirstOrDefault(o => o.OutputInfoId == outputInfo.OutputInfoId);
                if (outputInfoTmp != null)
                {
                    outputInfoTmp.OutputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

                _dbcontext.OutputProduct.Remove(outputInfo);

                _dbcontext.SaveChanges();

                

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
                _dbcontext.OutputInfo.Add(outputInfo);
                _dbcontext.SaveChanges();
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
                var outputInfo = _dbcontext.OutputInfo.FirstOrDefault(o => o.OutputInfoId == newOutputInfo.OutputInfoId);

                if (outputInfo != null)
                {
                    outputInfo.OutputInfoName = newOutputInfo.OutputInfoName;
                    outputInfo.OutputUpdateTime = newOutputInfo.OutputUpdateTime;
                    outputInfo.PickerId = newOutputInfo.PickerId;
                    outputInfo.SignatorId = newOutputInfo.SignatorId;
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
        public bool DeleteOutputInfo(OutputInfoEntity outputInfo)
        {
            try
            {
                
                _dbcontext.OutputInfo.Remove(outputInfo);

                _dbcontext.SaveChanges();

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
                var listOutputInfo = new List<OutputInfoEntity>();

                listOutputInfo = _dbcontext.OutputInfo.ToList();

                return listOutputInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
