namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupingExperimentEquipment")]
    public partial class GroupingExperimentEquipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentItemID { get; set; }

        public double LowStandardGroupingPeopleNumber { get; set; }

        public double HighStandardGroupingPeopleNumber { get; set; }

        public double SmallSchoolGroupingPeopleNumber { get; set; }

        public double TeachSchoolGroupingPeopleNumber { get; set; }

        public virtual EquipmentItems EquipmentItems { get; set; }
    }
}
