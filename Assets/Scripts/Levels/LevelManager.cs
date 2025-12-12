using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IService
{
    [SerializeField] ISerializationCallbackReceiver menuScene;

    public enum Levels
    {
        MainMenu,
        Level1,
    }

    public IService Initialize()
    {
        return this;
    }

    public IService Begin()
    {
        return this;
    }

    public void ChangeLevel(LevelManager.Levels level, LoadSceneMode mode = LoadSceneMode.Additive)
    {
        SceneManager.LoadScene((int)level, mode);
    }
}
