using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    bool sawOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!sawOnce)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Time.timeScale = 0;
        }
        sawOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            Time.timeScale = 1;
            GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
