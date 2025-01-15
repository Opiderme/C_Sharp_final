using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public class Priest : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public Priest(string name)
        {
            Name = name;
            MaxHealth = 70;
            CurrentHealth = 70;
            PhysicalAttack = 0;
            MagicalAttack = 65;
            ArmorType = ArmorType.Tissu;
            DodgeChance = 10;
            ParryChance = 0;
            MagicResistance = 20;
            Speed = 70;
            MaxMana = 100;
            CurrentMana = 100;
            Skills = new List<Skill> { new Frostbolt(), new Blizzard() };
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} utilise la puissance sacrée contre {target.Name} !");
            target.Defend(MagicalAttack, "Magique");
        }

        public override void Defend(int damage, string damageType)
        {
            int reducedDamage = CalculateDamageReduction(damage, damageType);

            CurrentHealth -= reducedDamage;
            Console.WriteLine($"{Name} subit {reducedDamage} dégâts, PV restants : {CurrentHealth}");
        }
    }
}
