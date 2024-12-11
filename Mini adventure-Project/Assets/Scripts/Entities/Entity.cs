using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team{
    Player,
    Enemy
}
public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    public Team team;
    [HideInInspector] public float health;
    private Rigidbody2D rb;
    public float fullHealth;
    public Vector3 initialPosition;
    protected virtual void Start()
    {
        health = fullHealth;
        this.transform.parent = EntityManager.Instance.transform;
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FallIntoTheEnd();
    }
    public void GetDamage(float damage){
        health -= damage;
        if (health <= 0){
            if (team == Team.Enemy){
                Die();
            }
            else{
                health = fullHealth;
                Player.Instance.transform.position = Player.Instance.initialPosition;
            }
        }
    }
    protected virtual void FallIntoTheEnd(){
        if (transform.position.y <= -15){
            transform.position = initialPosition;
        }
    }
    public virtual void Die(){
        Destroy(this.gameObject);
    }
}
