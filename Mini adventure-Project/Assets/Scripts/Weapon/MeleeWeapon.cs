using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeWeapon : Weapon{    
    public bool autoMeleeAttack = false;
    private bool isAttack = false;
    protected float distance;
    protected Timer atkTimer;
    protected override void Start(){
        base.Start();
        atkTimer = new Timer(atkSpeed);
    }

    void Update()
    {
        if (animator != null){
            if (autoMeleeAttack == true){
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= this.atkRange){

                    isAttack = true;
                }
            }
            if (isAttack){
                animator.Play("Attack");
            }
            else{
                animator.Play("Move");
            }
        }
        
    }
    public override void Attack(){
        if (owner.team == Team.Enemy){
            float distance = Vector3.Distance(transform.position, Player.Instance.transform.position);
            if (distance <= atkRange){
                Player.Instance.GetComponent<Entity>().GetDamage(this.dmg);
            }
            return;
        }
        foreach(Transform trans in EntityManager.Instance.transform){
            Entity entity = trans.GetComponent<Entity>();
            if (entity == null){
                continue;
            }
            float distance = Vector3.Distance(transform.position, entity.transform.position);
            if (distance <= atkRange && owner.team != entity.team){
                //Deal damage to entity
                entity.GetDamage(this.dmg);
            }
        }
        isAttack = false;
    }
    
}
