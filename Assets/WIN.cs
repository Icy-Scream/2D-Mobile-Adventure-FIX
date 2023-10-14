using UnityEngine;


public class WIN : MonoBehaviour
{
    [SerializeField] GameObject winner_Text;
    [SerializeField] GameObject key_Text;
    [SerializeField] GameObject restartButton;
    Player _player;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out _player)) {
            if (_player != null) {
                if (_player.win) {
                    Debug.Log("YOU WIN");
                    winner_Text.SetActive(true);
                    restartButton.SetActive(true);
                }
                else {
                    Debug.Log("LOSER");
                    key_Text.SetActive(true);
                }
                  
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        key_Text?.SetActive(false); 
    }

}
