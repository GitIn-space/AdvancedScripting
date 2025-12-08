using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MenuManager : MonoBehaviour, IService
{
    [SerializeField] private AssetReference mainMenu;

    private GameObject mainMenuObject;

    public IService Initialize()
    {
        LoadAssets();

        mainMenuObject.SetActive(true);

        return this;
    }

    public IService Begin()
    {
        return this;
    }

    private IEnumerator LoadAssets()
    {
        UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> temp = Addressables.InstantiateAsync(mainMenu);

        yield return new WaitUntil(() => mainMenu.IsDone);

        mainMenuObject = temp.Result;
    }
}
