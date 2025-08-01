using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;
	[SerializeField] Transform cameraTransform;
    float xRotation = 0f;
	float yRotation = 0f;

	const string xAxis = "Mouse X";
	const string yAxis = "Mouse Y";

    public float speed = 5f;
    public Rigidbody rb;
    public GameObject charObj;
    void Start()
    {
	Cursor.lockState = CursorLockMode.Locked;
	Cursor.visible = false;
    }

    void Update()
{
    Vector3 move = Vector3.zero;

    if (Input.GetKey(KeyCode.D))
        move += transform.right;
    if (Input.GetKey(KeyCode.A))
        move -= transform.right;
    if (Input.GetKey(KeyCode.W))
        move += transform.forward;
    if (Input.GetKey(KeyCode.S))
        move -= transform.forward;
    if (Input.GetKey(KeyCode.Space))
        move += transform.up;

    transform.position += move.normalized * speed * Time.deltaTime;

    xRotation += Input.GetAxis(xAxis) * sensitivity;
    yRotation += Input.GetAxis(yAxis) * sensitivity;
    yRotation = Mathf.Clamp(yRotation, -yRotationLimit, yRotationLimit);
    transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
    if (cameraTransform != null)
        cameraTransform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
}
    
}
