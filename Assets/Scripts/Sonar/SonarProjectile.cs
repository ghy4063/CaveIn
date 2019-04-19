using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SonarProjectile : MonoBehaviour {
	[HideInInspector]
	public Data_Sonar projectileData;

	private void Start() {
		this.transform.localScale =
			new Vector3(this.projectileData.scaleStart, 1, this.projectileData.scaleStart);
		//this.GetComponent<BoxCollider>().size = this.transform.localScale;

		var light = this.GetComponent<Light>();
		light.color = this.projectileData.sonarColor;
		light.intensity = this.projectileData.sonarIntensity;
		light.range = this.projectileData.sonarRange;
	}

	private void Update() {
		//this.projectileData.scaleSpeed * Time.deltaTime
		this.transform.localScale += new Vector3(
			this.projectileData.scaleSpeed * Time.deltaTime,
			0,
			(this.projectileData.scaleSpeed * Time.deltaTime) * 0.25f);

		this.transform.position += new Vector3(this.transform.forward.x, this.transform.forward.y, 0)
			* this.projectileData.moveSpeed * Time.deltaTime;
	}

	public void OnCollisionEnter(Collision collision) {
		Debug.LogWarning("Collision!", this.gameObject);

		var lightObject = new GameObject();
		lightObject.transform.position = collision.contacts[0].point;

		var lightComponent = lightObject.AddComponent<Light>();
		lightComponent.type = LightType.Point;
		lightComponent.color = this.projectileData.remnantColor;
		lightComponent.intensity = this.projectileData.remnantIntensity;
		lightComponent.shadows = LightShadows.None;
		lightComponent.cullingMask = this.projectileData.cullingMask;

		lightObject.AddComponent<FadingLight>().fadeDuration = this.projectileData.fadeDuration;

		Destroy(this.gameObject);
	}
}
