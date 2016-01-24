using UnityEngine;
using System.Collections;

public class Slime : Monster {
    public int myLevel = DEFAULT_LEVEL;
    public float myAttackSpeed = DEFAULT_ATTACK_SPEED;
    public float myMoveSpeed = DEFAULT_MOVE_SPEED;
    public int myBaseDamage = DEFAULT_BASE_DAMAGE;
    public int myBaseHealth = DEFAULT_BASE_HEALTH;
    public int myDropChance = DEFAULT_DROP_CHANCE;
    public int myCritChance = DEFAULT_CRIT_CHANCE;

    // Use this for initialization
    void Start() {
        Initialize(myLevel, myAttackSpeed, myMoveSpeed, myBaseDamage, myBaseHealth, myDropChance, myCritChance);
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