using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private Text _buttonText;

    // Start is called before the first frame update
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        if (button != null)
        {
            _buttonText = button.GetComponentInChildren<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Roll()
    {
        StartCoroutine(PerformRoll());
    }

    IEnumerator PerformRoll()
    {
        _buttonText.text = "?";
        yield return new WaitForSeconds(0.25f);
        var rolled = Random.Range(1, 6 + 1);
        _buttonText.text = rolled.ToString();
    }
}
