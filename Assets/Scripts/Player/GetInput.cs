using UnityEngine;

public class GetInput : MonoBehaviour
{
    public static bool PressedSpace => Input.GetKeyDown(KeyCode.Space);
    public static bool PressedShift => Input.GetKeyDown(KeyCode.LeftShift);
    public static float GetHorizontalAxis => Input.GetAxis(Axis.Horizontal);
    public static float GetVerticalAxis => Input.GetAxis(Axis.Vertical);
}