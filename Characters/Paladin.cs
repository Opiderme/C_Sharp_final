using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public class Paladin : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public Paladin(string name)
        {
            Name = name;
            MaxHealth = 95;
            CurrentHealth = 95;
            PhysicalAttack = 40;
            MagicalAttack = 40;
            ArmorType = ArmorType.Mailles;
            DodgeChance = 5;
            ParryChance = 10;
            MagicResistance = 20;
            Speed = 50;
            MaxMana = 60;
            CurrentMana = 60;
            Skills = new List<Skill> { new HeroicStrike(), new Frostbolt() };
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attaque {target.Name} avec une attaque mixte !");
            target.Defend(PhysicalAttack, "Physique");
        }

        public override void Defend(int damage, string damageType)
        {
            int reducedDamage = CalculateDamageReduction(damage, damageType);

            CurrentHealth -= reducedDamage;
            Console.WriteLine($"{Name} subit {reducedDamage} dégâts, PV restants : {CurrentHealth}");
        }
    }
}
