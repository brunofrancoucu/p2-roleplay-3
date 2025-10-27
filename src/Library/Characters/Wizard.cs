using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Wizard: IMagicCharacter
{
    private int _health = 100;

    private List<IItem> _items = new List<IItem>();

    private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

    public Wizard(string name)
    {
        this.Name = name;

        this.AddItem(new Staff());
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
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
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
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalDefenseItem)
                {
                    value += (item as IMagicalDefenseItem).DefenseValue;
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

    public void AddItem(IMagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalItems.Remove(item);
    }

}
