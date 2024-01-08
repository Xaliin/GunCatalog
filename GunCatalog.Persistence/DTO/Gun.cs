using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Persistence.DTO
{
    public class Gun
    {
        public int Id { get; set; }
        public byte[]? Picture { get; set; }
        public GunData Data { get; set; }



        public Gun(int id , byte[]? picture, GunData data)
        {
            Id = id;
            Picture = picture;
            Data = data;
        }
    }
}
