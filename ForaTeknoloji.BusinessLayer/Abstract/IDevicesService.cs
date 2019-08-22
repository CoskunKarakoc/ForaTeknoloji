using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDevicesService
    {
        List<Devices> GetAllDevices();
        Devices GetById(int id);
        Devices AddDevice(Devices devices);
        void DeleteDevice(Devices devices);
        Devices UpdateDevice(Devices devices);
    }
}
