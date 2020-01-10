using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Player.HealthBarPLayer = healthBar;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
