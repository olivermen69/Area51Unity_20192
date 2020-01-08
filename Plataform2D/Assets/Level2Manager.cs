using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    private Transform startPos;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Level 2 start");
        //Player.instance.transform.position = startPos.position;
        //Player.SetPropPosition = startPos.position;
        Player.SetPropPosition2 = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
