
using UnityEngine;

public class DontDestroySceneTransition : MonoBehaviour
{
    private static DontDestroySceneTransition _instance;
    public static DontDestroySceneTransition Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DontDestroySceneTransition>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(DontDestroySceneTransition).Name;
                    _instance = obj.AddComponent<DontDestroySceneTransition>();
                }

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}

