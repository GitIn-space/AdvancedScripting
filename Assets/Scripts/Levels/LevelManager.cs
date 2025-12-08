using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IService
{
    [SerializeField] Scene menuScene;

    public IService Initialize()
    {
        SceneManager.LoadScene(menuScene.name, LoadSceneMode.Additive);

        return this;
    }

    public IService Begin()
    {
        return this;
    }
}
