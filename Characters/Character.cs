using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public ArmorType ArmorType { get; set; }
        public int DodgeChance { get; set; }
        public int ParryChance { get; set; }
        public int MagicResistance { get; set; }
        public int Speed { get; set; }
        public List<Skill> Skills { get; set; }

        public abstract void Attack(Character target);
        public abstract void Defend(int damage, string damageType);
        public virtual void Heal(int amount)
        {
            CurrentHealth = Math.Min(CurrentHealth + amount, MaxHealth);
            Console.WriteLine($"{Name} se soigne pour {amount} points.");
        }

        public override string ToString()
        {
            return $"{Name}: PV {CurrentHealth}/{MaxHealth}, Attaque Physique {PhysicalAttack}, Attaque Magique {MagicalAttack}";
        }

        public int CalculateDamageReduction(int damage, string damageType)
        {
            double reductionPercentage = 0;

            switch (ArmorType)
            {
                case ArmorType.Tissu:
                    reductionPercentage = damageType == "Physique" ? 0 : 0.3;
                    break;
                case ArmorType.Cuir:
                    reductionPercentage = damageType == "Physique" ? 0.15 : 0.2;
                    break;
                case ArmorType.Mailles:
                    reductionPercentage = damageType == "Physique" ? 0.3 : 0.1;
                    break;
                case ArmorType.Plaques:
                    reductionPercentage = damageType == "Physique" ? 0.45 : 0;
                    break;
            }

            return (int)(damage * (1 - reductionPercentage));
        }
    }

    public enum ArmorType
    {
        Tissu,
        Cuir,
        Mailles,
        Plaques
    }

}
