using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Start
{
    public static void Main(string[] args)
    {
        new Program().Run();
    }
}

class Program
{
    private Random random = new Random();
    public List<GameCharacter> Hero = new List<GameCharacter> { new GameCharacter(100, 20, 40) };
    public List<GameCharacter> Boss = new List<GameCharacter> { new GameCharacter(200, 50, 80) };
    public void Run()
    {
        while (Boss[0].Health > 0 && Hero[0].Health > 0)
        {
            Console.Clear();
            foreach (var hero in Hero) Console.WriteLine($"Hero - Health: {hero.Health}, Strength: {hero.Strength}, Stamina: {hero.Stamina}");
            foreach (var boss in Boss) Console.WriteLine($"Boss - Health: {boss.Health}, Strength: {boss.Strength}, Stamina: {boss.Stamina}");
            if (Hero[0].Stamina >= 10) fight(Hero[0], Boss[0], "Boss");
            else recharge(Hero[0], "Hero");
            Thread.Sleep(2000);
            if (Boss[0].Stamina >= 10) fight(Boss[0], Hero[0], "Hero");
            else recharge(Boss[0], "Boss");
            Thread.Sleep(3000);
        }
        Console.Clear();
        foreach (var hero in Hero) Console.WriteLine($"Hero - Health: {hero.Health}, Strength: {hero.Strength}, Stamina: {hero.Stamina}");
        foreach (var boss in Boss) Console.WriteLine($"Boss - Health: {boss.Health}, Strength: {boss.Strength}, Stamina: {boss.Stamina}");
        Console.WriteLine(Hero[0].Health <= 0 && Boss[0].Health <= 0 ? "Begge tapte. Dette var en skuffelse!" : Hero[0].Health <= 0 ? 
            "Hero Tapte. Lenge leve Boss!" :
            "Boss Tapte. Lenge leve Hero!");
        Thread.Sleep(4000);
    }

    private void fight(GameCharacter attacker, GameCharacter defender, string targetName)
    {
        int damage = random.Next(0, 31);
        damage = attacker.Strength;
        defender.Health -= targetName == "Boss" ? attacker.Strength : damage;
        defender.Stamina -= 10;
        if (defender.Health < 0) defender.Health = 0;
        Console.WriteLine($"{targetName} took {damage} Damage!");
    }

    private void recharge(GameCharacter user, string userName)
    {
        Console.WriteLine($"{userName} må hvile!");
        user.Stamina += 10;
    }
}

class GameCharacter
{
    public int Health;
    public int Strength;
    public int Stamina;

    public GameCharacter(int health = 0, int strength = 0, int stamina = 0)
    {
        Health = health;
        Strength = strength;
        Stamina = stamina;
    }
}