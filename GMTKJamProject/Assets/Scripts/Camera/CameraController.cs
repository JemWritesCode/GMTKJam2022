using UnityEngine;

public class CameraController : MonoBehaviour {
  public Transform cameraTarget;
  public Vector3 offset;

  public float minZoom = -5f;
  public float maxZoom = 15f;

  public float currentZoom = 10f;
  public float zoomSpeed = 4f;

  public float currentPitch = 1f;
  public float pitchSpeed = 5f;

  public float currentYaw = 0f;
  public float yawSpeed = 250f;

  void Update() {
    currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

    if (Input.GetMouseButton(1)) {
      currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
      currentPitch += Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;
    }
  }

  void LateUpdate() {
    transform.position = cameraTarget.position - (offset * currentZoom);
    transform.LookAt(cameraTarget.position + Vector3.up * currentPitch);

    transform.RotateAround(cameraTarget.position, Vector3.up, currentYaw);
    transform.RotateAround(cameraTarget.position, Vector3.right, currentPitch);
  }
}
