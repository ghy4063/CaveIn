using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FadingLight : MonoBehaviour {
	[HideInInspector]
	public float fadeDuration;

	private new Light light;

	private void Start() {
		this.light = GetComponent<Light>();

		this.StartCoroutine("FadeLight");
	}

	private IEnumerator FadeLight() {
		float intensityTick = this.light.intensity / this.fadeDuration;

		while (this.light.intensity > 0) {
			this.light.intensity -= intensityTick * Time.deltaTime;

			yield return null;
		}

		Destroy(this.gameObject);
	}
}
