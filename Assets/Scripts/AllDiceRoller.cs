using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDiceRoller : MonoBehaviour
{
    [SerializeField] List<GameObject> DiceToRoll = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollAllDice()
    {
        foreach (var dice in DiceToRoll)
        {
            dice.GetComponent<Dice>().Roll();
        }
    }
}
