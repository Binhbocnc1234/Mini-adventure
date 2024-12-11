using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    private static Player _instance;

    public static Player Instance{
        get {return _instance;}
    }
    public Weapon initialWeapon;
    [HideInInspector] public Weapon primaryWeapon;
    [HideInInspector] public Weapon secondaryWeapon;
    public Transform weaponContainer;
    public Animator animator;
    public bool enableInitalPos;
    [HideInInspector] public int collectedCoins;
    // [HideInInspector] public House checkpoint;
    void Awake(){
        if (_instance == null){
            _instance = this;
        }
    }
    protected override void Start(){
        ChangeWeapon(initialWeapon);
        if (enableInitalPos){
            transform.position = initialPosition;
        }
        base.Start();
        
    }
    protected override void Update(){
        FallIntoTheEnd();
    }
    public void EndAttack(){
        animator.speed = 1;
        primaryWeapon.Attack();
    }
    public void StartAttack(){
        animator.speed = primaryWeapon.atkSpeed;
    }
    public void ChangeWeapon(Weapon weapon){
        Destroy(primaryWeapon.gameObject);
        Weapon newWeapon = Instantiate(weapon, weaponContainer.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        primaryWeapon = newWeapon;
        newWeapon.owner = GetComponent<Entity>();
        SwitchPrimary();
    }
    public void SwitchPrimary(){
        primaryWeapon.owner = GetComponent<Entity>();
        primaryWeapon.gameObject.SetActive(true);
        secondaryWeapon.gameObject.SetActive(false);
    }
    protected override void FallIntoTheEnd(){
        if (transform.position.y <= -15){
            ChangeWeapon(initialWeapon);
            transform.position = initialPosition;
        }
    }
}
