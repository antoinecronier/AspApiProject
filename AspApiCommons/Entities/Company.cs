using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApiCommons.Entities
{
    public class Company : DbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }

        //Système d’Identification du Répertoire des Entreprises : 9 chiffres) et du code NIC (Numéro Interne de Classement) à 5 chiffres identifiant l’établissement. Le NIC est composé de 4 chiffres et d’une clé de contrôle à 1 chiffre
        //SIRET 404 833 048 00022
        public string Siret { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
