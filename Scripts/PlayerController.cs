using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float mBounceForce = 6.0f;
    private AudioManager mAudioManager;
    private Rigidbody mPlayerRB;

    private void Start()
    {
        mAudioManager = FindObjectOfType<AudioManager>();
        mPlayerRB = GetComponent<Rigidbody>();
        return;
    }
    private void OnCollisionEnter(Collision _other)
    {
        mPlayerRB.velocity = new Vector3(mPlayerRB.velocity.x, mBounceForce, mPlayerRB.velocity.z);
        string materialName = _other.transform.GetComponent<MeshRenderer>().material.name;

        if(!GameManager.IsLevelCompleted)
            mAudioManager.Play("bounceSFX");

        if(materialName == "UnsafeColor (Instance)")
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.IsGameOver = true;
            mAudioManager.Play("gameOverMSC");
        }
        else if(materialName == "FinalColor (Instance)" && !GameManager.IsLevelCompleted)
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.IsLevelCompleted = true;
            mAudioManager.Play("levelCompleteMSC");
        }
        return;
    }
}
