using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sonar Projectile Data")]
public class Data_Sonar : ScriptableObject {
	[Header("Sonar Info")]
	public KeyCode sonarKey = KeyCode.Space;
	[Range(2, 6)]
	public int sonarCooldown = 4;

	[Header("Movement Data")]
	[Range(0.5f, 4)]
	public float sonarOffset = 2;
	public float moveSpeed = 3;
	public float scaleStart = 0.5f;
	public float scaleSpeed = 2;

	[Header("Travel Light Data")]
	public Color sonarColor = Color.HSVToRGB(175, 62, 124);
	[Range(0.5f, 10)]
	public float sonarIntensity = 2;
	[Range(1, 25)]
	public int sonarRange = 1;

	[Header("Remnant Light Data")]
	public LayerMask cullingMask = 0;
	public Color remnantColor = Color.HSVToRGB(175, 62, 124);
	[Range(0.5f, 10)]
	public float remnantIntensity = 2;
	[Range(1, 25)]
	public int remnantLightRange = 5;
	[Range(0.5f, 5)]
	public float fadeDuration = 5f;
}
