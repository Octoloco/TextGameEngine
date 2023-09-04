using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TextWritter : MonoBehaviour
{
    static public TextWritter Instance;

    [Range(0f, 0.1f)]
    public float speed = 0;

    private TMP_Text textBox;
    private string textToWrite;
    private bool isWritting;
    private Queue<IEnumerator> writtingQueue = new Queue<IEnumerator>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        textBox = GetComponent<TMP_Text>();
    }

    void Start()
    {
        
    }

    public void WriteText(string text)
    {
        if (!isWritting)
        {
            isWritting = true;
            textToWrite = text;
            StartCoroutine(WriteLetter());
        }
        else
        {
            textToWrite += text;
        }
    }

    IEnumerator WriteLetter()
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            textBox.text += textToWrite[i];
            yield return new WaitForSeconds(speed);
        }
        isWritting = false;
    }
}
