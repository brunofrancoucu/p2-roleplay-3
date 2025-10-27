using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class EncountersTests
{
    Helper _helper;
    Manager _manager;

    // Encounter constants
    private int _enemyDamage;
    private int _heroDamage;
    
    [SetUp]
    public void Setup()
    {
        _manager = new Manager();
        _helper = new Helper(_manager);
        
        this._enemyDamage = _helper.CreateCharacter<Dwarf>(0).AttackValue;
        this._heroDamage = _helper.CreateWizard(0).AttackValue;
    }

    [Test]
    public void Encounter_FullBattleUntilOneSideRemains()
    {
        _helper.Populate(10, 10);
        _manager.DoEncounter();

        Assert.That(_manager.Heroes.Count > 0 ^ _manager.Enemies.Count > 0, Is.True); // Only 1 survives

        if (_manager.Heroes.Count > 0) Assert.That(_manager.Enemies.Count, Is.EqualTo(0));
        else Assert.That(_manager.Heroes.Count, Is.EqualTo(0));
    }

    
    // Enemy Encounter Test Scenarios    

    [Test]
    public void EnemyAttackEq() {
        _helper.Populate(10, 10); // Equal enemies and heroes

        int initialHealth = _manager.Heroes[4].Health;
        
        _manager.EnemiesAttack();
 
        // Expected: all heroes receive equal damage
        Assert.That(_manager.Heroes.Select(h => h.Health), Has.All.EqualTo(initialHealth - _enemyDamage));
    }

    [Test]
    public void EnemyAttackUn() {
        _helper.Populate(8, 10); // Less enemies than heroes

        int initialHealth = _manager.Heroes[8].Health;
        
        _manager.EnemiesAttack();

        // Expected: last heroes unharmed
        Assert.That(_manager.Heroes[8].Health, Is.EqualTo(initialHealth));
        Assert.That(_manager.Heroes[9].Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void EnemyAttackOv()
    {
        _helper.Populate(10, 6); // More enemies than heroes
        
        int initialHealth = _manager.Heroes[4].Health;

        _manager.EnemiesAttack();

        // Expected: first 4 heroes receive double damage
        Assert.That(_manager.Heroes[3].Health, Is.EqualTo(initialHealth - _enemyDamage * 2));
        Assert.That(_manager.Heroes[4].Health, Is.EqualTo(initialHealth - _enemyDamage * 1));
    }
    
    // Hero Encounter Test Scenarios
    
    // ...
}