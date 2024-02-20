using UnityEngine;
using XNode;

public class Dialog : Node
{
	[Input] public bool _input;
	[Output] public bool _output;
	
	[SerializeField] private string _name;
	[SerializeField][TextArea(5,10)] private string _text;


	[Output(dynamicPortList = true)] public string[] _choise;

	public string Name => _name;
	public string Text => _text;

	protected override void Init()
	{
		base.Init();
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}
}