namespace Ucu.Poo.RoleplayGame;

public interface ICharacter
{
    string Name { get; set; }

    int Health { get; }

    int AttackValue { get; }

    int DefenseValue { get; }
 
    int VP { get;}

    void StealVP(ICharacter character);

    void AddItem(IItem item);

    void RemoveItem(IItem item);

    void Cure();

    void ReceiveAttack(int power);
}
