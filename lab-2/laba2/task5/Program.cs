using System;
using System.Collections.Generic;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroBuilder = new HeroBuilder();
            var enemyBuilder = new EnemyBuilder();
            var director = new CharacterDirector(heroBuilder, enemyBuilder);

            var hero = director.ConstructCharacterHero();
            var enemy = director.ConstructCharacterEnemy();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hero Character:");
            Console.ResetColor();
            hero.DisplayCharacter();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nEnemy Character:");
            Console.ResetColor();
            enemy.DisplayCharacter();
        }
    }
}
