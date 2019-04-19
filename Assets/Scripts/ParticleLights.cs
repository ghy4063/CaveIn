using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleLights : MonoBehaviour {
	// The amount of lights that will be in all at once
	public int lightLimit = 20;
	// How bright the lights will be
	public float LightIntencityMultiplayer = 1;
	// Does it render shadows
	public LightShadows Shadows = LightShadows.None;

	// This particle system
	private new ParticleSystem particleSystem;
	// The paricles being rendered
	private ParticleSystem.Particle[] particles;
	// The lights being added
	private Light[] lights;

	// Use this for initialization
	void Start() {
		// Grab the particle system on this object
		this.particleSystem = GetComponent<ParticleSystem>();
		// if the number of particles is greater than the light limit
		if (this.particleSystem.main.maxParticles > this.lightLimit) {
			// Set the max number of particles to the light limit
			this.particleSystem.maxParticles = this.lightLimit;
		}
		// Set partivles equal tot he max number of particles 
		this.particles = new ParticleSystem.Particle[this.particleSystem.main.maxParticles];
		// Set lights equal to the max number of particles 
		this.lights = new Light[this.particleSystem.main.maxParticles];
		// for each light in lights
		for (int i = 0; i < this.lights.Length; i++) {
			// make place holder object
			var lightObject = new GameObject();
			// Add the light component of the object 
			this.lights[i] = lightObject.AddComponent<Light>();
			// set its transform
			this.lights[i].transform.parent = this.transform;
			// Set the brightness
			this.lights[i].intensity = 0;
			// Set if it renders shadows 
			this.lights[i].shadows = this.Shadows;
		}

	}

	// Update is called once per frame
	void Update() {
		// The number of particels in game
		int count = this.particleSystem.GetParticles(this.particles);
		// For loop for adding lights 
		for (int i = 0; i < count; i++) {
			// turn lights on
			this.lights[i].gameObject.SetActive(true);
			// Set its postion
			this.lights[i].transform.position = this.particles[i].position;
			// Set the color
			this.lights[i].color = this.particles[i].GetCurrentColor(this.particleSystem);
			// Set the range 
			this.lights[i].range = this.particles[i].GetCurrentSize(this.particleSystem);
			// Set the intensity
			this.lights[i].intensity = this.particles[i].GetCurrentColor(this.particleSystem).a / 255f * this.LightIntencityMultiplayer;
		}
		// This turn the lights off
		for (int i = count; i < this.particles.Length; i++) {
			this.lights[i].gameObject.SetActive(false);
		}
	}
}
