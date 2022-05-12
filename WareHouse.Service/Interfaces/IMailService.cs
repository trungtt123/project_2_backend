using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;

namespace WareHouse.Service.Interfaces
{
    public interface IMailService
    {
        public Task<bool> SendMail(EmailForm email, EmailAccount systemEmail);
    }
}
