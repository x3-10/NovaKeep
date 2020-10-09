using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaKeep.Models
{
    public partial class Characters
    {
        [Key]
        [Column("character_id")]
        public int CharacterId { get; set; }
        [Column("team_id")]
        public int TeamId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Required]
        [Column("hometown")]
        [StringLength(30)]
        public string Hometown { get; set; }
        [Required]
        [Column("ability", TypeName = "text")]
        public string Ability { get; set; }
        [Required]
        [Column("bio", TypeName = "text")]
        public string Bio { get; set; }
        [Required]
        [Column("weapon")]
        [StringLength(30)]
        public string Weapon { get; set; }
        [Required]
        [Column("user_accounted_id")]
        [StringLength(255)]
        public string UserAccountedId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty(nameof(Teams.Characters))]
        public virtual Teams Team { get; set; }
    }
}
