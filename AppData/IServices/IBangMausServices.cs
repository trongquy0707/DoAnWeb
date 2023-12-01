using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IBangMausServices
    {
        public List<Mau> DanhSachbangMau();
        public string ThemMoiBangMau(Mau mau);
        public string SuaBangMau(int idMau, Mau mau);
        public string XoaBangMau(int idMau);

        public Mau getbyid(int id);
    }
}
