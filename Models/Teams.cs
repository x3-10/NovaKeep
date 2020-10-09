using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaKeep.Models
{
    public partial class Teams
    {
        public Teams()
        {
            Characters = new HashSet<Characters>();
        }

        [Key]
        [Column("team_id")]
        public int TeamId { get; set; }
        [Column("game_id")]
        public int GameId { get; set; }
        [Required]
        [Column("team_name")]
        [StringLength(50)]
        public string TeamName { get; set; }
        [Column("date_created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty(nameof(Games.Teams))]
        public virtual Games Game { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<Characters> Characters { get; set; }
    }
}
