using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name)
        {
            Name = name;
            MaxHealth = 100;
            CurrentHealth = 100;
            PhysicalAttack = 50;
            MagicalAttack = 0;
            ArmorType = ArmorType.Plaques;
            DodgeChance = 5;
            ParryChance = 25;
            MagicResistance = 10;
            Speed = 50;
            Skills = new List<Skill> { new HeroicStrike(), new BattleCry(), new Whirlwind() };
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attaque {target.Name} avec une attaque physique !");
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
