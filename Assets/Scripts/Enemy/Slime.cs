using UnityEngine;
using System.Collections;

public class Slime : Monster {
    public int level = DEFAULT_LEVEL;
    public float attackSpeed = DEFAULT_ATTACK_SPEED;
    public float moveSpeed = DEFAULT_MOVE_SPEED;
    public int baseDamage = DEFAULT_BASE_DAMAGE;
    public int baseHealth = DEFAULT_BASE_HEALTH;
    public int dropChance = DEFAULT_DROP_CHANCE;
    public int critChance = DEFAULT_CRIT_CHANCE;

    // Use this for initialization
    void Start() {
        Initialize(level, attackSpeed, moveSpeed, baseDamage, baseHealth, dropChance, critChance);
    }

    // Update is called once per frame
    void Update() {

    }

    public override void Attack() {

    }

    public override void Move() {

    }

    public override void Drop() {

    }
}