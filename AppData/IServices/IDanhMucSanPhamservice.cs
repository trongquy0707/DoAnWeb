using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IDanhMucSanPhamservice
    {
        public List<DanhMucSanPham> DanhSachDanhMucSP();
        public string ThemMoiDanhMuc( DanhMucSanPham danhMucSanPham );
        public string SuaDanhMuc(int idDanhMucSP, DanhMucSanPham danhMucSanPham);
        public string XoaDanhMuc(int idDanhMucSP);

        public DanhMucSanPham idDanhMuc(int id);
    }
}
