using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class BorderCreator : MonoBehaviour
{
    public BorderSO border;
    public TMP_Text latitudeText;
    public TMP_Text longitudeText;
    public LineRenderer lineRenderer;

    int count = 0;

    private IEnumerator Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        //lineRenderer.positionCount = border.longitudeList

        lineRenderer.startWidth = 1;
        lineRenderer.endWidth = 1;

        yield return null;
    }

    public void DrawBorder()
    {
        foreach (string i in border.latitudeList)
        {
            latitudeText.text += i + " ";
        }

        foreach (string i in border.longitudeList)
        {
            longitudeText.text += i + " ";
        }

        foreach (string i in border.latitudeList)
        {
            float.TryParse(border.latitudeList.ElementAt(count), out float latVal);
            float.TryParse(border.longitudeList.ElementAt(count), out float lonVal);

            lineRenderer.SetPosition(count, new Vector3(lonVal, latVal));
            count++;
        }

        float.TryParse(border.longitudeList.ElementAt(0), out float lonValue);
        float.TryParse(border.longitudeList.ElementAt(0), out float latValue);

        lineRenderer.SetPosition(count, new Vector3(lonValue, latValue));
    }
}
