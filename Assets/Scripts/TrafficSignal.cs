using System.Collections;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    public enum SignalState
    {
        Red,
        Yellow,
        Green
    }
    public SignalState signalState;

    [SerializeField] private GameObject stopTraffic;

    [SerializeField] private Signal red;
    [SerializeField] private Signal yellow;
    [SerializeField] private Signal green;

    private void Start()
    {
        red.Activate();
        signalState = SignalState.Red;
        stopTraffic.SetActive(false);
        StartCoroutine(ChangeSignal());
    }

    private IEnumerator ChangeSignal()
    {
        while (true)
        {
            yield return new WaitForSeconds(red.duration);
            red.Deactivate();
            green.Activate();
            signalState = SignalState.Green;
            stopTraffic.SetActive(true);
            yield return new WaitForSeconds(green.duration);
            green.Deactivate();
            yellow.Activate();
            signalState = SignalState.Yellow;
            stopTraffic.SetActive(true);
            yield return new WaitForSeconds(yellow.duration);
            yellow.Deactivate();
            red.Activate();
            signalState = SignalState.Red;
            stopTraffic.SetActive(false);
        }
    }

    [System.Serializable]
    protected class Signal
    {
        public GameObject signalObject;
        public float duration;

        public void Activate()
        {
            signalObject.SetActive(true);
        }

        public void Deactivate()
        {
            signalObject.SetActive(false);
        }
    }
}


