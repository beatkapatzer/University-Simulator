using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed;
    public float maxFloatHeight = 10;
    public float minFloatHeight;

    public Camera freelookCamera;
    private float currentHeight;
    private Animation anim;
    private float xRotation;
    void Start()
    {
        currentHeight = transform.position.y;
        anim = GetComponent<Animation>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        xRotation = freelookCamera.transform.rotation.eulerAngles.x;


        if (Input.GetKey(KeyCode.W))
        {
            MoveCharacter();
        }
        else
        {
            DisableMovent();
        }

        currentHeight = Mathf.Clamp(transform.position.y, currentHeight, maxFloatHeight);
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

    }

    private void MoveCharacter()
    {
        Vector3 cameraForward = new Vector3(freelookCamera.transform.forward.x, 0, freelookCamera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, 0), Space.Self);



        Vector3 forward = freelookCamera.transform.forward;
        Vector3 flyDirection = forward.normalized;

        currentHeight += flyDirection.y * moveSpeed * Time.deltaTime;
        currentHeight = Mathf.Clamp(currentHeight, minFloatHeight, maxFloatHeight);

        transform.position += flyDirection * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);


    }

    private void DisableMovent()
    {

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

    }
}
