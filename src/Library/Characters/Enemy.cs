using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Enemy: ICharacter
{
    private int health = 100;
    
    private List<IItem> items = new List<IItem>();

    public Dwarf(string name)
    {
        this.Name = name;

        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public int VP
    {
        get
        {
            return 1;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }

}