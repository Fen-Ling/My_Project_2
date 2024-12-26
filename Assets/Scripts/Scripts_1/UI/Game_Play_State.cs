using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class Game_Play_State : MonoBehaviour
    {
        public Game_Over_State GameOverState;
        public PlayerController playerController;
        public LevelController levelController;
        public GameObject GamePlayUI;
        public TextMeshProUGUI Score_Text;
        private void OnEnable()
        {
            GamePlayUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;
            levelController.onGameOver += OnGameOver;
            levelController.onScoreInc += OnScoreInc;

            OnScoreInc(0);

        }
        private void OnDisable()
        {
            if (GamePlayUI)
            {
                GamePlayUI.SetActive(false);
            }

            if (playerController)
            {
                playerController.enabled = false;
            }

            if (levelController)
            {
                levelController.enabled = false;
                levelController.onGameOver -= OnGameOver;
                levelController.onScoreInc -= OnScoreInc;
            }
        }
        private void OnScoreInc(int score)
        {
            Score_Text.text = $"Очки: {score}";
        }
        private void OnGameOver(int score)
        {
            Game_Instance.score = Mathf.Max(Game_Instance.score, score);

            gameObject.SetActive(false);

            GameOverState.gameObject.SetActive(true);
        }
    }
}