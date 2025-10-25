// Encounters manager
// Manages List of Heroes[] and Enemies[] (if (health <= 0) remove from list)
namespace RoleplayGame.Manager;

class Manager {
    List<ICharacter> Heroes;
    List<ICharacter> Enemies;

    // 1. Enemies attacks Heroes
    void EnemiesAttack() {
        int victimId = 0;
        Enemies.foreach (enemy) {


            Heroes.forEach (hero) {
                hero.ReceiveAttack(enemy.AttackValue);
                if (hero.Health <= 0) Heroes.remove(hero);
            }
            victimId += 1 % Heroes.Length;
        }
    }

    // 2. Heroes attack Enemies
    void HeroesAttack() {
        int victimId = 0;
        Heroes.foreach (hero) {
        }
    }

    void DoEncounter() {
        EnemiesAttack();
        HeroesAttack();    

        // Check health of both
    }
}
