using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface iVoucherService
    { 
        public List<Voucherr> DanhSachVoucher();
        public string ThemMoiVoucher(Voucherr voucherr);
        public string SuaVoucher(int idVoucher, Voucherr voucherr);
        public string XoaVoucher(int idVoucher);
        public Voucherr getbyid(int id);
    }
}
