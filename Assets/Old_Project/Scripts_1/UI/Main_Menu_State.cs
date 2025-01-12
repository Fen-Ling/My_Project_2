using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class Main_Menu_State : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public Game_Play_State GamePlayState;
        public Settings_State SettingState;
        public GameHistory_State gameHistoryState;
        public TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            mainMenuUI.SetActive(true);
            scoreText.text = $"Макс. Очки: {Game_Instance.score}";
        }

        private void OnDisable()
        {
            mainMenuUI.SetActive(false);
        }

        public void Play()
        {
            gameObject.SetActive(false);
            GamePlayState.gameObject.SetActive(true);
        }
        public void Settings()
        {
            gameObject.SetActive(false);
            SettingState.gameObject.SetActive(true);
        }

        public void History()
        {
            gameObject.SetActive(false);
            gameHistoryState.gameObject.SetActive(true);
        }
    }
}