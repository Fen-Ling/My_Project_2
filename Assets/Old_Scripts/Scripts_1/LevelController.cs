using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public Sound_Stoun S_sound;
        public Sound_Game_Over G_O_sound;
        public Stone_Spawner stoneSpawner;
        public GameHistory_State gameHistory;
        private float m_timer;
        public float m_delay = 2f;
        private float m_delay2;
        private int m_score = 0;
        private List<Stone> m_stones = new List<Stone>();
        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStick;
            m_delay2 = m_delay;
            m_score = 0;

            ClearStones();
        }
        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStick;
            }
        }
        public void SetDelay(float newDelay)
        {
            m_delay = newDelay;
        }
        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }

            m_stones.Clear();
        }
        private void FixedUpdate()
        {
            if (Time.time > m_timer + m_delay2)
            {
                m_timer = Time.time;

                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();

                stone.onCollisionStone += OnCollisionStone;

                m_stones.Add(stone);
                m_delay2 = Mathf.Max(0.5f, m_delay2 - 0.1f);
            }
        }
        private void OnCollisionStick()
        {
            S_sound.PlayStoneSound();
            m_score++;
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }
        private void OnCollisionStone()
        {
            G_O_sound.PlayGameOverSound();
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
            gameHistory.AddScore(m_score);
            PlayerPrefs.Save();
            ClearStones();
            // gameHistory.ClearHistory();
        }
    }
}