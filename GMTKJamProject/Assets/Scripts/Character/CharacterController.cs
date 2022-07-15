using UnityEngine;

public class CharacterController : MonoBehaviour {

  readonly float Interpolation = 10f;

  public float moveSpeed = 2f;
  public float turnSpeed = 200f;

  float currentVertical = 0f;
  float currentHorizontal = 0f;

  Vector3 currentDirection = Vector3.zero;

  void FixedUpdate() {
    float v = Input.GetAxis("Vertical");
    float h = Input.GetAxis("Horizontal");

    Transform camera = Camera.main.transform;

    currentVertical = Mathf.Lerp(currentVertical, v, Time.deltaTime * Interpolation);
    currentHorizontal = Mathf.Lerp(currentHorizontal, h, Time.deltaTime * Interpolation);

    Vector3 direction = camera.forward * currentVertical + camera.right * currentHorizontal;
    float directionLength = direction.magnitude;
    direction = direction.normalized * directionLength;

    if (direction != Vector3.zero) {
      currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * Interpolation);

      transform.rotation = Quaternion.LookRotation(currentDirection);
      transform.position += currentDirection * moveSpeed * Time.deltaTime;
    }
  }
}
