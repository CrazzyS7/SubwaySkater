using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject mPlayer;
    private Vector3 mOffset = Vector3.zero;
    private readonly float mSmoothSpeed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        mOffset = transform.position - mPlayer.transform.position;
        return;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, mPlayer.transform.position + mOffset, mSmoothSpeed);
        transform.position = newPos;
        return;
    }
}
