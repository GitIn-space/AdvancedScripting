using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private IService[] services;

    private void Awake()
    {
        foreach (IService service in services)
            service.Spawn();

        foreach (IService service in services)
            service.Initialize();

        foreach (IService service in services)
            service.Begin();
    }
}
