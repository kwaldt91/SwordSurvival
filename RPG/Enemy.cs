using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Enemy
    {
        private string enemyName;
        private int attack;
        private int health;
        private int xp; // the amount of xp gained when enemy is defeated

        //Properties/////////////////
        public string EnemyName
        {
            get
            {
                return enemyName;
            }

            set
            {
                enemyName = value;
            }
        }
        public int Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int Xp
        {
            get
            {
                return xp;
            }

            set
            {
                xp = value;
            }
        }
        //////////////////////////

        public void DisplayEnemyHealth()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy Health: {this.Health}");
            Console.ResetColor();
        }

        public void DisplayEnemyAttack()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Enemy Attack: {Attack}");
            Console.ResetColor();
        }

        public void DrawEnemy(string enemyName)
        {

            switch(enemyName)
            {
                case "Spider":

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (Health > 0)
                    {
                        Console.WriteLine("/\\(oo)/\\");
                    }
                    else
                    {
                        Console.WriteLine("/\\(xx)/\\");
                    }
                    break;

                case "Bat":

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (Health > 0)
                    {
                        Console.WriteLine("~(oo)~");
                    }
                    else
                    {
                        Console.WriteLine("~(xx)~");
                    }
                    break;

                case "Goblin":

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (Health > 0)
                    {
                        Console.WriteLine("<{oo}>");
                    }
                    else
                    {
                        Console.WriteLine("<{xx}>");
                    }

                    break;

                case "Robot":

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (Health > 0)
                    {
                        Console.WriteLine("0-[oo]-0");
                    }
                    else
                    {
                        Console.WriteLine("0-[xx]-0");
                    }

                    break;
            }
            
        }//Displays the enemy (emoji)
        public void SpawnEnemy(Player player)//Initializes enemy stats based on player's level
        {
            Random rand = new Random();
            int monsterAttack = 0;
            int monsterHealth = 0;
            int monsterXp = 0;

            switch (player.Level)
            {
                case 1:
                    monsterAttack = rand.Next(25, 50);
                    monsterHealth = rand.Next(125, 150);
                    monsterXp = rand.Next(25,50);
                    EnemyName = "Spider";
                    break;

                case 2:
                    monsterAttack = rand.Next(50, 75);
                    monsterHealth = rand.Next(150, 175);
                    monsterXp = rand.Next(50, 75);
                    EnemyName = "Bat";
                    break;

                case 3:
                    monsterAttack = rand.Next(75, 100);
                    monsterHealth = rand.Next(175, 200);
                    monsterXp = rand.Next(100, 125);
                    EnemyName = "Goblin";
                    break;

                default:
                    monsterAttack = rand.Next(100, 125);
                    monsterHealth = rand.Next(200, 225);
                    monsterXp = rand.Next(125, 150); ;
                    EnemyName = "Robot";
                    break;
            }

            Attack = monsterAttack;
            Health = monsterHealth;
            Xp = monsterXp;

            Console.WriteLine($"A {EnemyName} appeared!");
            Game.LineBreak();
            DrawEnemy(EnemyName);
            DisplayEnemyHealth();
            DisplayEnemyAttack();
            Game.LineBreak();         
        }

        public int AttackPlayer(Player player)
        {
            Random rand = new Random();
            int damage = rand.Next(Attack / 2, Attack);

            player.Health -= damage;

            return damage; //return damage dealt so it can be displayed in FightSequence()
        }//attack player for random damage(based on attack stat)
    }
}
