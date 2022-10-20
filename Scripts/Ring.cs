using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform mPlayerTrans;

    // Start is called before the first frame update
    void Start()
    {
        mPlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (mPlayerTrans.position.y < transform.position.y)
        {
            FindObjectOfType<AudioManager>().Play("whooshSFX");
            GameManager.PassedRingNum++;
            Destroy(gameObject);
        }
    }
}
