using projetFinalTest.Characters;
using projetFinalTest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projetFinalTest.GameLogic
{
    public class Game
    {
        private List<Character> Player1Team = new List<Character>();
        private List<Character> Player2Team = new List<Character>();

        public void Start()
        {
            Console.WriteLine("Bienvenue dans le jeu ! Préparez vos équipes.");
            SetupTeam(Player1Team, "Joueur 1");
            SetupTeam(Player2Team, "Joueur 2");
            Battle();
        }

        private void SetupTeam(List<Character> team, string playerName)
        {
            Console.WriteLine($"{playerName}, choisissez vos personnages.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("1. Guerrier\n2. Mage\n3. Paladin\n4. Voleur\n5. Prêtre");
                Console.Write("Choisissez un personnage : ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    choice = 1; // Défaut : Guerrier
                }

                switch (choice)
                {
                    case 1:
                        team.Add(new Warrior($"Guerrier {i + 1} " + playerName));
                        break;
                    case 2:
                        team.Add(new Mage($"Mage {i + 1} " + playerName));
                        break;
                    case 3:
                        team.Add(new Paladin($"Paladin {i + 1} " + playerName));
                        break;
                    case 4:
                        team.Add(new Rogue($"Voleur {i + 1} "+ playerName));
                        break;
                    case 5:
                        team.Add(new Priest($"Prêtre {i + 1} " + playerName));
                        break;
                    default:
                        Console.WriteLine("Choix invalide, Guerrier sélectionné par défaut.");
                        team.Add(new Warrior($"Guerrier {i + 1} " + playerName));
                        break;
                }
            }
        }

        private void Battle()
        {
            Console.WriteLine("<----------------------===Le combat commence !===--------------------------->");
            while (Player1Team.Any(c => c.CurrentHealth > 0) && Player2Team.Any(c => c.CurrentHealth > 0)) //Le .Any c'est trop pratique
            {
                foreach (var character in Player1Team.Concat(Player2Team).OrderByDescending(c => c.Speed))
                {
                    if (character.CurrentHealth > 0)
                    {
                        TakeTurn(character);
                    }
                }
            }

            Console.WriteLine(Player1Team.Any(c => c.CurrentHealth > 0) ? "Joueur 1 a gagné !" : "Joueur 2 a gagné !");
        }

        private void TakeTurn(Character character)
        {
            Console.WriteLine(character.Name.Substring(Math.Max(0, character.Name.Length - 8)) + " à vous.\n");
            Console.WriteLine($"{character.Name}, choisissez une action : ");
            Console.WriteLine("1. Attaquer\n2. Utiliser une compétence\n3. Passer");

            if (!int.TryParse(Console.ReadLine(), out int action))
            {
                action = 3; // Par défaut, passer le tour
            }

            switch (action)
            {
                case 1:
                    var target = SelectTarget(character);
                    if (target != null)
                    {
                        character.Attack(target);
                    }
                    break;
                case 2:
                    var skill = SelectSkill(character);
                    target = SelectTarget(character); //meme si le skill n'attaque pas l'equipe adverse ça le demande quand meme, TODO
                    skill?.Use(character, target);
                    break;
                case 3:
                    Console.WriteLine($"{character.Name} passe son tour.");
                    break;
                default:
                    Console.WriteLine("Action invalide, le tour est passé.");
                    break;
            }
        }

        private Character SelectTarget(Character character)
        {
            var opponents = Player1Team.Contains(character)
                ? Player2Team.Where(c => c.CurrentHealth > 0).ToList()
                : Player1Team.Where(c => c.CurrentHealth > 0).ToList();

            if (opponents.Count == 0)
            {
                Console.WriteLine("Aucune cible disponible.");
                return null;
            }

            Console.WriteLine("Choisissez une cible : ");
            for (int i = 0; i < opponents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opponents[i]}\n");
            }

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                choice = 1; // Par défaut, première cible
            }

            return opponents[Math.Clamp(choice - 1, 0, opponents.Count - 1)];
        }

        private Skill SelectSkill(Character character)
        {
            if (character.Skills == null || character.Skills.Count == 0)
            {
                Console.WriteLine("Aucune compétence disponible.");
                return null;
            }

            Console.WriteLine("Choisissez une compétence : ");
            for (int i = 0; i < character.Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.Skills[i].Name}\n");
            }

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                choice = 1; // Par défaut, première compétence
            }

            return character.Skills[Math.Clamp(choice - 1, 0, character.Skills.Count - 1)];
        }
    }
}
