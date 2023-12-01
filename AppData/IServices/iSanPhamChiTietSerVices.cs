using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface iSanPhamChiTietSerVices
    {
        public List<SanPhamChiTiet> DanhSachSanPhamCT();
        public string ThemMoiSanPhamCT(SanPhamChiTiet sanphamCT);
        public string SuaSanPhamCT(int idSanPhamCT, SanPhamChiTiet sanphamCT);
        public string XoaSanPhamCT(int idSanPhamCT);
        public SanPhamChiTiet getbyid(int id);
    }
}
