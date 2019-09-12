using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace RPG
{
    class Program
    {
        //test push
        //testing change 123
        //testing change again
        static void Main(string[] args)
        {
            int songCounter = 0;
            string introSongPath = Path.GetFullPath("Intro.wav");
            SoundPlayer introSong = new SoundPlayer(introSongPath);

            string battlSongPath = Path.GetFullPath("BattleSong.wav");
            SoundPlayer battleSong = new SoundPlayer(battlSongPath);

            string battlSong2Path = Path.GetFullPath("BattleSong2.wav");
            SoundPlayer battleSong2 = new SoundPlayer(battlSong2Path);

            string victorySongPath = Path.GetFullPath("Victory.wav");
            SoundPlayer victorySong = new SoundPlayer(victorySongPath);


            string gameOverSongPath = Path.GetFullPath("GameOver.wav");
            SoundPlayer gameOverSong = new SoundPlayer(gameOverSongPath);

            string levelUpSongPath = Path.GetFullPath("LevelUp.wav");
            SoundPlayer levelUpSong = new SoundPlayer(levelUpSongPath);



            Player player = new Player();
            introSong.PlayLooping();
           
            Game.Welcome();

            player.SelectClass();
            Game.WaitForInput();          
            Console.Clear();
            
            do
            {
                if(songCounter % 2 == 0)
                {
                    battleSong.PlayLooping();
                }
                else
                {
                    battleSong2.PlayLooping();
                }
                
                player.DisplayStats();
                Enemy enemy = new Enemy();
                enemy.SpawnEnemy(player);

                player.GainedLevel = false; //resets this after leveling up  

                Game.FightSequence(player, enemy);
             
                if (player.Health <= 0) //end game if player runs out of health
                {
                        
                    gameOverSong.PlayLooping();
                    Game.GameOver(player);
                    return; //Exits the game
                }
              
                if(player.GainedLevel)
                {
                    
                    levelUpSong.PlayLooping();
                }
                else
                {
                    victorySong.PlayLooping();
                }
                
                songCounter++;

            } while (Game.PlayOrQuit()); //Keep spawning enemies while player chooses to continue

            gameOverSong.PlayLooping();
            player.DisplayStats();
            Game.GameOver(player); //end game if player chooses not to continue;
        }

    }
    
}
