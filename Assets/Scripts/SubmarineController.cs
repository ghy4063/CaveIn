using UnityEngine;

public class SubmarineController : MonoBehaviour {
	public Camera playerCamera;

	[Header("Player Controls")]
	public KeyCode boostKey;

	[Header("Player Variables")]
	public int playerHealth;
	public float playerSpeed;
	public float maxSpeed = 1.5f;
	public float boostSpeed;
	public float boostLifeTime;
	public float boostCoolDown;
	public float offsetFromMouse;
	public float InvulTimer;
	public bool stopPlayerControls = true;

	private float Invulnerable;
	private float boostCountdown;
	private float boostLifeTimeCountdown;
	private bool boostActive = false;
	private bool InvulActive = false;

	void Start() {
		this.boostCountdown = this.boostCoolDown;
		this.boostLifeTimeCountdown = this.boostLifeTime;
		this.Invulnerable = 0;
	}

	void Update() {
		if (stopPlayerControls == true) {
			return;
		}
		if (this.boostActive == false) {
			this.boostCountdown -= Time.deltaTime;

			if (this.boostCountdown <= 0) {
				if (Input.GetKeyDown(this.boostKey)) {
					this.playerSpeed += this.boostSpeed;
					this.boostActive = true;
				}
			}
		}
		if (this.boostActive) {
			if (this.boostLifeTimeCountdown <= 0) {
				this.playerSpeed -= this.boostSpeed;
				this.boostLifeTimeCountdown = this.boostLifeTime;
				this.boostCountdown = this.boostCoolDown;
				this.boostActive = false;
			} else {
				this.boostLifeTimeCountdown -= Time.deltaTime;
			}
		}

		Vector3 target = this.playerCamera.ScreenToWorldPoint(Input.mousePosition);
		target.z = 0;

		if (Vector3.Distance(this.transform.position, target) > this.offsetFromMouse) {
			float newPlayerSpeed = this.playerSpeed * Time.deltaTime;
			newPlayerSpeed *= Vector3.Distance(this.transform.position, target);

			if (newPlayerSpeed > this.maxSpeed) {
				newPlayerSpeed = this.maxSpeed;
			}

			this.transform.position = Vector3.MoveTowards(this.transform.position, target, newPlayerSpeed);
		}

		Vector3 position = this.playerCamera.WorldToScreenPoint(this.transform.position);
		Vector3 direction = Input.mousePosition - position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (this.playerHealth > 3) {
			this.playerHealth = 3;
		}

		if (this.Invulnerable > 0) {//
			this.Invulnerable -= Time.deltaTime;//slowly tick down the timer in seconds
			this.InvulActive = true;//makes sure invul is true
			Debug.Log("I am invincible");
		} else { //naturally invulnoff
			this.InvulActive = false;
		}
	}

	//What happens when The player hits an enemy
	void OnCollisionEnter(Collision other) {//checks to see if it hit enemy or hazard
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Hazard") {
			if (this.InvulActive == false) {//if not invunlerable
				this.Invulnerable = this.InvulTimer;//set time invulnerable to invultime
				this.playerHealth = this.playerHealth - 1;//reduce health by one
				Debug.Log("taking damage");
				this.InvulActive = true;//set invulactive to true

			} else if (this.InvulActive == true) {
				//do nothing
			}
		}
	}
}
