using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEnterEvents()
    {
        print("trigger enter");
    }
    public void TriggerExitEvents()
    {
        print("trigger exit");
    }
    public void TriggerIntermittendEvents()
    {
        print("trigger Intermittent");
    }
}
