using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingHurt : MonoBehaviour
{
	public float intensity = 0;
	PostProcessVolume _volume;
	Vignette _vignette;
	[SerializeField] private PostProcessVolume _volume2;
	private Vignette _vignette2;
	public Color vignetteColor = Color.red;

	private Coroutine damageEffectCoroutine;

	void Start()
	{
		_volume = GetComponent<PostProcessVolume>();
		_volume.profile.TryGetSettings(out _vignette);
		_volume2.profile.TryGetSettings(out _vignette2);
		if (!_vignette)
		{
			Debug.Log("EMPTYYYYY");
		}
		else
		{
			_vignette.enabled.Override(false);
			_vignette.active = false;
		}
	}

	public void StartDamageEffect()
	{
		// Stop the existing coroutine if it's running
		if (damageEffectCoroutine != null)
		{
			StopCoroutine(damageEffectCoroutine);
		}

		// Start the new coroutine
		damageEffectCoroutine = StartCoroutine(TakeDamageEffect());
	}

	public IEnumerator TakeDamageEffect()
	{
		intensity = 0.4f;
		_vignette.active = true;
		_vignette.enabled.Override(true);
		_vignette.intensity.Override(0.4f);
		yield return new WaitForSeconds(0.4f);

		while (intensity > 0)
		{
			intensity -= 0.01f;
			if (intensity < 0) intensity = 0;
			_vignette.intensity.Override(intensity);
			_vignette.color.Override(Color.Lerp(Color.black, vignetteColor, intensity / 0.4f));

			yield return new WaitForSeconds(0.1f);
		}

		_vignette.enabled.Override(false);
		_vignette.active = false;

		while (intensity < 0.45)
		{
			intensity += 0.01f;
			if (intensity > 0.45) intensity = 0.45f;
			_vignette.intensity.Override(intensity);
			_vignette.color.Override(Color.Lerp(vignetteColor, Color.black, intensity / 0.45f));

			yield return new WaitForSeconds(0.1f);
		}

		damageEffectCoroutine = null; // Reset the coroutine reference
		yield break;
	}
}
