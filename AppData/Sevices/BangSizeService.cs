using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class BangSizeService : IBangSizeService
    {
        CoolMate_1Context db = new CoolMate_1Context();

        public List<Size> DanhSachbangSize()
        {
            var data = db.Sizes.ToList();
            return data;
        }

        public string SuaBangSize(int idSize, Size size)
        {
            var timkiem = DanhSachbangSize().FirstOrDefault(c => c.IdSize == idSize);
            if (timkiem == null)
            {
                return "Không tìm thấy size!!";
            }
            else
            {
                timkiem.TenSize = size.TenSize;
                db.Sizes.Update(timkiem);
                db.SaveChanges();
                return "Sửa thành công bảng màu!!";
            }
        }

        public string ThemMoiBangSize(Size size)
        {
            if(DanhSachbangSize().Any( c => c.TenSize == size.TenSize))
            {
                return "Đã có tên trong danh sách";
            }
            else if(size.TenSize == null)
            {
                return "Bạn chưa nhập tên Size";
            }
            else
            {
                db.Sizes.Add(size);
                db.SaveChanges();
                return "Thêm mới Thành công";
            }
        }

        public string XoaBangSize(int idSize)
        {
            var timkiem = DanhSachbangSize().FirstOrDefault(c => c.IdSize == idSize);
            if(timkiem == null)
            {
                return " Khong co Size";
            }
            else
            {
                db.Sizes.Remove(timkiem);
                db.SaveChanges();
                return "Đã xóa size";
            }
        }
     

       
    }
}
