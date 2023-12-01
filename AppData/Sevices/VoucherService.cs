using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class VoucherService : iVoucherService
    {
        CoolMate_1Context db;
        public VoucherService()
        {
            db = new CoolMate_1Context();
        }
        public List<Voucherr> DanhSachVoucher()
        {
            var data = db.Voucherrs.ToList();
            return data;
        }

        public Voucherr getbyid(int id)
        {
            return DanhSachVoucher().FirstOrDefault( c => c.IdVoucher == id);
        }

        public string SuaVoucher(int idVoucher, Voucherr voucherr)
        {
            var timkiem = db.Voucherrs.FirstOrDefault(c => c.IdVoucher == idVoucher);   
            if (timkiem == null)
            {
                return "Không tìm thấy Voucher!!";
            }else
            {
               timkiem.TenVoucher = voucherr.TenVoucher;
               timkiem.SoLuong = voucherr.SoLuong;
                timkiem.ThoiGianBatDau = voucherr.ThoiGianBatDau;
                timkiem.ThoiGianKetThuc = voucherr.ThoiGianKetThuc;
                timkiem.Min = voucherr.Min;
                timkiem.Max = voucherr.Max;
                timkiem.ThoiGianTao = voucherr .ThoiGianTao;

                db.Voucherrs.Update(timkiem);
                db.SaveChanges();
                return "Sửa thành công !!";
            }
        }

        public string ThemMoiVoucher(Voucherr voucherr)
        {
            if (string.IsNullOrEmpty(voucherr.TenVoucher))
            {
                return "bạn chưa nhập tên";
            }
            else
            {
                voucherr.ThoiGianTao = DateTime.Now;
               db.Voucherrs.Add(voucherr);
                db.SaveChanges ();
                return "Thêm thành công";
            }
        }

        public string XoaVoucher(int idVoucher)
        {

            var timkiem = DanhSachVoucher().FirstOrDefault(c => c.IdVoucher == idVoucher);
            if (timkiem == null)
            {
                return "Không tìm thấy Voucher";
            }
            else
            {
                db.Voucherrs.Remove(timkiem);
                db.SaveChanges();
                return "Đã xóa size";
            }
        }
    }
}
