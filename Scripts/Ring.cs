using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform mPlayerTrans;
    private readonly int mScore = 3;

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
            ScoreManager.AddScore(mScore);
            GameManager.PassedRingNum++;
            Destroy(gameObject);
        }
        return;
    }
}
