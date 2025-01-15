using projetFinalTest.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinalTest.Skills
{
    public abstract class Skill
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public string TargetType { get; set; }
        public int ManaCost { get; set; }

        public abstract void Use(Character user, Character target);
    }

    public class HeroicStrike : Skill
    {
        public HeroicStrike()
        {
            Name = "Frappe héroïque";
            Cooldown = 1;
            TargetType = "Ennemi";
            ManaCost = 0;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} utilise {Name} sur {target.Name}.");
            target.Defend(user.PhysicalAttack, "Physique");
        }
    }

    public class BattleCry : Skill
    {
        public BattleCry()
        {
            Name = "Cri de bataille";
            Cooldown = 2;
            TargetType = "Équipe";
            ManaCost = 0;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} augmente l'attaque physique de son équipe !");
            // Logique pour augmenter l'attaque physique des alliés
        }
    }

    public class Whirlwind : Skill
    {
        public Whirlwind()
        {
            Name = "Tourbillon";
            Cooldown = 2;
            TargetType = "Équipe ennemie";
            ManaCost = 0;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} attaque toute l'équipe ennemie avec {Name} !");
            // Logique pour infliger des dégâts à toute l'équipe ennemie
        }
    }

    public class Frostbolt : Skill
    {
        public Frostbolt()
        {
            Name = "Éclair de givre";
            Cooldown = 1;
            TargetType = "Ennemi";
            ManaCost = 15;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} lance {Name} sur {target.Name}.");
            target.Defend(user.MagicalAttack, "Magique");
            // Réduction de vitesse si la compétence n'est pas résistée
        }
    }

    public class FrostBarrier : Skill
    {
        public FrostBarrier()
        {
            Name = "Barrière de givre";
            Cooldown = 2;
            TargetType = "Soi-même";
            ManaCost = 25;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} se protège avec {Name}.");
            // Réduction des dégâts des prochaines attaques
        }
    }

    public class Blizzard : Skill
    {
        public Blizzard()
        {
            Name = "Blizzard";
            Cooldown = 2;
            TargetType = "Équipe ennemie";
            ManaCost = 25;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} invoque {Name} sur l'équipe ennemie !");
            // Logique pour infliger des dégâts et réduire la vitesse
        }
    }

    public class CounterAttack : Skill
    {
        public CounterAttack()
        {
            Name = "Contre-attaque";
            Cooldown = 0;
            TargetType = "Ennemi";
            ManaCost = 0;
        }

        public override void Use(Character user, Character target)
        {
            Console.WriteLine($"{user.Name} riposte avec {Name} contre {target.Name}.");
            // Logique pour la riposte automatique
        }
    }

}
