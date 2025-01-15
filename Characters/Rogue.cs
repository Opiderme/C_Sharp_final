using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public class Rogue : Character
    {
        public Rogue(string name)
        {
            Name = name;
            MaxHealth = 80;
            CurrentHealth = 80;
            PhysicalAttack = 55;
            MagicalAttack = 0;
            ArmorType = ArmorType.Cuir;
            DodgeChance = 15;
            ParryChance = 25;
            MagicResistance = 25;
            Speed = 100;
            Skills = new List<Skill> { new HeroicStrike(), new CounterAttack() };
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attaque {target.Name} furtivement !");
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
