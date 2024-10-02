using UnityEngine;
public class TestPositionReset : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to reset the position
        {
            player.position = spawnPoint.position;
            Debug.Log("Player position set to: " + player.position);
        }
    }
}
