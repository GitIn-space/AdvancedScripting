using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IService
{
    [SerializeField] private AssetReference mainMenu;

    private GameObject mainMenuObject;
    private LevelManager levelManager;

    public IService Initialize()
    {
        StartCoroutine(LoadAssets());

        return this;
    }

    public IService Begin()
    {
        levelManager = FindFirstObjectByType<LevelManager>();

        return this;
    }

    private IEnumerator LoadAssets()
    {
        UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> temp = Addressables.InstantiateAsync(mainMenu);

        temp.WaitForCompletion();

        yield return new WaitUntil(() => mainMenu.IsDone); //this seemingly doesn't work? need the line above or it nulls out

        mainMenuObject = temp.Result;

        foreach (Button button in mainMenuObject.GetComponent<ButtonRef>().Buttons)
            switch (button.name)
            {
                case "Play":
                    button.onClick.AddListener(Play);
                    break;
                case "Quit":
                    button.onClick.AddListener(Quit);
                    break;
            }

        mainMenuObject.SetActive(true);
    }

    private void Play()
    {
        levelManager.ChangeLevel(LevelManager.Levels.Level1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
