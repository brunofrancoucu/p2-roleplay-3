namespace RoleplayGame.Helpers.Standard;

public static class Helpers {
    // Helper, verbosity
    public static IEnumerable<T> Fill<T>(int count, Func<int, T> factory)
        => Enumerable.Range(0, count).Select(factory);

    ICharacter CreateEnemy(int id) => {
        Dwarf gandalf = new Dwarf("Enemy-" + id);

        // Basic enemy equipment
        gandalf.AddItem(helmet);
        gandalf.AddItem(stick);

        return gandalf;
    }

    ICharacter CreateHero(int id) => {
        Wizard hero = new Wizard($"Hero{id}", 100);

        fireball = new Spell("Fireball", 25, 0);
        shield1 = new Spell("Magic Shield", 0, 2);

        // Create spellbook and add spells
        SpellBook magicBookUltra = new SpellBook();
        magicBookUltra.LearnSpell(fireball);
        magicBookUltra.LearnSpell(shield1);
        
        // Create Wizard attacker (total damage: 25 + 0 + 15) 
        gandalf.Book = magicBookUltra;

        return hero;
    }

    public void Populate(int e, int h) {
        Manager.Heroes.AddRange( Fill(e, i => CreateEnemy(i); ));
        Manager.Heroes.AddRange( Fill(h, i => CreateHero(i); ));
    }
}