using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [ComplexType]
    [Table("CodeFirstModel", Schema = "dbo")]
    public class CodeFirstModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "int")]
        [Index(IsUnique = true)]
        [ForeignKey("CatID")]
        public int ID { get; set; }

        [ForeignKey("CatID")]
        public virtual CodeFirstModel Model { get; set; }

        [Required, Column(TypeName = "nvarchar"), MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Display(Name = "版本名称"), Description("版本名称")]
        public string Name { get; set; }

        [NotMapped]
        [InverseProperty("UpdatedBy")]
        [ConcurrencyCheck,Column("Remark", TypeName = "nvarchar(max)"), StringLength(1024)]
        public string Remark { get; set; }
    }
}
