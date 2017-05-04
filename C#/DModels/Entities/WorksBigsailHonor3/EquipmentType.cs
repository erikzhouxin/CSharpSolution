using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity
{
    public enum EquipmentType
    {
        [Display(Name = "普通设备")]
        Normal = 1,
        [Display(Name = "低值易耗")]
        EasyConsume = 2,
        [Display(Name = "固定资产")]
        FixedAsset = 4,
    }
}
