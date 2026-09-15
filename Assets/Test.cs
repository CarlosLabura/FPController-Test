using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public float Sensitivity = 1;
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(
            transform.rotation.eulerAngles.x - Input.mousePositionDelta.y * Time.deltaTime * Sensitivity,
            transform.rotation.eulerAngles.y + Input.mousePositionDelta.x * Time.deltaTime * Sensitivity,
            transform.rotation.eulerAngles.z
        ));
        
        transform.Translate(new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * Sensitivity,
            0,
            Input.GetAxis("Vertical") * Time.deltaTime * Sensitivity
        ));
    }
}
