using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] Transform _shopKeeperPanel;
    private Items _selectedItem;
    private int _costOfItem;
    private int _playerGems;
    private Player _player;
    private bool win =false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.TryGetComponent<Player>(out _player)){
            if(_player != null) {
                UIManager.Instance.UpdatePlayerGems(_player);
                _playerGems = _player.GetGemValue();
                _shopKeeperPanel.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out _player)) {
            if (_player != null) {
                UIManager.Instance.UpdatePlayerGems(_player);
                if (win) {
                    _player.win = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<Player>(out Player player)) {
            if (player != null) {
                UIManager.Instance.UpdatePlayerGems(player);
                _shopKeeperPanel.gameObject.SetActive(false);
            }
        }
    }

    public void SelectItem(int item) {
        switch(item) {
            case 0:
                UIManager.Instance._selection.transform.localPosition = new Vector3 (-152.4464f, 108, 0);
                _costOfItem = 200;
                _selectedItem = Items.FireSword;

                break;
            case 1:
                UIManager.Instance._selection.transform.localPosition = new Vector3(-152.4464f, 4, 0);
                _costOfItem = 400;
                _selectedItem = Items.Boots;
                break;
            case 2:
                UIManager.Instance._selection.transform.localPosition = new Vector3(-152.4464f, -93.51479f, 0);
                _costOfItem = 100;
                _selectedItem = Items.Key;
                break;
                default:
                UIManager.Instance._selection.transform.localPosition = new Vector3(-152.4464f, 4, 0);
                _costOfItem = 400;
                _selectedItem = Items.Boots;
                break;
        }
    }

    public void BuyItem() {
        if (_playerGems >= _costOfItem) {
            if(_selectedItem == Items.Key) {
                win = true;
            }
            UnityEngine.Debug.Log($"Item Purchased: {_selectedItem.ToString()}");
            _playerGems -= _costOfItem;
            GameObject.Find("Player").GetComponent<Player>().SetGemValue(_playerGems);

        }
        else
            UnityEngine.Debug.Log("NOT ENOUGH GEMS");
    }

    public enum Items { FireSword, Boots, Key };

}
