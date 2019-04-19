using System.Collections;
using UnityEngine;

public class Sonar : MonoBehaviour {
	[SerializeField]
	private Data_Sonar projectileData;

	//Time when sonar can be cast again
	private float nextCastTime = 0;

	//Coordinates for 12-way directional fire
	private static readonly Vector2[] fireDirections = {
		//Quadrant 1 (+,+)
		Vector2.up,
		new Vector2(0.5f, 0.866f),
		new Vector2(0.866f, 0.5f),
		//Quadrant 4 (+,-)
		Vector2.right,
		new Vector2(0.866f, -0.5f),
		new Vector2(0.5f, -0.866f),
		//Quadrant 3 (-,-)
		Vector2.down,
		new Vector2(-0.5f, -0.866f),
		new Vector2(-0.866f, -0.5f),
		//Quadrant 2 (-,+)
		Vector2.left,
		new Vector2(-0.866f, 0.5f),
		new Vector2(-0.5f, 0.866f)
	};

	private void Start() {
		this.StartCoroutine("ReadInput");
	}

	private IEnumerator ReadInput() {
		while (true) {
			if (Input.GetKeyDown(this.projectileData.sonarKey) || Input.GetKey(this.projectileData.sonarKey)) {
				if (Time.time > this.nextCastTime) {
					FireSonar();
				}
			}

			yield return null;
		}
	}

	private void FireSonar() {
		Debug.Log("Firing Sonar!");

		int i = 0;

		//For each firing direction
		foreach (var direction in fireDirections) {
			//Spawn projectile
			var projectile = Instantiate(
				//Object data
				Resources.Load("SonarProjectile") as GameObject,
				//Position data
				this.transform.position + (new Vector3(direction.x, direction.y) * this.projectileData.sonarOffset),
				//Rotation data
				Quaternion.Euler(new Vector3(-90 + (i * -30), -90, -90)));

			//Set projectile data
			projectile.AddComponent<SonarProjectile>().projectileData = this.projectileData;

			i++;
		}

		this.nextCastTime = Time.time + this.projectileData.sonarCooldown;
	}
}
