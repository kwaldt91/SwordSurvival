using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Player
    {
        private string className;
        private int attack;
        private int maxHealth;
        private int health;
        private int xp;
        private int requiredXP;
        private int leftOverXp; //Xp gained from monster kill that remains after leveling up
        private int level;

        //Properties///////////
        public string ClassName
        {
            get
            {
                return className;
            }

            set
            {
                className = value;
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

        public int RequiredXP
        {
            get
            {
                return requiredXP;
            }

            set
            {
                requiredXP = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }

        public int LeftOverXp
        {
            get
            {
                return leftOverXp;
            }

            set
            {
                leftOverXp = value;
            }
        }
        ///////////////////////////

        public void SelectClass()
        {
            int input;

            do
            {
                input = 0;
                Console.WriteLine("Select your Class: 1 = Berserker || 2 = Defender || 3 = Class Descriptions");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Game.DisplayError();//if player enters non-number
                }
               
                if (input != 0)//need this to only display error once
                {
                    if (input == 1)
                    {
                        ClassName = "Berserker";
                        Attack = 150;
                        MaxHealth = 100;

                    }
                    else if (input == 2)
                    {
                        ClassName = "Defender";
                        Attack = 100;
                        MaxHealth = 150;
                    }
                    else if (input == 3)
                    {
                        Game.ClassDescriptions();
                        SelectClass();
                    }
                    else
                    {
                        Game.DisplayError();
                    } 
                }
              
            } while (input != 1 && input != 2 && input != 3);//keep asking until input is valid

            if (input != 3)
            {
                Xp = 0;
                RequiredXP = 100;
                Level = 1;
                Health = MaxHealth;

                Console.WriteLine($"You have chosen the {ClassName} class");
            }
            

        }//Initializes player's starting stats
        public void DisplayStats()//Displays player stats at top (with multi-colors)
        {
            Game.Segment();  
            Console.Write("Class: ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(ClassName);

            Console.ResetColor();            
            Console.Write(" | Attack: ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Attack);

            Console.ResetColor();
            Console.Write(" | Health: ");

            //Change color of curent health depending on amount
            if (Health > MaxHealth / 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Health <= MaxHealth / 2 && Health >= MaxHealth / 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if (Health <= 0) // avoids writing negative values to console.
            {
                Console.Write("0");
            }
            else
            {
                Console.Write(Health);
            }
            

            Console.ResetColor();
            Console.Write("/");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MaxHealth);

            Console.ResetColor();
            Console.Write(" | XP: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Xp);

            Console.ResetColor();
            Console.Write("/");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(RequiredXP);

            Console.ResetColor();
            Console.Write(" | LVL: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine(Level);

            Console.ResetColor();
            Game.Segment();
            Game.LineBreak();
        }

        public void DisplayHealth()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player Health: {Health}");
            Console.ResetColor();
        }

        public int AttackEnemy(Enemy enemy)
        {
            Random rand = new Random();
            int damage = rand.Next(Attack / 2, Attack);

            enemy.Health -= damage; //random damage based on Attack stat

            return damage;
        }

        public void GainXP(Enemy enemy)
        {
            LeftOverXp = 0;
            Xp += enemy.Xp;

            if (Xp > RequiredXP)
            {
                LeftOverXp = Xp - RequiredXP;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"You gained {enemy.Xp} XP!");
            Console.Beep();
            Console.ResetColor();
            Game.LineBreak();
        }

        public void LoseXP()
        {
            Random rand = new Random();
            int lostXP = rand.Next(10, Xp/2);
            Xp -= lostXP;
            Console.ForegroundColor = ConsoleColor.Red;
            Game.LineBreak();
            Console.WriteLine($"You lost {lostXP} XP");        
            Console.ResetColor();
            Game.LineBreak();
        }//Lose xp when running

        public void LevelUp()
        {
            int addedAtack = 0;
            int addedHealth = 0;
            
            Level++;
            Xp = LeftOverXp;//give leftover xp if xp gained surpasses required
            RequiredXP += 100;

            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Level Up! Your {ClassName} is now level {Level}");
            

            if (ClassName == "Berserker")
            {
                addedAtack = 20;
                addedHealth = 10;
                
            }
            else if (this.ClassName == "Defender")
            {
                addedAtack = 10;
                addedHealth = 20;
            }

            Attack += addedAtack;
            MaxHealth += addedHealth;
            Health = MaxHealth;

            Game.LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Attack + {addedAtack}");
            Console.WriteLine($"Health + {addedHealth}");
            Console.ResetColor();
            Game.LineBreak();
        }

        public void RecoverHealthFromRun()
        {
            Random rand = new Random();
            int recoveredHealth = rand.Next(10, MaxHealth);

            Console.Write("You recovered ");
            Console.ForegroundColor = ConsoleColor.Blue;

            if (Health + recoveredHealth > MaxHealth)//stops health from exceeding MaxHealth
            {
                int remainingHealth = MaxHealth - Health;
                Health += remainingHealth;                          
                Console.Write(remainingHealth + " ");            
            }
            else
            {
                Health += recoveredHealth;            
                Console.Write(recoveredHealth + " ");               
            }

            Console.ResetColor();
            Console.WriteLine("Health");

        }

    }
} 