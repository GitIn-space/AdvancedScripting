using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MenuManager : MonoBehaviour, IService
{
    [SerializeField] private List<AssetReference> menus = new List<AssetReference>();

    public IService Initialize()
    {


        return this;
    }

    public IService Begin()
    {
        return this;
    }
}
