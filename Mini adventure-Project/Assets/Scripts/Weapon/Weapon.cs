using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour{
    public int dmg ;
    public float atkSpeed ; 
    public float atkRange;
    public WeaponSO so;
    public Entity owner;
    protected Player player;
    protected Animator animator;
    protected virtual void Start()
    {
        player = Player.Instance;
        dmg = so.damage;
        atkSpeed = so.atkSpeed;
        atkRange = so.atkRange;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Attack(){
        
    }
}
