#pragma strict

var Aberto: boolean;
public var posicao : float;

function Start () 
{

}

function Update () 
{							
	if (!Aberto && Input.GetKey (KeyCode.B))
	{
		transform.Rotate(0, 0, -90f);
		Aberto = true;
	}		
	else if(Aberto && EntrouNoBalao() && Input.GetKey(KeyCode.F))
	{
		transform.Rotate(0, 0, 90f);
		Aberto = false;
	}
	//if (pontoatual = this

}

function EntrouNoBalao()
{
//	if(Tempo<=2)
//	{
		return true;
//	}
//	else
//	{
//		return false;
//	}
}