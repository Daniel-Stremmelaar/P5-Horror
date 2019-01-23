using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    [Tooltip("These need to be in the correct order")]
    public List<Room> rooms;
    public int currentRoom;

    public void Start()
    {
        rooms[0].enabled = true;
    }

    public void RemoveFromList()
    {
        //rooms.Remove(rooms[currentRoom]);
        currentRoom++;
        rooms[currentRoom].enabled = true;
    }
}
