using UnityEngine.InputSystem;

public interface IControllable
{
    public enum ControlType
    {
        Move,
    }

    public void Callback(ControlType type, InputValue input);
}
