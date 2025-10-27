using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class MechanicsTests
{
    Helper _helper;

    ICharacter _enemy;
    ICharacter _player;

    [SetUp]
    public void Setup()
    {
        _helper = new Helper(null);

        _enemy = _helper.CreateCharacter<Dwarf>(0);
        _player = _helper.CreateCharacter<Knight>(1);
    }

    [Test]
    public void Damage()
    {
        Axe axe = new Axe();
        _enemy.ReceiveAttack(_player.AttackValue);
        
        Assert.That(_enemy.Health, Is.EqualTo(100 + _enemy.DefenseValue - _player.AttackValue));

        _enemy.AddItem(axe); // Double axes

        Assert.That(_enemy.AttackValue, Is.EqualTo(axe.AttackValue*2 + 15)); // Includes: Axe, Bow
    }

    [Test]
    public void Inventory()
    {
        Archer chr = _helper.CreateCharacter<Archer>(0);

        IItem shield = new Shield();
        chr.AddItem(shield); // +14 Defence

        Assert.That(chr.DefenseValue, Is.EqualTo(50));

        chr.RemoveItem(shield);

        Assert.That(chr.DefenseValue, Is.EqualTo(18*2)); // Includes 2*Helmet
    }
    
    [Test]
    public void Health()
    {
        _enemy.ReceiveAttack(_player.AttackValue);
        
        Assert.That(_enemy.Health, Is.EqualTo(100 + _enemy.DefenseValue - _player.AttackValue));

        Helmet helmet2 = new Helmet();
        _enemy.AddItem(helmet2);        // Total defence of 18*2
        _enemy.Cure();                  // Restored Health
        
        // Multiple attacks
        _enemy.ReceiveAttack(_player.AttackValue);
        _enemy.ReceiveAttack(_player.AttackValue);
        
        Assert.That(_enemy.Health, Is.EqualTo(100 + _enemy.DefenseValue - _player.AttackValue*2));
    }
}