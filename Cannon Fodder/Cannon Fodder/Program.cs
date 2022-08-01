
class Game
{
    public int Level = 0;
    public int Round = 0;
    public bool enemyTurn = false;
    private int CoolDown;
    public int coolDown
    {
        get { return CoolDown ;}
        set
        {
            if (value < 0) CoolDown = 0;
            else CoolDown = value;
        }
    }
    static void Main(String[] args)
    {
        Game game = new Game();
        List<Enemy> enemyList = new List<Enemy>();
        List<Item> droppedItems = new List<Item>();
        ConsoleKeyInfo keyInfo;
        Random random = new Random();
        Character character;
        characterCreation characterGen = new characterCreation();
        Console.WriteLine("Welcome to the Game");
        Console.WriteLine("Please create your character...");
        Console.WriteLine("If you press the wrong buttons, your character will be generated randomly!");
        Console.WriteLine("Press F for: Fighter, T for : Tank and H for Healer");
        keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.F)
        {
            Console.Clear();
            Console.WriteLine("Now choose your armor, L for light and H for heavy");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.L)
            {
                Console.Clear();
                Console.WriteLine("Choose your weapon, S for shortsword and L for longsword");
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.S) character = characterGen.generateCharacter(1, 1, 1);
                if (keyInfo.Key == ConsoleKey.L) character = characterGen.generateCharacter(1, 1, 2);
                else character = characterGen.generateCharacter(random.Next(1, 3), random.Next(1, 2), random.Next(1, 3));
            }
            else if (keyInfo.Key == ConsoleKey.H)
            {
                Console.Clear();
                Console.WriteLine("Choose your weapon, S for shortsword and L for longsword");
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.S) character = characterGen.generateCharacter(1, 2, 1);
                if (keyInfo.Key == ConsoleKey.L) character = characterGen.generateCharacter(1, 2, 2);
                else character = characterGen.generateCharacter(random.Next(1, 3), random.Next(1, 2), random.Next(1, 3));
            }
            else
            {
                character = characterGen.generateCharacter(random.Next(1, 3), random.Next(1, 2), random.Next(1, 3));
            }
        }
        if (keyInfo.Key == ConsoleKey.T)
        {
            Console.Clear();
            Console.WriteLine("Choose your weapon, S for shortsword and L for longsword and T for Shield");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.S) character = characterGen.generateCharacter(2, 2, 1);
            if (keyInfo.Key == ConsoleKey.L) character = characterGen.generateCharacter(2, 2, 2);
            if (keyInfo.Key == ConsoleKey.T) character = characterGen.generateCharacter(2, 2, 3);
            else character = characterGen.generateCharacter(random.Next(1, 3), random.Next(1, 2), random.Next(1, 3));
        }
        if (keyInfo.Key == ConsoleKey.H)
        {
            character = characterGen.generateCharacter(3, null, null);
        }
        else
        {
            Console.Clear();
            character = characterGen.generateCharacter(random.Next(1, 3), random.Next(1, 2), random.Next(1, 3));
        }
        Console.Clear();
        Console.WriteLine("Your character has a maximum HP value of: ");
        Console.WriteLine(character.maxHP);
        Console.Clear();
        Console.WriteLine("And has a weight of: ");
        Console.WriteLine(character.Weight);
        Console.Clear();
        Console.WriteLine("And your Strength, Vitality and Intelligence scores are: ");
        Console.WriteLine(character.Strength + ", " + character.Vitality + " and " + character.Intelligence);
        Console.WriteLine("You are ready to play!");
        Console.WriteLine("Press S to start the game");
        do
        {
            keyInfo = Console.ReadKey();
        }
        while (keyInfo.Key != ConsoleKey.S);
        Console.Clear();
        droppedItems.Add(new Longsword());
        droppedItems.Add(new Shield());
        //if (enemyList.Count > 0) Console.WriteLine("00");
        while (game.Level <= 3)
        {
            enemyList.AddRange(characterGen.waveCreator(game.Level));
            Console.WriteLine("Wave " + (game.Level + 1) + " is incoming!");
            while (true)
            {
                //enemyList.ElementAt(0).Play(character, 20);
                Console.WriteLine("Turn " + game.Round);
                for (int i = 0; i < enemyList.Count(); i++)
                {
                    //Console.WriteLine("Inside first loop");
                    //Console.WriteLine("00");
                    Console.WriteLine("Enemy number " + (i+1) + " is alive and has a remaining HP of " + enemyList.ElementAt(i).HP);
                }
                Console.WriteLine("Press 1 to attack, 2 to special, 3 to wield, 4 to wear, 5 to pick, 6 to show your status");
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.D1)
                {
                    game.enemyTurn = true;
                    game.updateTurn();
                    Console.WriteLine(" Choose a target");
                    keyInfo = Console.ReadKey();
                    if(keyInfo.Key == ConsoleKey.D1)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(0).Armor.protectionValue) { character.Attack(enemyList.ElementAt(0)); }
                    }
                    else if(keyInfo.Key == ConsoleKey.D2)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(1).Armor.protectionValue) character.Attack(enemyList.ElementAt(1));
                    }
                    else if(keyInfo.Key == ConsoleKey.D3)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(2).Armor.protectionValue) character.Attack(enemyList.ElementAt(2));
                    }
                    else if (keyInfo.Key == ConsoleKey.D4)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(3).Armor.protectionValue) character.Attack(enemyList.ElementAt(3));
                    }
                    else if (keyInfo.Key == ConsoleKey.D5)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(4).Armor.protectionValue) character.Attack(enemyList.ElementAt(4));
                    }
                    else if (keyInfo.Key == ConsoleKey.D6)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(5).Armor.protectionValue) character.Attack(enemyList.ElementAt(5));
                    }
                    else if (keyInfo.Key == ConsoleKey.D7)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(6).Armor.protectionValue) character.Attack(enemyList.ElementAt(6));
                    }
                    else if (keyInfo.Key == ConsoleKey.D8)
                    {
                        if (random.Next(1, 20) >= enemyList.ElementAt(7).Armor.protectionValue) character.Attack(enemyList.ElementAt(7));
                    }
                }
                else if(keyInfo.Key == ConsoleKey.D2)
                {
                    Console.WriteLine(" Press 1 to heal yourself");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        if (game.coolDown == 0)
                        {
                            character.SpecialAction(character);
                            game.coolDown = 3;
                            game.enemyTurn = true;
                            game.updateTurn();
                        }
                        else
                        {
                            Console.WriteLine("Skill in cooldown");
                        }
                    }
                }
                else if(keyInfo.Key == ConsoleKey.D3)
                {
                    game.enemyTurn = true;
                    game.updateTurn();
                    Console.Clear();
                    List<int> options = new List<int>();
                    for (int i = 0; i < character.Inventory.Count; i++)
                    {
                        if (character.Inventory.ElementAt(i) is Weapons)
                        {
                            character.Inventory.ElementAt(i).showAttributes();
                            options.Add(i);
                        }
                    }
                    Console.WriteLine("Press the number increasingly to take the weapon");
                    keyInfo = Console.ReadKey();
                    if(keyInfo.Key == ConsoleKey.D1)
                    {
                        character.Wield((Weapons)character.Inventory.ElementAt(options.ElementAt(0)));
                    }
                    else if(keyInfo.Key == ConsoleKey.D2)
                    {
                        character.Wield((Weapons)character.Inventory.ElementAt(options.ElementAt(1)));
                    }
                    else if (keyInfo.Key == ConsoleKey.D3)
                    {
                        character.Wield((Weapons)character.Inventory.ElementAt(options.ElementAt(2)));
                    }
                    else if (keyInfo.Key == ConsoleKey.D4)
                    {
                        character.Wield((Weapons)character.Inventory.ElementAt(options.ElementAt(3)));
                    }
                }
                else if (keyInfo.Key == ConsoleKey.D4)
                {
                    game.enemyTurn = true;
                    game.updateTurn();
                    Console.Clear();
                    List<int> options = new List<int>();
                    for (int i = 0; i < character.Inventory.Count; i++)
                    {
                        if (character.Inventory.ElementAt(i) is Clothing)
                        {
                            character.Inventory.ElementAt(i).showAttributes();
                            options.Add(i);
                        }
                    }
                    Console.WriteLine("Press the number increasingly to wear the armor");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        character.Wear((Clothing)character.Inventory.ElementAt(options.ElementAt(0)));
                    }
                    else if (keyInfo.Key == ConsoleKey.D2)
                    {
                        character.Wear((Clothing)character.Inventory.ElementAt(options.ElementAt(1)));
                    }
                    else if (keyInfo.Key == ConsoleKey.D3)
                    {
                        character.Wear((Clothing)character.Inventory.ElementAt(options.ElementAt(2)));
                    }
                    else if (keyInfo.Key == ConsoleKey.D4)
                    {
                        character.Wear((Clothing)character.Inventory.ElementAt(options.ElementAt(3)));
                    }
                }
                else if (keyInfo.Key == ConsoleKey.D5)
                {
                    game.enemyTurn = true;
                    game.updateTurn();
                    List<Item> options = new List<Item>();
                    for (int i = 0; i < droppedItems.Count; i++)
                    {
                        droppedItems.ElementAt(i).showAttributes();
                        options.Add(droppedItems.ElementAt(i));
                    }
                    Console.WriteLine("Press the number increasingly to take the item from the ground");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        character.Pick(options.ElementAt(0));
                        Console.WriteLine("Picked the first item");
                        droppedItems.RemoveAt(0);
                    }
                    else if (keyInfo.Key == ConsoleKey.D2)
                    {
                        character.Pick(options.ElementAt(1));
                        Console.WriteLine("Picked the second item");
                        droppedItems.RemoveAt(1);
                    }
                    else if (keyInfo.Key == ConsoleKey.D3)
                    {
                        character.Pick(options.ElementAt(2));
                        Console.WriteLine("Picked the third item");
                        droppedItems.RemoveAt(2);
                    }
                    else if (keyInfo.Key == ConsoleKey.D4)
                    {
                        character.Pick(options.ElementAt(3));
                        Console.WriteLine("Picked the fourth item");
                        droppedItems.RemoveAt(3);
                    }
                }
                else if(keyInfo.Key == ConsoleKey.D6)
                {
                    Console.Clear();
                    character.ListInventory();
                    Console.WriteLine(character.HP);
                    Console.WriteLine("Press esc to exit...");
                    do
                    {
                        keyInfo = Console.ReadKey();
                    }
                    while (keyInfo.Key != ConsoleKey.Escape);
                }
                if (game.enemyTurn)
                {
                    for (int i = 0; i < enemyList.Count(); i++)
                    {
                        enemyList.ElementAt(i).Attack(character);
                    }
                    game.enemyTurn = false;
                }
                if(character.HP <= 0)
                {
                    character.Kill();
                    break;
                }
                for (int i = 0; i < enemyList.Count(); i++)
                {
                    if(enemyList.ElementAt(i).HP <= 0) enemyList.RemoveAt(i);
                }
                if (!enemyList.Any()) break;
            }
            if (character.hasDied())
            {
                break;
            }
            else 
            { 
                character.HP = character.maxHP;
                game.updateLevel();
            }
        }
        Console.Clear();
        if (character.hasDied()) 
        {
            Console.WriteLine("You died");
        }
        else
        {
            Console.WriteLine("You've Won!");
        }
    }
    public void updateLevel()
    {
        Level++;
    }
    public void updateTurn()
    {
        Round++;
    }
}
public interface Item 
{
    void showAttributes();
}
public class Clothing:Item
{
    public string name;
    public int weight;
    public int protectionValue;
    public void showAttributes()
    {
        Console.WriteLine(name);
        Console.WriteLine("Weight of the armor is " + weight);
        Console.WriteLine("Protection value of the armor is " + protectionValue);
    }
}
public class LightArmor : Clothing
{
    public LightArmor()
    {
        name = "Light Armor";
        weight = 8;
        protectionValue = 5;
    }
}
public class HeavyArmor : Clothing
{
    public HeavyArmor()
    {
        name = "Heavy Armor";
        weight = 12;
        protectionValue = 8;
    }
}
public class Weapons:Item
{
    public string name;
    public int weight;
    public int damageValue;
    public void showAttributes()
    {
        Console.WriteLine(name);
        Console.WriteLine("Weight of the weapon is " + weight);
        Console.WriteLine("Damage of the weapon is " + damageValue);
    }
}
public class Longsword : Weapons
{
    public Longsword()
    {
        name = "Longsword";
        weight = 5;
        damageValue = 3;
    }
}
public class Shortsword : Weapons
{
    public Shortsword()
    {
        name = "Shortsword";
        weight = 3;
        damageValue = 2;
    }
}
public class Shield : Weapons
{
    public Shield()
    {
        name = "Shield";
        weight = 4;
        damageValue = 2;
    }
}
public class Wand : Weapons
{
    public Wand()
    {
        name = "Wand";
        weight = 2;
        damageValue = 2;
    }
}
public class Character
{
    Random random = new Random();
    public double Strength;
    public double Vitality;
    public double Intelligence;
    public int maxHP;
    public int HP;
    public int Level;
    public int Weight;
    public int Damage;
    private bool isDead = false;
    public Clothing Armor;
    public Weapons Weapon;
    public List<Item> Inventory = new List<Item>();
    public void Attack(Character target)
    {
        target.HP = target.HP - Weapon.damageValue;
    }
    public void SpecialAction(Character target)
    {
        target.HP = maxHP;
    }
    public void Pick(Item item)
    {
        Inventory.Add(item);
        if (item is Shortsword) Weight += 3;
        else if (item is Longsword) Weight += 5;
        else if (item is Shield) Weight += 4;
        else if (item is Wand) Weight += 2;
        else if (item is LightArmor) Weight += 8;
        else Weight += 12;
    }
    public void Wield(Weapons weapon)
    {
        Weapon = weapon;
    }
    public void Wear(Clothing armor)
    {
        Armor = armor;
    }
    public void Examine(Item item)
    {
        item.showAttributes();
    }
    public int getWeight()
    {
        return Weight;
    }
    public void ListInventory()
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            Inventory.ElementAt(i).showAttributes();
        }
    }
    public void Kill()
    {
        isDead = true;
    }
    public bool hasDied()
    {
        return isDead;
    }
    protected void setInventory()
    {
        Inventory.Add(Weapon);
        Inventory.Add(Armor);
    }
}
public class Fighter : Character
{
    public Fighter(int Strength, int Vitality, int Intelligence, Clothing armor, Weapons weapon)
    {
        Level = 0;
        this.Strength = Strength;
        this.Vitality = Vitality;
        this.Intelligence = Intelligence;
        maxHP = Convert.ToInt32((0.7 * Vitality) + (0.2 * Strength) + (0.1 * Intelligence))*2;
        HP = maxHP;
        Armor = armor;
        Weapon = weapon;
        Weight = armor.weight + weapon.weight;
        Damage = Strength * weapon.damageValue;
        setInventory();
    }
}
public class Tank : Character
{
    public Tank(int Strength, int Vitality, int Intelligence, Clothing armor, Weapons weapon)
    {
        Level = 0;
        this.Strength = Strength;
        this.Vitality = Vitality;
        this.Intelligence = Intelligence;
        maxHP = Convert.ToInt32((0.7 * Vitality) + (0.2 * Strength) + (0.1 * Intelligence))*3;
        HP = maxHP;
        Armor = armor;
        Weapon = weapon;
        Weight = armor.weight + weapon.weight;
        setInventory();
        if(weapon is Shield)
        {
            Damage = Vitality * weapon.damageValue;
        }
        else
        {
            Damage = Strength * weapon.damageValue;
        }
    }
}
public class Healer : Character
{
    public Healer(int Strength, int Vitality, int Intelligence, Clothing armor, Weapons weapon)
    {
        Level = 0;
        this.Strength = Strength;
        this.Vitality = Vitality;
        this.Intelligence = Intelligence;
        maxHP = Convert.ToInt32((0.7 * Vitality) + (0.2 * Strength) + (0.1 * Intelligence))*2;
        HP = maxHP;
        Armor = armor;
        Weapon = weapon;
        Weight = armor.weight + weapon.weight;
        Damage = Intelligence * weapon.damageValue;
        setInventory();
    }
}
public class Enemy : Character
{    
    public Enemy(int Strength, int Vitality, int Intelligence, Clothing armor, Weapons weapon, int Level)
    {
        this.Level = Level;
        this.Strength = Strength;
        this.Vitality = Vitality;
        this.Intelligence = Intelligence;
        Armor = armor;
        Weapon = weapon;
        Weight = armor.weight + weapon.weight;
        maxHP = 5 + 2*Level;
        HP = maxHP;
        setInventory();
        if(weapon is Shield)
        {
            Damage = Vitality* weapon.damageValue/2;
        }
        else if(weapon is Wand)
        {
            Damage = Intelligence*weapon.damageValue/2;
        }
        else
        {
            Damage = Strength * weapon.damageValue/2;
        }
    }
    public void Play(Character target, int odd)
    {
        if(odd > target.Armor.protectionValue)
        {
            Attack(target);
            Console.WriteLine("Enemy has hit " + Damage);
        }
        else
        {
            Console.WriteLine("Enemy has missed!");
        }
    }
}
public class characterCreation
{
    Random random = new Random();
    public List<Enemy> waveCreator(int level)
    {
        List<Enemy> enemylist = new List<Enemy>();
        for (int i = 0; i < Math.Pow(2, level); i++)
        {
            Enemy enemy = generateEnemy(level);
            enemylist.Add(enemy);
        }
        return enemylist;
    }
    public Character ?generateCharacter(int type, int ?armor, int ?weapon)
    {
        if (type == 1)
        {
            if (weapon == 1)
            {
                Shortsword shortsword = new Shortsword();
                if (armor == 1)
                {
                    LightArmor lightarmor = new LightArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), lightarmor, shortsword);
                }
                else if (armor == 2)
                {
                    HeavyArmor heavyarmor = new HeavyArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), heavyarmor, shortsword);
                }
                else return null;
            }
            else if (weapon == 2)
            {
                Longsword longsword = new Longsword();
                if (armor == 1)
                {
                    LightArmor lightarmor = new LightArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), lightarmor, longsword);
                }
                else if (armor == 2)
                {
                    HeavyArmor heavyarmor = new HeavyArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), heavyarmor, longsword);
                }
                else return null;
            }
            else return null;
        }
        else if (type == 2)
        {
            if (weapon == 1)
            {
                Shortsword shortsword = new Shortsword();
                if (armor == 1)
                {
                    LightArmor lightarmor = new LightArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), lightarmor, shortsword);
                }
                else if (armor == 2)
                {
                    HeavyArmor heavyarmor = new HeavyArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), heavyarmor, shortsword);
                }
                else return null;
            }
            else if (weapon == 2)
            {
                Longsword longsword = new Longsword();
                if (armor == 1)
                {
                    LightArmor lightarmor = new LightArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), lightarmor, longsword);
                }
                else if (armor == 2)
                {
                    HeavyArmor heavyarmor = new HeavyArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), heavyarmor, longsword);
                }
                else return null;
            }
            else if (weapon == 3)
            {
                Shield shield = new Shield();
                if (armor == 1)
                {
                    LightArmor lightarmor = new LightArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), lightarmor, shield);
                }
                else if (armor == 2)
                {
                    HeavyArmor heavyarmor = new HeavyArmor();
                    return new Fighter(random.Next(6, 10), random.Next(3, 7), random.Next(1, 5), heavyarmor, shield);
                }
                else return null;
            }
            else return null;
        }
        else if (type == 3)
        {
            LightArmor lightarmor = new LightArmor();
            Wand wand = new Wand();
            return new Healer(random.Next(3, 7), random.Next(1, 5), random.Next(6, 10), lightarmor, wand);
        }
        else return null;
    }
    public Enemy generateEnemy(int Level)
    {
        Random random = new Random();
        int weapon = random.Next(1, 3);
        int armor = random.Next(1,2);
        if(weapon == 1)
        {
            if(armor == 1)
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new LightArmor(), new Shortsword(), Level);
            }
            else
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new HeavyArmor(), new Shortsword(), Level);
            }
        }
        else if (weapon == 2)
        {
            if (armor == 1)
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new LightArmor(), new Longsword(), Level);
            }
            else
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new HeavyArmor(), new Longsword(), Level);
            }
        }
        else
        {
            if(armor == 1)
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new LightArmor(), new Wand(), Level);
            }
            else
            {
                return new Enemy(random.Next(1, 5), random.Next(1, 5), random.Next(1, 5), new HeavyArmor(), new Wand(), Level);
            }
        }

    }
}