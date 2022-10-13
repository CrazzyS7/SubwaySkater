using UnityEngine;

public class TowerController : MonoBehaviour
{
    private float mSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * mSpeed * Time.deltaTime, 0);
        }
        return;
    }
}
