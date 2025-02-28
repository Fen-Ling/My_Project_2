using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        LoadSettings();
        cam.gameObject.SetActive(true);
    }

    public void LoadSettings()
    {
        Settings_Data settings = SettingsDataManager.LoadSettings();

        Screen.SetResolution(settings.width, settings.height, settings.isFullScreen);

        AudioListener.volume = settings.volume;

        Screen.fullScreen = settings.isFullScreen;
    }
}