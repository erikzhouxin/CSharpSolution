namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationBureau_ExperimentSettings
    {
        public int ID { get; set; }

        public Guid EducationFileID { get; set; }

        public int CatalogID { get; set; }

        public int Grade { get; set; }

        public int BookEditionId { get; set; }

        public virtual BookEditions BookEditions { get; set; }

        public virtual EducationBureauFilesControl EducationBureauFilesControl { get; set; }

        public virtual EquipmentCatalogs EquipmentCatalogs { get; set; }
    }
}
