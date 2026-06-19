using UnityEngine;

public class DSPClock : MonoBehaviour
{
    private double prevDSPTime = double.NaN;
    private double currDSPTime;
    private double deltaDSPTime = 0;
    private double currAudioDSPTime = 0;
    private double endAudioDSPTime = 0;

    // Update is called once per frame
    private void Update()
    {
        ClockTick();
    }
    public void SetAudioDSP(double d)
    {
        currAudioDSPTime = d;
    }
    public void SetAudioEndTime(double d)
    {
        endAudioDSPTime = d;
    }
    public double GetAudioDSP()
    {
        return currAudioDSPTime;
    }

    public double GetAudioEndDSP()
    {
        return endAudioDSPTime;
    }

    private void ClockTick()
    {
        currDSPTime = AudioSettings.dspTime;

        if (prevDSPTime != double.NaN)
        {
            deltaDSPTime = currDSPTime - prevDSPTime;
            currAudioDSPTime += deltaDSPTime;
        }

        prevDSPTime = currDSPTime;
    }
}
