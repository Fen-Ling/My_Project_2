using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class Stone_Spawner : MonoBehaviour
    {
        [SerializeField]
        private Transform m_point;
        [SerializeField]
        private GameObject[] m_Prefabs;
        private void Start()
        {
            if (m_point == null)
            {
                m_point = transform;
            }
        }
        public GameObject Spawn()
        {
            int index = Random.Range(0, m_Prefabs.Length);

            return Instantiate(m_Prefabs[index], m_point.position, m_point.rotation);
        }

    }
}