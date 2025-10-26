// Encounters manager
// Manages List of Heroes[] and Enemies[] (if (health <= 0) remove from list)
namespace Ucu.Poo.RoleplayGame;

public class Manager {
    public List<ICharacter> Heroes;
    public List<ICharacter> Enemies;

    // 1. Enemies attacks Heroes
    public void EnemiesAttack() {
        int victimId = 0;
        Enemies.ForEach(enemy =>
        {
            Heroes.ForEach(hero =>
            {
                hero.ReceiveAttack(enemy.AttackValue);
                if (hero.Health <= 0) Heroes.Remove(hero);
            });
            victimId += 1 % Heroes.Count;
        });
    }

    // 2. Heroes attack Enemies
    public void HeroesAttack() {
        int victimId = 0;
        Heroes.ForEach(hero =>
        {
            // Damage
            victimId += 1 % Heroes.Count;
        });
    }

    public void DoEncounter() {
        EnemiesAttack();
        HeroesAttack();    

        // Check health of both
    }
}
