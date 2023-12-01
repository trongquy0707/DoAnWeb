using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface INguoiDungServiec
    {
        public List<User> ListUser();
        public string ThemMoiNguoiDung(User user);
        public string SuaNguoiDung(int idUser);
        public string mokhoa(int idUser);
        public string DangKy(User user);
        public User getbyid(int id);

    }
}
