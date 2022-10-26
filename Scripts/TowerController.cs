using System.Threading;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private float mSpeed = 200;

    void Update()
    {
        // for PC
        if(Input.GetMouseButton(0) && !GameManager.IsPaused)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * mSpeed * Time.deltaTime, 0);
        }
        /*
        // for Mobile
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDelta * mSpeed * Time.deltaTime, 0);
        }*/
        return;
    }
}
