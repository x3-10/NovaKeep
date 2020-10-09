using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaKeep.Models
{
    public partial class Games
    {
        public Games()
        {
            Teams = new HashSet<Teams>();
        }

        [Key]
        [Column("game_id")]
        public int GameId { get; set; }
        [Required]
        [Column("game_name")]
        [StringLength(50)]
        public string GameName { get; set; }
        [Column("date_created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Game")]
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
