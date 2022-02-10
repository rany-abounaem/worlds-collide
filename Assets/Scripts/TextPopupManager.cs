using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopupManager : MonoBehaviour
{
    public string text;
    TextMeshPro textmeshPro;
    Color textColor;
    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = text;
        textColor = textmeshPro.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        textColor.a -= 1 * Time.deltaTime;
        textmeshPro.color = textColor;
        if(textColor.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
