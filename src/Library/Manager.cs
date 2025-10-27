namespace Ucu.Poo.RoleplayGame;

public class Manager 
{
    public List<ICharacter> Heroes { get; set; }
    public List<ICharacter> Enemies { get; set; }

    public Manager()
    {
        Heroes = new List<ICharacter>();
        Enemies = new List<ICharacter>();
    }

    public void EnemiesAttack()
    {
        if (Heroes.Count == 0 || Enemies.Count == 0) return;
        for (int i = 0; i < Enemies.Count; i++)
        {
            int victimId = i % Heroes.Count;
            Heroes[victimId].ReceiveAttack(Enemies[i].AttackValue);
        }
        Heroes.RemoveAll(h => h.Health <= 0);
    }

    public void HeroesAttack()
    {
        if (Heroes.Count == 0 || Enemies.Count == 0) return;
        for (int i = 0; i < Heroes.Count; i++)
        {
            int victimId = i % Enemies.Count;
            Enemies[victimId].ReceiveAttack(Heroes[i].AttackValue);
        }
        Enemies.RemoveAll(e => e.Health <= 0);
    }

    public void DoEncounter()
    {
        while (Heroes.Count > 0 && Enemies.Count > 0)
        {
            EnemiesAttack();
            HeroesAttack();
        }
    }
}