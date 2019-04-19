using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform targetToFollow;
	public float cameraMoveSpeed;
	public Vector3 cameraPosition = new Vector3 (0, 0, -10);

	private void Update () {
		if (targetToFollow != null) {
			this.gameObject.transform.position = Vector3.Lerp (this.gameObject.transform.position, this.targetToFollow.position + this.cameraPosition, this.cameraMoveSpeed * Time.deltaTime);
		}
	}
}
