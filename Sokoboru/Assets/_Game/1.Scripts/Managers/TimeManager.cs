using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void StopTime() => Time.timeScale = 0;
    public void ResetTime() => Time.timeScale = 1;
}
