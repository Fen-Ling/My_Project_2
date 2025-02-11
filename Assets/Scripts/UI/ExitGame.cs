using UnityEngine;

public class ExitGame : MonoBehaviour

    {
        public void Quit()
        {
#if UNITY_EDITOR

            QuestDataManager.ResetQuestData();
            UnityEditor.EditorApplication.isPlaying = false;
#else

            QuestDataManager.ResetQuestData();
            Application.Quit();
#endif
        }
    }