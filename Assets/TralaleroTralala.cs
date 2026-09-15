using UnityEngine;

public class TralaleroTralala : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public int MovementSpeed = 2000;
    public float Sensivity = 20;
    public int JumpForce = 200;
    [SerializeField] private Camera Camera;
    private bool TouchingFloor = true;
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed,
            0,
            Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed
        ));
        Camera.transform.position = gameObject.transform.position;


        TouchingFloor = Physics.Raycast(
            new Vector3(
                gameObject.GetComponent<MeshRenderer>().bounds.center.x,
                gameObject.GetComponent<MeshRenderer>().bounds.min.y, 
                gameObject.GetComponent<MeshRenderer>().bounds.center.z
            ),
            Vector3.down,
            0.1f
        );
        if (Input.GetKeyDown(KeyCode.Space) && TouchingFloor)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,JumpForce,0));
        }
        Debug.Log(TouchingFloor);


        Camera.transform.rotation = Quaternion.Euler(new Vector3(
            Camera.transform.rotation.eulerAngles.x - Input.mousePositionDelta.y * Time.deltaTime * Sensivity,
            Camera.transform.rotation.eulerAngles.y + Input.mousePositionDelta.x * Time.deltaTime * Sensivity,
            0
        ));
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(
            gameObject.transform.rotation.eulerAngles.x,
            Camera.transform.rotation.eulerAngles.y,
            gameObject.transform.rotation.eulerAngles.z
        ));
    }
}
