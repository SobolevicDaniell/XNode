using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XNode;

namespace Game.View
{
    public class Say : MonoBehaviour
    {
        [SerializeField] private Dialogs _dialogs;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Choise _choise;

        private Node _dialog;
        public void Start()
        {
            if (_dialogs != null) NextDialog();
        }

        public void NextDialog()
        {
            if (_dialogs == null) return;

            _dialog ??= _dialogs.nodes[0];

            switch (_dialog)
            {
                case Dialog dialog:
                    _name.SetText(dialog.Name);
                    _text.SetText(dialog.Text);
                    break;
            }
            
            
            Dialog dialogtmp = _dialog as Dialog;
            
            
            if (dialogtmp._choise.Length == 0)
            {
                NodePort port = _dialog.GetPort("_output").Connection;
                if (port != null) _dialog = port.node;
            }
            else
            {
                ChoiseCreate(dialogtmp);
            }
                
            
        }
        

        private void ChoiseCreate(Dialog dialog)
        {
            
            _choise.Show();
            for (int i = 0; i < dialog._choise.Length; i++)
            {
                ChoiseElement tmp = new ChoiseElement();
                tmp.Text = dialog._choise[i];
                tmp.Node = dialog.GetPort($"_choise{i}").Connection.node;
                _choise.Add(tmp, this);
            }
                
            
            
        }

        public void Choise(ChoiseButton choiseButton)
        {
            _dialog = choiseButton.Node;
            choiseButton.Hide();
            _choise.Hide();
        }
    }
}

