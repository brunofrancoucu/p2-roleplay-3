using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight: ICharacter
{
    private int _health = 100;

    private List<IItem> _items = new List<IItem>();

    public Knight(string name)
    {
        this.Name = name;

        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
    
    public int VP { get; set; }

    public void StealVP(ICharacter target)
    {
        this.VP += target.VP;
        target.VP = 0;
    }

    public string Name { get; set; }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this._items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this._items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this._health + this.DefenseValue;
        }
        private set
        {
            this._health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        int minHealth = -this.DefenseValue;
        this._health = Math.Max(minHealth, this._health - power);
    }

    public void Cure()
    {
        this._health = 100;
    }

    public void AddItem(IItem item)
    {
        this._items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this._items.Remove(item);
    }
}
