using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class Ares
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ares { get; set; }
        public int? id_persona { get; set; }
        public int? A2022_12 { get; set; }
        public int? A2023_01 { get; set; }
        public int? A2023_02 { get; set; }
        public int? A2023_03 { get; set; }
        public int? A2023_04 { get; set; }
        public int? A2023_05 { get; set; }
        public int? A2023_06 { get; set; }
        public int? A2023_07 { get; set; }
        public int? A2023_08 { get; set; }
        public int? A2023_09 { get; set; }
        public int? A2023_10 { get; set; }
        public int? A2023_11 { get; set; }
        public int? A2023_12 { get; set; }
        public int? A2024_01 { get; set; }
        public int? A2024_02 { get; set; }
        public int? A2024_03 { get; set; }
        public int? A2024_04 { get; set; }
        public int? A2024_05 { get; set; }
        public int? A2024_06 { get; set; }
        public int? A2024_07 { get; set; }
        public int? A2024_08 { get; set; }
        public int? A2024_09 { get; set; }
        public int? A2024_10 { get; set; }

        [ForeignKey("id_persona")]
        public virtual Persona Persona { get; set; }
    }
}
