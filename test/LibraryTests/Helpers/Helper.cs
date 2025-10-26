namespace Ucu.Poo.RoleplayGame;

public class Helper(Manager managerRef) // primary constructor
{
    private Manager _manRef = managerRef;

    private Helmet _helmet = new();
    private Bow _bow = new();
    private SpellOne _fireball = new();    // prev: new Spell("Fireball", 25, 0);
    private SpellOne _shield = new();      // prev: new Spell("Magic Shield", 0, 2);

    // Helper, verbosity
    public static IEnumerable<T> Fill<T>(int count, Func<int, T> factory)
        => Enumerable.Range(0, count).Select(factory);

    public ICharacter CreateEnemy(int id) {
        Dwarf gandalf = new Dwarf("Enemy-" + id);

        // Basic enemy equipment
        gandalf.AddItem(_helmet);
        gandalf.AddItem(_bow);

        return gandalf;
    }

    public ICharacter CreateHero(int id) {
        Wizard hero = new Wizard($"Hero{id}");

        // Create spellbook and add spells
        SpellsBook magicBookUltra = new SpellsBook();
        magicBookUltra.AddSpell(_fireball);
        magicBookUltra.AddSpell(_shield);
        
        hero.AddItem(magicBookUltra);       // Total wizard damage: (70 + 70)

        return hero;
    }

    public void Populate(int e, int h) {
        _manRef.Heroes.AddRange(Fill(e, i => CreateEnemy(i)));
        _manRef.Heroes.AddRange(Fill(h, i => CreateHero(i)));
    }
}