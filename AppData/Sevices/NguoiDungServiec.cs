using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class NguoiDungServiec : INguoiDungServiec
    {
        CoolMate_1Context db = new CoolMate_1Context();
        public string DangKy(User user)
        {
            throw new NotImplementedException();
        }

        public User getbyid(int id)
        {

            return ListUser().FirstOrDefault(c => c.IdUser == id);
        }
      
    public List<User> ListUser()
        {
            var data = db.Users.ToList();
            return data;

        }

        public string mokhoa(int idUser)
        {
            var timkiem = ListUser().FirstOrDefault(c => c.IdUser == idUser);
            if (timkiem == null)
            {
                return "Không tìm thấy Ngườid dùng";
            }
            else
            {
                timkiem.TrangThai = 1;
                db.Users.Update(timkiem);
                db.SaveChanges();
                return "Đã Mở Khóa người dùng";
            };
        }

        public string SuaNguoiDung(int idUser)
        {
            var timkiem = ListUser().FirstOrDefault(c => c.IdUser == idUser);
            if (timkiem == null)
            {
                return "Không tìm thấy Ngườid dùng";
            }
            else
            {
                timkiem.TrangThai = 0;
                db.Users.Update(timkiem);
                db.SaveChanges();
                return "Đã Khóa người dùng";
            }
        }

        public string ThemMoiNguoiDung(User user)
        {
            user.IdChucVu = 2;
            user.TrangThai = 1;
            db.Users.Add(user);

            db.SaveChanges();
            return "Thêm thành công";
        }

       
    }

}
