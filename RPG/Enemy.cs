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
                case "Dumb Fish":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (Health > 0)
                    {
                        Console.WriteLine("><>");
                    }
                    else
                    {
                        Console.WriteLine("><x>");
                    }
                    break;

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

                case "Owl":

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (Health > 0)
                    {
                        Console.WriteLine("m{o>o}m");
                    }
                    else
                    {
                        Console.WriteLine("m{x>x}m");
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

                case "Cursed Sword":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (Health > 0)
                    {
                        Console.Write("D=[");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("===>");
                    }
                    else
                    {
                        Console.Write("D=[");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("XXX>");
                    }

                    break;

                case "Cursed Hammer":

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (Health > 0)
                    {
                        Console.Write("====");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("[]");
                    }
                    else
                    {
                        Console.Write("=XX=");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("[X]");
                    }

                    break;

                case "Cursed Staff":

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (Health > 0)
                    {
                        Console.Write("@");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("~)~~~");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("X");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("~)~~~");
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
                    monsterXp = rand.Next(25, 50);
                    EnemyName = "Dumb Fish";
                    break;

                case 2:
                    monsterAttack = rand.Next(50, 75);
                    monsterHealth = rand.Next(150, 175);
                    monsterXp = rand.Next(50, 75);
                    EnemyName = "Spider";
                    break;

                case 3:
                    monsterAttack = rand.Next(75, 100);
                    monsterHealth = rand.Next(175, 200);
                    monsterXp = rand.Next(75, 100);
                    EnemyName = "Bat";
                    break;

                case 4:
                    monsterAttack = rand.Next(100, 125);
                    monsterHealth = rand.Next(200, 225);
                    monsterXp = rand.Next(100, 125);
                    EnemyName = "Owl";
                    break;

                case 5:
                    monsterAttack = rand.Next(125, 150);
                    monsterHealth = rand.Next(225, 250);
                    monsterXp = rand.Next(125, 150);
                    EnemyName = "Goblin";
                    break;

                case 6:
                    monsterAttack = rand.Next(150, 175);
                    monsterHealth = rand.Next(250, 275);
                    monsterXp = rand.Next(150, 175); ;
                    EnemyName = "Robot";
                    break;

                case 7:
                    monsterAttack = rand.Next(175, 200);
                    monsterHealth = rand.Next(275, 300);
                    monsterXp = rand.Next(175, 200); ;
                    EnemyName = "Cursed Sword";
                    break;

                case 8:
                    monsterAttack = rand.Next(200, 225);
                    monsterHealth = rand.Next(300, 325);
                    monsterXp = rand.Next(200, 225); ;
                    EnemyName = "Cursed Hammer";
                    break;

                default:
                    monsterAttack = rand.Next(225, 250);
                    monsterHealth = rand.Next(325, 350);
                    monsterXp = rand.Next(225, 250); ;
                    EnemyName = "Cursed Staff";
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
