using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.PresentationLayer.Filters;
using ForaTeknoloji.PresentationLayer.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Controllers
{
    [Auth]
    [Excp]
    public class CameraController : Controller
    {
        private IUserService _userService;
        public CameraController(IUserService userService)
        {
            _userService = userService;
        }
        public void Capture(int id = -1)
        {
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            var path = Server.MapPath("/Images/user_" + id + ".jpeg");
            var entity = _userService.GetById(id);
            entity.Resim = "user_" + id + ".jpeg";
            _userService.UpdateUsers(entity);
            System.IO.File.WriteAllBytes(path, String_To_Bytes(dump));
        }

        private byte[] String_To_Bytes(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }
    }
}