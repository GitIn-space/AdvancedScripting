using UnityEngine;

public interface IService
{
    IService Spawn();

    IService Initialize();

    IService Begin();
}
