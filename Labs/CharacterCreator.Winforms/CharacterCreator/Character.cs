/* ITSE1430
 * DALIA HUSSIN
 * 10/22/2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character 
    {
        private string name;
        private string profession;
        private string race;
        private int strength, intelligence, agility, constitution, charisma;
        private string description;

        /// <summary>
        /// Create a character initialize the required attributes
        /// </summary> 
        public Character(string name, string profession, string race,
            int strength, int intelligence, int agility, int constitution, int charisma)
        { 
            this.name = name;
            this.profession = profession;
            this.race = race;
            this.strength = strength;
            this.intelligence = intelligence;
            this.agility = agility;
            this.constitution = constitution;
            this.charisma = charisma;
            this.description = "";
        }

        /// <summary>
        /// Charisma property
        /// </summary>
        public int Charisma
        {
            get
            {
                return charisma;
            }
            set
            {
                charisma = value;
            }
        }

        /// <summary>
        /// Constitution property
        /// </summary>
        public int Constitution
        {
            get
            {
                return constitution;
            }
            set
            {
                constitution = value;
            }
        }

        /// <summary>
        /// Agility property
        /// </summary>
        public int Agility
        {
            get
            {
                return agility;
            }
            set
            {
                agility = value;
            }
        }

        /// <summary>
        /// Intelligence property
        /// </summary>
        public int Intelligence
        {
            get
            {
                return intelligence;
            }
            set
            {
                intelligence = value;
            }
        }

        /// <summary>
        /// Strength property
        /// </summary>
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
            }
        }

        /// <summary>
        /// Race property
        /// </summary>
        public string Race
        {
            get
            {
                return race;
            }
            set
            {
                race = value;
            }
        }

        /// <summary>
        /// Profession property
        /// </summary>
        public string Profession
        {
            get
            {
                return profession;
            }
            set
            {
                profession = value;
            }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Description property
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Return a string representation of a character
        /// </summary>
        public override string ToString()
        {
            return "Name: " + name + ", "
                + "Profession: " + profession + ", "
                + "Race: " + race + ", "
                + "Attributes: [Strength=" + strength + ", Intelligence=" + intelligence + ", Agility=" + agility + ", Constitution=" + constitution + ", Charisma=" + charisma + "], "
                + "Description: " + description;
        }
    }
}
