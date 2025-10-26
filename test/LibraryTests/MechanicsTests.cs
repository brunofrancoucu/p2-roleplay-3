using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class MechanicsTests
{

    [SetUp]
    public void Setup()
    {
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


    [Test]
    public void Attack()
    {
        
    }


    [Test]
    public void Items()
    {
        
    }

    [Test]
    public void Battle1()
    {
        // Tests from RolePlay 1
        
        // // Create Wizard defender
        // Wizard saruman = new Wizard("Saruman", 100);
        // saruman.Book = new SpellBook();
        // saruman.Book.LearnSpell(shield2);
        // saruman.AddItem(helmet);
        //
        // gandalf.Attack(saruman);
        //
        // Assert.That(saruman.Health, Is.EqualTo(60));    // Post Gandalf attack health (test wpn type)
        // saruman.Heal(80);
        // Assert.That(saruman.Health, Is.EqualTo(118));   // Post self heal health (test max)
    }
}