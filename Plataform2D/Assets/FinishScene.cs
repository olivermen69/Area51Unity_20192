using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter2d(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            //FinishScene
            SceneManager.LoadScene(1);
        }
    }
}
