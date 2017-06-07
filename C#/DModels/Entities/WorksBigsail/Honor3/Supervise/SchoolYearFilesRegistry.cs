namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolYearFilesRegistry")]
    public partial class SchoolYearFilesRegistry
    {
        public Guid ID { get; set; }

        public Guid FilesControlID { get; set; }

        public Guid SchoolRegistryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string SponsorType { get; set; }

        [Required]
        [StringLength(20)]
        public string BelongType { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Linkman { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int ClassTotal { get; set; }

        [Required]
        [StringLength(50)]
        public string SchoolNetworkModel { get; set; }

        public int NumberOfStudents { get; set; }

        [Required]
        [StringLength(50)]
        public string HealthRoomSettings { get; set; }

        [Required]
        [StringLength(200)]
        public string IntegratedPracticeActivity { get; set; }

        public int EquipmentStandardDimensionID { get; set; }

        public int MaxNumberOfClass { get; set; }

        public int AnotherPartNineYearSchoolClassTotal { get; set; }

        [Required]
        [StringLength(20)]
        public string BoardingType { get; set; }

        public int NumberOfBoardingStudents { get; set; }

        public int NumberOfCanOperateComputerStudents { get; set; }

        public bool IsSmallScale { get; set; }

        [Required]
        [StringLength(20)]
        public string ContainedGrades { get; set; }

        public int SchoolDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal ApproveQuota { get; set; }

        [Column(TypeName = "money")]
        public decimal MaxQuota { get; set; }

        public int Location { get; set; }

        public int ConversionType { get; set; }

        public int SeniorClassTotal { get; set; }

        public int SeniorStudents { get; set; }

        public int SeniorBoardingStudents { get; set; }

        public int StandardComputeMode { get; set; }

        public bool IsLocked { get; set; }

        [Required]
        public string LockedCatalogs { get; set; }

        public DateTime LockedTime { get; set; }

        public virtual EducationBureauFilesControl EducationBureauFilesControl { get; set; }

        public virtual SchoolRegistry SchoolRegistry { get; set; }
    }
}
