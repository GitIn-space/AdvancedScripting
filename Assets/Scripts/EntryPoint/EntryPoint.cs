using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EntryPoint : MonoBehaviour
{
    public enum InitObject
    {
        EntryPoint,
    }

    [RuntimeInitializeOnLoadMethod]
    private static void BootSequence()
    {
        if (!FindFirstObjectByType<EntryPoint>())
            Addressables.InstantiateAsync("EntryPoint");
    }

    private IEnumerator Start()
    {
        List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject>> loadHandles = new List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject>>();
        loadHandles.Add(Addressables.InstantiateAsync("GameManager"));
        loadHandles.Add(Addressables.InstantiateAsync("InputManager"));
        loadHandles.Add(Addressables.InstantiateAsync("SoundManager"));
        loadHandles.Add(Addressables.InstantiateAsync("AssetManager"));
        yield return new WaitUntil(() => IsLoadingDone(loadHandles));

        foreach (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> item in loadHandles)
            item.Result.GetComponent<IService>().Initialize();

        foreach (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> item in loadHandles)
            item.Result.GetComponent<IService>().Begin();
    }

    private bool IsLoadingDone(List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject>> list)
    {
        foreach(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> item in list)
            if(!item.IsDone)
                return false;

        return true;
    }
}
