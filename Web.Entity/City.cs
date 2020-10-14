using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
    public class Cities
    {
        public string City { get; set; }
    }
    public class City
    {
        public List<Cities> GetCityList()
        {
            List<Cities> City = new List<Cities>()
            {
                new Cities{City="Adana"},
                new Cities{City="Adıyaman"},
                new Cities{City="AfyonKarahisar"},
                new Cities{City="Ağrı"},
                new Cities{City="Ankara"},
                new Cities{City="Amasya"},
                new Cities{City="Antalya"},
                new Cities{City="Artvin"},
                new Cities{City="Aydın"},
                new Cities{City="Balıkesir"},
                new Cities{City="Bilecik"},
                new Cities{City="Bingöl"},
                new Cities{City="Bitlis"},
                new Cities{City="Bolu"},
                new Cities{City="Burdur"},
                new Cities{City="Bursa"},
                new Cities{City="Çanakkale"},
                new Cities{City="Çankırı"},
                new Cities{City="Çorum"},
                new Cities{City="Denizli"},
                new Cities{City="Diyarbakır"},
                new Cities{City="Edirne"},
                new Cities{City="Elazığ"},
                new Cities{City="Erzincan"},
                new Cities{City="Erzurum"},
                new Cities{City="Eskişehir"},
                new Cities{City="Gaziantep"},
                new Cities{City="Giresun"},
                new Cities{City="Gümüşhane"},
                new Cities{City="Hakkari"},
                new Cities{City="Hatay"},
                new Cities{City="Isparta"},
                new Cities{City="Mersin"},
                new Cities{City="İstanbul"},
                new Cities{City="İzmir"},
                new Cities{City="Kars"},
                new Cities{City="Kastamonu"},
                new Cities{City="Kayseri"},
                new Cities{City="Kırklareli"},
                new Cities{City="Kırşehir"},
                new Cities{City="Kocaeli"},
                new Cities{City="Konya"},
                new Cities{City="Kütahya"},
                new Cities{City="Malatya"},
                new Cities{City="Manisa"},
                new Cities{City="Kahramanmaraş"},
                new Cities{City="Mardin"},
                new Cities{City="Muğla"},
                new Cities{City="Muş"},
                new Cities{City="Nevşehir"},
                new Cities{City="Niğde"},
                new Cities{City="Ordu"},
                new Cities{City="Rize"},
                new Cities{City="Sakarya"},
                new Cities{City="Samsun"},
                new Cities{City="Siirt"},
                new Cities{City="Sinop"},
                new Cities{City="Sivas"},
                new Cities{City="Tekirdağ"},
                new Cities{City="Tokat"},
                new Cities{City="Trabzon"},
                new Cities{City="Tunceli"},
                new Cities{City="Şanlıurfa"},
                new Cities{City="Uşak"},
                new Cities{City="Van"},
                new Cities{City="Yozgat"},
                new Cities{City="Zonguldak"},
                new Cities{City="Aksaray"},
                new Cities{City="Bayburt"},
                new Cities{City="Karaman"},
                new Cities{City="Kırıkkale"},
                new Cities{City="Batman"},
                new Cities{City="Şırnak"},
                new Cities{City="Bartın"},
                new Cities{City="Ardahan"},
                new Cities{City="Iğdır"},
                new Cities{City="Yalova"},
                new Cities{City="Karabük"},
                new Cities{City="Kilis"},
                new Cities{City="Osmaniye"},
                new Cities{City="Düzce"},
            };
            return City;
        }
    }
}
