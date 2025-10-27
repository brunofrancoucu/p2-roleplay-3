using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class EncountersTests
{
    Helper _helper;
    Manager _manager;

    // Encounter constants
    int enemyDamage;
    int heroDamage;
    
    [SetUp]
    public void Setup()
    {
        _manager = new Manager();
        _helper = new Helper(_manager);
        
        this.enemyDamage = _helper.CreateCharacter<Dwarf>(0).AttackValue;
        this.heroDamage = _helper.CreateWizard(0).AttackValue;
    }
    
    // Enemy Encounter Test Scenarios    

    [Test]
    public void EnemyAttackEq() {
        _helper.Populate(10, 10); // Equal enemies and heroes

        _manager.EnemiesAttack();
 
        // Expected: all heroes receive equal damage
        Assert.That(_manager.Heroes.Select(h => h.Health), Has.All.EqualTo(100 - enemyDamage));
    }

    [Test]
    public void EnemyAttackUn() {
        _helper.Populate(10, 8); // Less enemies than heroes

        _manager.EnemiesAttack();

        // Expected: last heroes unharmed
        Assert.That(_manager.Heroes[8].Health, Is.EqualTo(100));
        Assert.That(_manager.Heroes[9].Health, Is.EqualTo(100));
    }

    [Test]
    public void EnemyAttackOv()
    {
        _helper.Populate(10, 6); // More enemies than heroes

        _manager.EnemiesAttack();

        // Expected: first 4 heroes receive double damage
        Assert.That(_manager.Heroes[4].Health, Is.EqualTo(100 - enemyDamage * 2));
        Assert.That(_manager.Heroes[5].Health, Is.EqualTo(100 - enemyDamage * 1));
    }
    
    // Hero Encounter Test Scenarios
    
    // ...
    
    // Tests from RolePlay 1
    
    // // Create Items / Spells
    // helmet = new Armour("Dark Helmet", 10);
    // stick = new SpellWeapon("Staff of Power", 15, 5);
    // fireball = new Spell("Fireball", 25, 0);
    // shield1 = new Spell("Magic Shield", 0, 2);
    // shield2 = new Spell("Shield of Darkness", 1, 8);
    // gandalf = new Wizard("Gandalf", 100);
    //
    // // Create spellbook and add spells
    // SpellBook magicBookUltra = new SpellBook();
    // magicBookUltra.LearnSpell(fireball);
    // magicBookUltra.LearnSpell(shield1);
    //
    // // Create Wizard attacker (total damage: 25 + 0 + 15) 
    // gandalf.Book = magicBookUltra;
    // gandalf.AddItem(helmet);
    // gandalf.AddItem(stick);
}