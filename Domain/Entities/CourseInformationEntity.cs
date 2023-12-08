using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("courses")]
    public class CourseInformationEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("teachers")]
        public List<string> Teatchers { get; set; }

        [Column("workload")]
        public string Workload { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
