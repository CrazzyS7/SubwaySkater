using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody mPlayerRB;
    private float mBounceForce = 6.0f;

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
            GameMAnager.IsGameOver = true;
            Debug.Log("Game Over");
        }
        else if(materialName == "FinalColor (Instance)")
        {
            GameMAnager.LevelCompleted = true;
            Debug.Log("Completed level");
        }
        return;
    }
}
