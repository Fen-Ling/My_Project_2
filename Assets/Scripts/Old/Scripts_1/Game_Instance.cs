using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Game_Instance : MonoBehaviour
    {
        public static int score = 0;

        public Transform states;

        private void OnEnable()
        {
            score = PlayerPrefs.GetInt("Макс. Очки");

        }
        public void OnDisable()
        {
            PlayerPrefs.SetInt("Макс. Очки", score);
            PlayerPrefs.Save();

        }
        private void Start()
        {
            foreach (Transform child in states)
            {
                child.gameObject.SetActive(false);
            }
            states.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}