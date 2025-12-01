using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour, IService
{
    private List<IControllable> controllables = new List<IControllable>();
    private bool running = false;

    public IService Initialize()
    {
#if UNITY_STANDALONE
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Standalone");
#elif UNITY_PS4 || UNITY_PS3 || UNITY_XBOX360 || UNITY_XBOXONE
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Console");
#endif

        return this;
    }

    public IService Begin()
    {
        return this;
    }

    public void Register(IControllable controllable)
    {
        controllables.Add(controllable);
    }

    private void Call(IControllable.ControlType type, InputValue input)
    {
        if (running)
            foreach (IControllable controllable in controllables)
                controllable.Callback(type, input);
    }

    private void OnMove(InputValue input)
    {
        Call(IControllable.ControlType.Move, input);
    }
}
