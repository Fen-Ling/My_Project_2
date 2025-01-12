using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameHistory_State : MonoBehaviour
    {
        public GameObject GameHistoryUI;
        public Main_Menu_State mainMenuState;
        public TextMeshProUGUI HistoryText;
        private string history = "";

        private void Start()
        {
            LoadHistory();
            UpdateHistoryUI();
        }
        private void OnEnable()
        {
            GameHistoryUI.SetActive(true);
        }
        private void OnDisable()
        {
            if (GameHistoryUI)
            {
                GameHistoryUI.SetActive(false);
            }
        }
        public void BackToMainMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
        public void AddScore(int score)
        {
            history += $"Очки: {score}\n";
            SaveHistory();
            UpdateHistoryUI();
        }
        private void UpdateHistoryUI()
        {
            HistoryText.text = history;
        }

        
        private void LoadHistory()
        {
            history += PlayerPrefs.GetString("GameHistory");
        }

        
        private void SaveHistory()
        {
            PlayerPrefs.SetString("GameHistory", history);
            PlayerPrefs.Save();
        }
        public void ClearHistory()
    {
        history = "";
        PlayerPrefs.DeleteKey("GameHistory");
        UpdateHistoryUI();
    }

    }
}