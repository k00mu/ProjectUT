using UnityEngine;

public class TimeController : MonoBehaviour
{
	public SunRotation sunRotation;

	public float timeScale = 1f;

	void Update()
	{
		if (sunRotation != null)
		{
			sunRotation.timeOfDay += timeScale * Time.deltaTime;
		}
	}
}