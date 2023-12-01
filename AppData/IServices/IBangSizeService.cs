using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IBangSizeService
    {
        public List<Size> DanhSachbangSize();
        public string ThemMoiBangSize(Size size);
        public string SuaBangSize(int idSize, Size size);
        public string XoaBangSize(int idSize);
       
    }
}
