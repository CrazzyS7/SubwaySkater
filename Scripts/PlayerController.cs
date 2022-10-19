using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody mPlayerRB;
    private readonly float mBounceForce = 6.0f;

    private void Start()
    {
        mPlayerRB = GetComponent<Rigidbody>();
        return;
    }
    private void OnCollisionEnter(Collision _other)
    {
        mPlayerRB.velocity = new Vector3(mPlayerRB.velocity.x, mBounceForce, mPlayerRB.velocity.z);
        string materialName = _other.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "UnsafeColor (Instance)")
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.IsGameOver = true;
        }
        else if(materialName == "FinalColor (Instance)")
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.LevelCompleted = true;
        }
        return;
    }
}
