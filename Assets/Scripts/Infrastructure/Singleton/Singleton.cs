using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SingletonAwake();
    }

    public virtual void OnDestroy()
    {
        if (_instance != this)
            return;
        
        _instance = null;
        SingletonOnDestroy();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    protected virtual void SingletonAwake()
    {

    }

    protected virtual void SingletonOnDestroy()
    {

    }
}