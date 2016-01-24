using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract Monster class that implements behaviors common to all monsters and can
/// be specialized by subclasses that need or wish to override certain functionalities.
/// </summary>
public abstract class Monster : MonoBehaviour {
    // Constants for default and allowed instance variable values
    public const int DEFAULT_LEVEL = 1;
    public const int MIN_LEVEL = 1;
    public const int MAX_LEVEL = 10;
    public const float DEFAULT_ATTACK_SPEED = 2f;
    public const float MIN_ATTACK_SPEED = 1f;
    public const float DEFAULT_MOVE_SPEED = 50f;
    public const float MIN_MOVE_SPEED = 1f;
    public const int DEFAULT_BASE_DAMAGE = 5;
    public const int MIN_BASE_DAMAGE = 5;
    public const int DEFAULT_BASE_HEALTH = 25;
    public const int MIN_MAX_HEALTH = 1;
    public const int DEFAULT_DROP_CHANCE = 10;
    public const int MIN_DROP_CHANCE = 0;
    public const int MAX_DROP_CHANCE = 100;
    public const int DEFAULT_CRIT_CHANCE = 5;
    public const int MIN_CRIT_CHANCE = 0;
    public const int MAX_CRIT_CHANCE = 100;

    // Other constants
    public const int PROBABILITY_CONVERSION = 99;
    public const float CRIT_MODIFIER = 2f;

    // Unchanging (after initialization) instance variables
    int level;
    float attackSpeed;
    float moveSpeed;
    int baseDamage;
    int maxHealth;
    int dropChance;
    int critChance;

    // Changing variables
    int curHealth;

    /* -------------------------- INITIALIZATION -------------------------- */

    /// <summary>
    /// Initializes this monster with the stats specified. Each monster MUST be initialized.
    /// </summary>
    /// <param name="level">The level of this monster [1~10]</param>
    /// <param name="attackSpeed">The speed this monster can attack [1+]</param>
    /// <param name="moveSpeed">The speed this monster can move [1+]</param>
    /// <param name="baseDamage">The base amount of damage this monster can do [5~50 Recommended]</param>
    /// <param name="baseHealth">The base amount of health this monster will have [25~75 Recommended]</param>
    /// <param name="dropChance">The chance this monster will drop a reward on death [0~100]</param>
    /// <param name="critChance">The chance this monster will crit on an attack [0~100]</param>
    protected void Initialize(int level, float attackSpeed, float moveSpeed, int baseDamage,
                              int baseHealth, int dropChance, int critChance) {
        Level = level;
        AttackSpeed = attackSpeed;
        MoveSpeed = moveSpeed;
        BaseDamage = baseDamage;
        MaxHealth = GetMaxHealth(baseHealth);
        DropChance = dropChance;
        CritChance = critChance;

        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// Calculates the max health of this monster based off the baseHealth given.
    /// Formula: y' = .0919y(1-y/100), where y(0) = 1
    /// </summary>
    /// <example>A base value of 25 will output a max health value of 5 at level 1</example>
    /// <example>A base value of 75 will output a max health value of 45 at level 1</example>
    /// <param name="baseHealth">The base for the calculation</param>
    /// <returns>The calculated max health</returns>
    int GetMaxHealth(int baseHealth) {
        return Mathf.RoundToInt(((100 * Mathf.Exp(.0919f * baseHealth)) /
                                 (99 + Mathf.Exp(.0919f * baseHealth))) * Level / 2);
    }

    /* -------------------------- UPDATE -------------------------- */

    /// <summary>
    /// MonoBehavior update. Will check the validity and death status of this monster.
    /// </summary>
    void Update() {
        CheckValid();
        CheckDeath();
    }

    /// <summary>
    /// If this monster has not been initialized, it is invalid and self-destructs.
    /// </summary>
    public virtual bool CheckValid() {
        if (Level == 0) {
            Destroy(gameObject);
            return false;
        }
        else {
            return true;
        }
    }

    /// <summary>
    /// Checks if this monster has died. If it has, it dies and tries to drop its treasure.
    /// </summary>
    /// <returns>True if this monster is dead, false otherwise</returns>
    public virtual bool CheckDeath() {
        if (CurrentHealth <= 0) {
            Destroy(gameObject);

            if ((int) (Random.value * PROBABILITY_CONVERSION) < DropChance) {
                Drop();
            }
            
            return true;
        }
        else {
            return false;
        }
    }

    /* -------------------------- HEALTH METHODS -------------------------- */

    /// <summary>
    /// Gets the amount of damage this monster would deal to the player. Checks for crit if applicable.
    /// </summary>
    /// <returns>The amount of damage to deal</returns>
    public virtual int DealDamage() {
        float damageMod = 1f;
        
        if ((int) (Random.value * PROBABILITY_CONVERSION) < CritChance) {
            damageMod = CRIT_MODIFIER;
        }

        return (int) ((Random.value * Mathf.Pow(BaseDamage / 4, 2) * (2 * Level / (1 + Level)) + 1) * damageMod);
    }

    /// <summary>
    /// This monster takes damage from another source and loses HP.
    /// </summary>
    /// <param name="damage">The amount of raw damage to deal</param>
    /// <returns>The amount of damage dealt</returns>
    public virtual int TakeDamage(int damage) {
        if (damage < 0) {
            damage = 0;
        }

        int actualDamage = damage;

        if (CurrentHealth - damage < 0) {
            actualDamage = CurrentHealth;
            CurrentHealth = 0;
        }
        else {
            CurrentHealth -= damage;
        }

        return actualDamage;
    }

    /// <summary>
    /// This monster is healed and gains HP.
    /// </summary>
    /// <param name="health">The amount of health to restore</param>
    /// <returns>The amount of health restored</returns>
    public virtual int Heal(int health) {
        if (health < 0) {
            health = 0;
        }

        int actualHeal = health;

        if (CurrentHealth + health > MaxHealth) {
            actualHeal = MaxHealth - CurrentHealth;
            CurrentHealth = MaxHealth;
        }
        else {
            CurrentHealth += health;
        }

        return actualHeal;
    }

    /* -------------------------- ABSTRACT METHODS -------------------------- */

    /// <summary>
    /// Handles the implementation for when this monster attacks.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// Handles the implementation for when this monster moves.
    /// </summary>
    public abstract void Move();

    /// <summary>
    /// Handles the implementation for when this monster drops treasure.
    /// </summary>
    public abstract void Drop();

    /* -------------------------- PROPERTIES -------------------------- */

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public int Level {
        get {
            return level;
        }
        private set {
            if (value < MIN_LEVEL || value > MAX_LEVEL) {
                value = DEFAULT_LEVEL;
            }

            level = value;
        }
    }

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public float AttackSpeed {
        get {
            return attackSpeed;
        }
        private set {
            if (value < MIN_ATTACK_SPEED) {
                value = DEFAULT_ATTACK_SPEED;
            }

            attackSpeed = value;
        }
    }

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public float MoveSpeed {
        get {
            return moveSpeed;
        }
        private set {
            if (value < MIN_MOVE_SPEED) {
                value = DEFAULT_MOVE_SPEED;
            }

            moveSpeed = value;
        }
    }

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public int BaseDamage {
        get {
            return baseDamage;
        }
        private set {
            if (value < MIN_BASE_DAMAGE) {
                value = DEFAULT_BASE_DAMAGE;
            }

            baseDamage = value;
        }
    }
    
    /// <summary>
    /// Property for the maximum health of this monster.
    /// </summary>
    public int MaxHealth {
        get {
            return maxHealth;
        }
        private set {
            if (value < MIN_MAX_HEALTH) {
                value = GetMaxHealth(DEFAULT_BASE_HEALTH);
            }

            maxHealth = value;
        }
    }

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public int DropChance {
        get {
            return dropChance;
        }
        private set {
            if (value < MIN_DROP_CHANCE || value > MAX_DROP_CHANCE) {
                value = DEFAULT_DROP_CHANCE;
            }

            dropChance = value;
        }
    }

    /// <see cref="Initialize(int, float, float, int, int, int, int)" />
    public int CritChance {
        get {
            return critChance;
        }
        private set {
            if (value < MIN_CRIT_CHANCE || value > MAX_CRIT_CHANCE) {
                value = DEFAULT_CRIT_CHANCE;
            }

            critChance = value;
        }
    }

    /// <summary>
    /// Property for the current health of this monster.
    /// </summary>
    public int CurrentHealth {
        get {
            return curHealth;
        }
        private set {
            if (value < 0) {
                value = 0;
            }
            else if (value > MaxHealth) {
                value = MaxHealth;
            }

            curHealth = value;
        }
    }
}