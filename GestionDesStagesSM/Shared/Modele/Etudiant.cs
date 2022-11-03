using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStagesSM.Shared.Modele
{
    public class Etudiant
    {
        [Key]
        [StringLength(450)]
        public String Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }


        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]

        public string  TelephoneCellulaire{ get; set; }

    }
}
