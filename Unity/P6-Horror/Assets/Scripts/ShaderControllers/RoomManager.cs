using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    [Tooltip("These need to be in the correct order")]
    public List<Room> rooms;

    public void Start()
    {
        rooms[0].enabled = true;
    }

    public void RemoveFromList()
    {
        rooms.Remove(rooms[0]);
        for (int i = 1; i < rooms.Capacity; i++)
        {
            rooms[i--] = rooms[i];
        }
        rooms[0].enabled = true;
    }
}
