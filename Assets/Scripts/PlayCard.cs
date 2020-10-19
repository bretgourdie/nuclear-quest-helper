using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    [SerializeField] public bool PlaysImmediately = default;
    [SerializeField] public bool DrawRadiationAfterUse = default;
    [SerializeField] public bool SkipNextTurn = default;
    [SerializeField] public bool LoseAllGammaRadiation = default;
    [SerializeField] public string InstructionsOnGain = default;
    [SerializeField] public string InstructionsOnPlay = default;
    [SerializeField] public bool WasPlayedFromHand = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
