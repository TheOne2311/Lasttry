using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TempPlayer player = collision.GetComponent<TempPlayer>();
        if (player)
        {
            Debug.Log("Touched");
            player.CarrotNum++;
            Destroy(this.gameObject);
        }
    }

    public enum CollectableType
    {
        NONE, CARROT
    }
}
