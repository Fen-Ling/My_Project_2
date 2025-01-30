// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Golf
// {
//     public class Game_Over_State : MonoBehaviour
//     {
//         public GameObject GameOverUI;
//         public Main_Menu_State mainMenuState;
//         public Game_Play_State gamePlayState;

//         private void OnEnable()
//         {
//             GameOverUI.SetActive(true);
//         }
//         private void OnDisable()
//         {
//             if (GameOverUI)
//             {
//                 GameOverUI.SetActive(false);
//             }
//         }

//         public void Restart()
//         {
//             gameObject.SetActive(false);
//             gamePlayState.gameObject.SetActive(true);
//         }

//         public void BackToMainMenu()
//         {
//             gameObject.SetActive(false);
//             mainMenuState.gameObject.SetActive(true);
//         }
//     }
// }
