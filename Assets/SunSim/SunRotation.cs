using UnityEngine;

public class SunRotation : MonoBehaviour
{
	public Light sunLight;
	
	[Range(-90f, 90f)]
	public float latitude = 0f;

	[Range(0f, 24f)]
	public float timeOfDay = 12f;

	void Update()
	{
		timeOfDay = Mathf.Repeat(timeOfDay, 24f);
		float sunAngle = (timeOfDay / 24f) * 360f;
		Quaternion latitudeRotation = Quaternion.Euler(latitude, 0f, 0f);
		transform.rotation = Quaternion.Euler(sunAngle - 90f, 0f, 0f) * latitudeRotation;

		// AdjustSunIntensity();
	}

	// void AdjustSunIntensity()
	// {
	// 	float dotProduct = Vector3.Dot(transform.forward, Vector3.down);
	// 	float intensity = Mathf.Clamp01(dotProduct);
	//
	// 	if (sunLight != null)
	// 	{
	// 		sunLight.intensity = intensity;
	// 		sunLight.color = Color.Lerp(Color.red, Color.white, intensity);
	// 	}
	// }
}