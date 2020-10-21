using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderButton : MonoBehaviour
{
    [SerializeField] int PlayerNumber = default;
    [SerializeField] GameObject TurnOrderPrefab = default;

    private TurnOrderContainer _turnOrderContainer;

    // Start is called before the first frame update
    void Start()
    {
        _turnOrderContainer = TurnOrderPrefab.GetComponent<TurnOrderContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToPlayerTurn()
    {
        _turnOrderContainer.GoToTurn(PlayerNumber);
    }
}
