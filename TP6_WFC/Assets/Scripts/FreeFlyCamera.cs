using UnityEngine;

public class FreeFlyCamera : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    [SerializeField]
    private float rotationSpeed = 100f;

    private void Update()
    {
        // Translation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float altitudeInput = Input.GetAxis("Jump");
        Vector3 translation = new Vector3(horizontalInput, altitudeInput, verticalInput);
        transform.Translate(translation * movementSpeed * Time.deltaTime);

        // Rotation
        float horizontalRotationInput = Input.GetAxis("HorizontalRotation");
        float verticalRotationInput = Input.GetAxis("VerticalRotation");
        transform.Rotate(
            Vector3.up,
            horizontalRotationInput * rotationSpeed * Time.deltaTime,
            Space.World
        );
        transform.Rotate(
            Vector3.right,
            -verticalRotationInput * rotationSpeed * Time.deltaTime,
            Space.Self
        );
    }
}
