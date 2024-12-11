using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    // Start is called before the first frame update
    List<House> checkPoints = new List<House>();
    public int ind = 0;
    void Start()
    {
        foreach(Transform cp in transform){
            House checkpoint = cp.GetComponent<House>();
            checkPoints.Add(checkpoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetCheckPoint(){
        return checkPoints[ind].transform.position;
    }
}
