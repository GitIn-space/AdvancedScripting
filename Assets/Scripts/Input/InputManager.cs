using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IService
{
    [HideInInspector] public UnityEvent<Vector2> doMovement = new UnityEvent<Vector2>();

    public IService Initialize()
    {
        return this;
    }

    public IService Begin()
    {
        return this;
    }

    private void OnMove(InputValue input)
    {
        doMovement.Invoke(input.Get<Vector2>());
    }
}
