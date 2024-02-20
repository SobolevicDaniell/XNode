using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XNode;
using TMPro;

namespace Game.View
{
    public class ChoiseButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _self;
        [SerializeField] private Say _say;
        
        public Node Node { get; private set; }
        public Say Say { set => _say = value; }

        public void Show(ChoiseElement choiseElement)
        {
            _text.SetText(choiseElement.Text);
            Node = choiseElement.Node;
            _self.onClick.AddListener((() => _say.Choise(this)));
        }

        public void Hide() => Destroy(gameObject);
    }
}

