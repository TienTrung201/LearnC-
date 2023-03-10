using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using WebAPIBt.DaTa;
using WebAPIBt.Model;

namespace WebAPIBt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangAPIController : ControllerBase
    {
        private readonly ApiContext _context;

        public KhachHangAPIController(ApiContext context)
        {
            _context = context;
        }
        //create/edit

        [HttpPost]
        public IActionResult InsertCustomer(KhachDTO KhachHang)
        {
            var khach = new KhachHang() { TenKH = KhachHang.TenKH, DiaChi = KhachHang.DiaChi, Sdt = KhachHang.Sdt };
            _context.KhachHang.Add(khach);
            _context.SaveChanges();
            return Ok(khach);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var khach = _context.KhachHang.FirstOrDefault(kh=>kh.MaKH== id);
            if (khach == null)
            {
              return  NotFound();
            }
            return Ok(khach);
        }
        [HttpGet]

        public List<KhachHang> GetAllCustomer()
        {
            var khach = _context.KhachHang.ToList();
            return khach;
        }
        [HttpPut("{id}")]
        public IActionResult EditCustomer( int id,KhachDTO KhachHang)
        {
            var khach = _context.KhachHang.FirstOrDefault(kh=>kh.MaKH== id);
            khach.TenKH = KhachHang.TenKH;
            khach.DiaChi = KhachHang.DiaChi;
            khach.Sdt = KhachHang.Sdt;
           // _context.KhachHang.Update(khach);
            _context.SaveChanges();

            return Ok(khach);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var khach = _context.KhachHang.FirstOrDefault(kh => kh.MaKH == id);
            _context.Remove(khach);
            _context.SaveChanges();

            return Ok(khach);


        }
        /*
        public JsonResult CreateEditCustumer(KhachHang khachHang)
        {
            // id =0 là thêm 1 api mới 
            if (khachHang.MaKH == 0)
            {
                _context.KhachHang.Add(khachHang);
            }
            else
            {
                var KhachHangInDb = _context.KhachHang.Find(khachHang.MaKH);
                Console.WriteLine(KhachHangInDb);
                if (KhachHangInDb == null)
                    return new JsonResult(NotFound());

                KhachHangInDb = khachHang;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(khachHang));
        }
        */
        /*
        [HttpGet]
        public JsonResult GetCustumer(int MaKH)
        {
            var result = _context.KhachHang.Find(MaKH);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        */
        // Delete
        /*
        [HttpDelete]
        public JsonResult DeleteCustumer(int MaKH)
        {
            var result = _context.KhachHang.Find(MaKH);

            if (result == null)
                return new JsonResult(NotFound());

            _context.KhachHang.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());// status 204
        }
        
        // Get all
        
        [HttpGet]
        public JsonResult GetAllCustumer()
        {
            var result = _context.KhachHang.ToList();

            return new JsonResult(Ok(result));
        }
        
        */
    }
}
