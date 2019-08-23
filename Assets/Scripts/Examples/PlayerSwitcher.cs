using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

//Just a small dirty script to disable the controls on the unused player
public class PlayerSwitcher : MonoBehaviour
{
    public ThirdPersonUserControl[] Players;

    private int _currentPlayerIndex;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            NextPlayer();
        }
    }

    private void NextPlayer()
    {
        _currentPlayerIndex = (_currentPlayerIndex+1) % Players.Length;

        foreach(var player in Players)
        {
            player.enabled = false;
        }
        Players[_currentPlayerIndex].enabled = true;
    }
}
