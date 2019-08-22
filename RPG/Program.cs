using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        //test push
        static void Main(string[] args)
        {  
            Player player = new Player();
           
            Game.Welcome();

            player.SelectClass();
            Game.WaitForInput();
            Console.Clear();
            
            do
            {
                player.DisplayStats();
                Enemy enemy = new Enemy();
                enemy.SpawnEnemy(player);
                
                Game.FightSequence(player, enemy);
             
                if (player.Health <= 0) //end game if player runs out of health
                {
                    Game.GameOver(player.Level);
                    return; //Exits the game
                }
               
            } while (Game.PlayOrQuit()); //Keep spawning enemies while player chooses to continue

            player.DisplayStats();
            Game.GameOver(player.Level); //end game if player chooses not to continue;
        }

        
    }
    
}
