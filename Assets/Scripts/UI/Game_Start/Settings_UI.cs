using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_UI : MonoBehaviour
{
	public AudioSource audioSource;
	public Slider sliderVal;
	public Dropdown resolutionDropdown;
	public Toggle fullscreenToggle;

	private Resolution[] resolutions;
	private int currResolutionIndex;


	private void Start()
	{
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].Equals(Screen.currentResolution))
			{
				currResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currResolutionIndex;
		resolutionDropdown.RefreshShownValue();

		audioSource.loop = true;
		audioSource.Play();

		LoadSettings();

	}


	public void ChangeVolume(float value)
	{
		sliderVal.value = value;
		audioSource.volume = sliderVal.value;

	}

	public void ChangeResolution(int resolutionindex)
	{
		Resolution resolution = resolutions[resolutionindex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


	}

	public void ChangeFullscreenMode(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;

	}

	public void SaveSettings()
	{
		PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
		PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
		PlayerPrefs.SetFloat("Volume", audioSource.volume);
		PlayerPrefs.Save();
	}

	private void LoadSettings()
	{
		if (PlayerPrefs.HasKey("ResolutionIndex"))
		{
			resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
			resolutionDropdown.RefreshShownValue();
			ChangeResolution(resolutionDropdown.value);
		}

		if (PlayerPrefs.HasKey("Fullscreen"))
		{
			bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
			fullscreenToggle.isOn = isFullscreen;
			ChangeFullscreenMode(isFullscreen);
		}

		if (PlayerPrefs.HasKey("Volume"))
		{
			audioSource.volume = PlayerPrefs.GetFloat("Volume");
			ChangeVolume(audioSource.volume);
		}
	}

}
