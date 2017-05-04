using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.Supervise
{
    /// <summary>
    /// 官网新闻
    /// </summary>
    public class OWSNews
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        public Int64? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public virtual OWSNews ParentNews { get; set; }

        [Required]
        [StringLength(256)]
        [Column(TypeName = "nvarchar")]
        public string Titile { get; set; }

        [Required]
        [StringLength(1024)]
        [Column(TypeName = "nvarchar")]
        public string Summary { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime EditTime { get; set; }

        public InfoType InfoType { get; set; }

        public bool IsDelete { get; set; }

        [Required]
        [StringLength(1024)]
        [Column(TypeName = "nvarchar")]
        public string Memo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string Remark { get; set; }
    }
}
