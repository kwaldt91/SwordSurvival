using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    static class Game
    {
        private static string divider = "------------------------------------------------------------------------";
        private static int monstersSlain = 0; //Keeps count of enemies defeated

        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("D==[=======> SWORD SURVIVIAL <=======}==D");
            Segment();
            Console.ResetColor();
        }//Displays Title on start

        public static void ClassDescriptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Berserker: ");
            Console.ResetColor();
            Console.WriteLine("The Berserker charges into battle with dual swords and no armor. \nWhat he lacks in armor and defense, he makes up for in terrrifying agrression and brute force.");
            Console.ForegroundColor = ConsoleColor.Blue;
            LineBreak();
            Console.WriteLine("(High attack, Low defense)");
            Console.ResetColor();
            LineBreak();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Defender: ");
            Console.ResetColor();
            Console.WriteLine("The Defender is equipped with a giant shield and heavy armor. \nHowever, the giant shield requires two hands, leaving no room for a sword");
            Console.ForegroundColor = ConsoleColor.Blue;
            LineBreak();
            Console.WriteLine("(Low attack, High defense)");
            Console.ResetColor();
            LineBreak();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Rogue: ");
            Console.ResetColor();
            Console.WriteLine("The Rogue wears thick leather armor and is equipped with a light shield and sword, \nmaking him a well rounded combatant");
            Console.ForegroundColor = ConsoleColor.Blue;
            LineBreak();
            Console.WriteLine("(Moderate attack, Moderate defense)");
            Console.ResetColor();
            LineBreak();
        }

        public static void Segment()
        {
            Console.WriteLine(divider);
        }//Displays the divider

        public static void WaitForInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.ResetColor();
        }//Pauses execution until player presses key
       
        public static void FightSequence(Player player, Enemy enemy)
        {
            int input;
            do
            {
                
                do
                {
                    input = 0;
                    Console.WriteLine("What will you do?: 1 = Attack || 2 = Run!");
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        DisplayError(); //if player enters a non-number
                        
                    }

                    if (input != 0) //need this to only display error once
                    {
                        if (input == 1) // attack enemy
                        {
                            Console.Beep();
                            int damageDealt = player.AttackEnemy(enemy);
                            Console.Write($"You slash the {enemy.EnemyName} causing ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(damageDealt);
                            Console.ResetColor();
                            Console.WriteLine(" damage!");
                            LineBreak();
                            enemy.DrawEnemy(enemy.EnemyName);

                            if (enemy.Health > 0)
                            {
                                enemy.DisplayEnemyHealth();
                                WaitForInput();
                                int enemyDamage = enemy.AttackPlayer(player);
                                Console.Beep();
                                Console.Write($"The {enemy.EnemyName} attacks, causing ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(enemyDamage);
                                Console.ResetColor();
                                Console.WriteLine(" damage!");
                                LineBreak();

                                if (player.Health > 0)
                                {
                                    player.DisplayHealth();
                                    Game.WaitForInput();
                                    Console.Clear();
                                    player.DisplayStats();
                                    enemy.DrawEnemy(enemy.EnemyName);
                                    enemy.DisplayEnemyHealth();
                                    enemy.DisplayEnemyAttack();
                                    Game.LineBreak();
                                }
                                else //avoids displaying negative values in console
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Player Health: 0");
                                    Console.ResetColor();
                                }
                            }
                            else //if enemy is defeated
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Enemy Health: 0");
                                Console.ResetColor();
                                LineBreak();
                                Console.WriteLine($"You defeated the {enemy.EnemyName}!");
                                LineBreak();
                                player.GainXP(enemy);
                                monstersSlain++;

                                if (player.Xp >= player.RequiredXP)
                                {
                                    player.LevelUp();
                                }

                            }

                            if (player.Health <= 0) //if player is defeted break from loop
                            {
                                Console.WriteLine("You were defeated");
                                LineBreak();
                                WaitForInput();
                                Console.Clear();
                                player.DisplayStats();
                                break;
                            }

                        }
                        else if (input == 2) //Run
                        {
                            if (player.Xp >= 10)
                            {
                                Console.WriteLine("You ran away...");
                                player.LoseXP();
                                player.RecoverHealthFromRun();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Cant escape! (not enough XP)");
                                WaitForInput();
                                Console.Clear();
                                player.DisplayStats();
                                enemy.DrawEnemy(enemy.EnemyName);
                                enemy.DisplayEnemyHealth();
                                enemy.DisplayEnemyAttack();
                                Game.LineBreak();
                            }

                        }
                        else
                        {
                            DisplayError();
                        } 
                    }

                } while (enemy.Health > 0); 
            } while (input != 1 && input != 2); //Keep asking for valid input
            
        }//Battle sequence between player and enemy

        public static bool PlayOrQuit()
        {
            int input;
            bool playAgain = false;

            LineBreak();

            do
            {
                input = 0;
                Console.WriteLine("Continue?: 1 = Yes || 2 = No");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException)//if player enter non-number
                {
                    DisplayError();
                }


                if (input != 0)//need this to only display error message once
                {
                    if (input == 1)
                    {
                        playAgain = true;
                    }
                    else if (input == 2)
                    {
                        playAgain = false;
                    }
                    else
                    {
                        DisplayError();
                    } 
                }

            } while (input != 1 && input != 2);

            Console.Clear();

            return playAgain;
        }//Asks user if they want to continue and returns answer

        public static void LineBreak()
        {
            Console.WriteLine();
        }//Adds space between lines of text

        public static void GameOver(int playerLevel)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("D==|=======> GAME OVER <=======}==D");
            LineBreak();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Monsters Slain: {monstersSlain}");
            Console.WriteLine($"Level Reached: {playerLevel}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            LineBreak();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

        }//Displays Game over message and results

        public static void DisplayError()
        {
            Console.WriteLine("Invalid input..Enter 1 or 2");
            LineBreak();
        }//Displays error to user if input is invalid
    }
}
