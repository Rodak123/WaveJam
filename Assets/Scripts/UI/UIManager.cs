using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player player;

    [SerializeField] private GameObjectHider useIconHider;

    void Update()
    {
        useIconHider.SetActive(player.CanUse());
    }
}
