using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagePopup : MonoBehaviour
{
    public float growTime = 0.5f;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        Vector2 size = rect.sizeDelta;
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 0.0f);

        rect.LeanSize(size, growTime).setOnComplete(activateSubtitles);
    }

    public void activateSubtitles()
    {
        StartCoroutine(activateText());
    }

    public IEnumerator activateText()
    {
        yield return new WaitForSeconds(0.3f);

        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(activateChildText());
    }

    public IEnumerator activateChildText()
    {
        yield return new WaitForSeconds(1.0f);

        transform.GetChild(1).gameObject.SetActive(true);
    }
}
