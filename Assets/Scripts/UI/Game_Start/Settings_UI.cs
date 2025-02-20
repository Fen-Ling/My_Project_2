using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_UI : MonoBehaviour
{
	public Slider sliderVal;
	public Dropdown resolutionDropdown;
	public Toggle fullscreenToggle;
	private Resolution[] resolutions;

	private void Start()
	{
		LoadSettings();
	}

	public void LoadSettings()
	{
		Settings_Data settings = SettingsDataManager.LoadSettings();

		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();

		int currResolutionIndex = 0;

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == settings.width && resolutions[i].height == settings.height)
			{
				currResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currResolutionIndex;
		resolutionDropdown.RefreshShownValue();

		AudioListener.volume = settings.volume;
		sliderVal.value = settings.volume;

		fullscreenToggle.isOn = settings.isFullScreen;

		ApplySettings(settings);
	}
	public void ChangeVolume(float value)
	{
		AudioListener.volume = value;
		sliderVal.value = value;
	}

	public void ChangeResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void ChangeFullscreenMode(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void SaveSettings()
	{
		Settings_Data settings = new Settings_Data
		{
			volume = AudioListener.volume,
			width = resolutions[resolutionDropdown.value].width,
			height = resolutions[resolutionDropdown.value].height,
			isFullScreen = fullscreenToggle.isOn
		};

		SettingsDataManager.SaveSettings(settings);
		ApplySettings(settings);
	}

	private void ApplySettings(Settings_Data settings)
	{
		AudioListener.volume = settings.volume;
		sliderVal.value = settings.volume;

		Screen.SetResolution(settings.width, settings.height, settings.isFullScreen);
		fullscreenToggle.isOn = settings.isFullScreen;
	}
}