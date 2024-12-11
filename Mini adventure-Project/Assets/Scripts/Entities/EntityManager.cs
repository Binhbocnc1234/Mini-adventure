using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : Singleton<EntityManager>
{
    // Start is called before the first frame update
    public List<Entity> entities;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KillAllEnemy(){
        foreach(Transform trans in transform){
            Entity entity = trans.GetComponent<Entity>();
            if (entity.team == Team.Enemy){
                entity.Die();
            }
        }
    }

}
