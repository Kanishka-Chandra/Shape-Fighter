using TMPro;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{
   public void SetPlayerName(string name)
   {
       PlayerPrefs.SetString("PlayerName", name);
   }
}
