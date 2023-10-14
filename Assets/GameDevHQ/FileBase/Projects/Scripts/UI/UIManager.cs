using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager _instance;
    [SerializeField] private TMP_Text _playerGemText;
    [SerializeField] public Image _selection;
    [SerializeField] private TMP_Text _gemCount;
    [SerializeField] private Image[] _healthUnits;
    [SerializeField] private GameObject _gameOverScene;
    public static UIManager Instance {

        get {
            if (_instance == null) {
                Debug.Log("ERROR UI");
            }

              return _instance;
        }

    }

    private void Awake() {
        _instance = this;
        _gameOverScene.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameOver() {
        _gameOverScene.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ReloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void UpdatePlayerGems(Player player) {
      _playerGemText.text = "" + player.GetGemValue().ToString()+"G";
      _gemCount.text = "" + player.GetGemValue().ToString();
    }

    public void UpdatePlayerHealth(Player player) {
        switch (player.Health) {
            case 1:
                if (_healthUnits[0].enabled == true) {
                    _healthUnits[0].enabled = false;
                }
                else if (_healthUnits[0].enabled == false)
                    _healthUnits[0].enabled = true;
                break;
            case 2:
                if (_healthUnits[1].enabled == true) {
                    _healthUnits[1].enabled = false;
                }
                else if (_healthUnits[1].enabled == false)
                    _healthUnits[1].enabled = true;
                break;
            case 3:
                if (_healthUnits[2].enabled == true) {
                    _healthUnits[2].enabled = false;
                }
                else if (_healthUnits[2].enabled == false)
                    _healthUnits[2].enabled = true;
                break;
            case 4:
                if (_healthUnits[3].enabled == true) {
                    _healthUnits[3].enabled = false;
                }
                else if (_healthUnits[3].enabled == false)
                    _healthUnits[3].enabled = true;
                break;  
        };
       
    }
}
