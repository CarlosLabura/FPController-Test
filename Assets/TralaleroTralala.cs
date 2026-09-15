using UnityEngine;

public class TralaleroTralala : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    [SerializeField] private Camera Camera;
    void Update()
    {
        gameObject.transform.Translate(new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * 20,
            0,
            Input.GetAxis("Vertical") * Time.deltaTime * 20
        ));
        Camera.transform.position = gameObject.transform.position;

        Camera.transform.rotation = Quaternion.Euler(new Vector3(
            Camera.transform.rotation.eulerAngles.x - Input.mousePositionDelta.y * Time.deltaTime * 20,
            Camera.transform.rotation.eulerAngles.y + Input.mousePositionDelta.x * Time.deltaTime * 20,
            0
        ));
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(
            gameObject.transform.rotation.eulerAngles.x,
            Camera.transform.rotation.eulerAngles.y,
            gameObject.transform.rotation.eulerAngles.z
        ));
    }
}
