using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}