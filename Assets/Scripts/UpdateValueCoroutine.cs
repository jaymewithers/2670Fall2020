using System.Collections;
using UnityEngine;

public class UpdateValueCoroutine : MonoBehaviour
{
    public FloatData value;
    public float valueChange = 0.1f;
    private WaitForFixedUpdate wffu;
    public WaitForSeconds wfs;
    public float delay = 1f;

    private void Start()
    {
        wfs = new WaitForSeconds(delay);
    }

    private IEnumerator valueDrain()
    {
        yield return wffu;
        yield return wfs;
        value.value -= valueChange;
    }

    private IEnumerator valueRefill()
    {
        yield return wffu;
        yield return wfs;
        value.value += valueChange;
    }
}