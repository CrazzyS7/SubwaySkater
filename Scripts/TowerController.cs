using UnityEngine;

public class TowerController : MonoBehaviour
{
    private float mSpeed = 200;

    void Update()
    {
        if(Input.GetMouseButton(0) && !GameManager.IsPaused)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * mSpeed * Time.deltaTime, 0);
        }
        return;
    }
}
