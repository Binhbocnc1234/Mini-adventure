using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Portal : Interactable
{
    // Start is called before the first frame update
    public Image panel;
    private Timer timer = new Timer(3f);
    public string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isTriggered){
            if (timer.Count()){
                SceneManager.LoadScene(sceneName);
            }
            Color color = panel.color;
            color.a = Mathf.Min((timer.curTime*1.5f)/timer.totalTime, 1f);
            panel.color = color;
        }
    }
    protected override void Trigger()
    {
        base.Trigger();
        tmp.text = "You did it!";
        EntityManager.Instance.KillAllEnemy();
        
    }
}
