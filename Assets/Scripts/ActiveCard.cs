using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour
{
    private Card _card;
    public Card Card
    {
        get => _card;
        set
        {
            _card = value;

            if (_card != null)
            {
                _card.transform.position = transform.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
