using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    public class ExperimentTextbook
    {
        public Int64 CatalogID { get; set; }

        public Int64 EditionID { get; set; }
    }
}
