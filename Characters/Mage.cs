using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Characters
{
    public class Mage : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public Mage(string name)
        {
            Name = name;
            MaxHealth = 60;
            CurrentHealth = 60;
            PhysicalAttack = 0;
            MagicalAttack = 75;
            ArmorType = ArmorType.Tissu;
            DodgeChance = 5;
            ParryChance = 5;
            MagicResistance = 25;
            Speed = 75;
            MaxMana = 100;
            CurrentMana = 100;
            Skills = new List<Skill> { new Frostbolt(), new FrostBarrier(), new Blizzard() };
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attaque {target.Name} avec une attaque magique !");
            target.Defend(MagicalAttack, "Magique");
        }

        public override void Defend(int damage, string damageType)
        {
            int reducedDamage = CalculateDamageReduction(damage, damageType);

            CurrentHealth -= reducedDamage;
            Console.WriteLine($"{Name} subit {reducedDamage} dégâts, PV restants : {CurrentHealth}");
        }

        public void RegenerateMana()
        {
            int manaRestored = MaxMana / 2;
            CurrentMana = Math.Min(CurrentMana + manaRestored, MaxMana);
            Console.WriteLine($"{Name} restaure {manaRestored} points de mana.");
        }
    }

}
