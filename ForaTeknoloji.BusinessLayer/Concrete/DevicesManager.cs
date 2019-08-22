using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DevicesManager : IDevicesService
    {
        private IDevicesDal _devicesDal;
        public DevicesManager(IDevicesDal devicesDal)
        {
            _devicesDal = devicesDal;
        }
        public Devices AddDevice(Devices devices)
        {
            return _devicesDal.Add(devices);
        }

        public void DeleteDevice(Devices devices)
        {
            _devicesDal.Delete(devices);
        }

        public List<Devices> GetAllDevices()
        {
            return _devicesDal.GetList();
        }

        public Devices GetById(int id)
        {
            return _devicesDal.Get(x => x.Kayit_No == id);
        }

        public Devices UpdateDevice(Devices devices)
        {
            return _devicesDal.Update(devices);

        }
    }
}
