using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class carro : MonoBehaviour {
	public WheelCollider wheelFL;
	public WheelCollider wheelRL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRR;
	public Transform wheelFLTrans;
	public Transform wheelRLTrans;
	public Transform wheelFRTrans;
	public Transform wheelRRTrans;
	public float maxTorque = 50;
	
	SerialPort spPotenciometro = new SerialPort ("COM4", 9600);
	SerialPort spPedal = new SerialPort("COM3",9600);
	Rigidbody carroRB;
	// Use this for initialization
	void Start () {
		spPotenciometro.Open(); //Opens up serial communication
		spPotenciometro.ReadTimeout = 105; //Sets a timeout when connection isn't receiving
		spPedal.Open();
		spPedal.ReadTimeout = 105;
		
		carroRB = GetComponent<Rigidbody>();
		carroRB.centerOfMass= new Vector3(0,-1f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (spPotenciometro.IsOpen && spPedal.IsOpen) { //checks if connection to the Arduino is open
			
			try {
				
				checkByte (spPotenciometro.ReadLine (),spPedal.ReadLine()); //Reads incoming bytes from the Arduino serial Port
				//speed = rigidbody.velocity.magnitude; //Sets the car's speed to the speed variable
				
			} 
			catch (System.Exception) { //If for some reason it can't get a
				
			}
			
		}
		/*
		wheelRR.motorTorque = maxTorque * Input.GetAxis ("Vertical");
		wheelRL.motorTorque = maxTorque * Input.GetAxis ("Vertical");
		wheelFL.steerAngle = 10 * Input.GetAxis ("Horizontal");
		wheelFR.steerAngle = 10 * Input.GetAxis ("Horizontal");
		*/
		//wheelFLTrans.transform.Rotate(wheelFL.rpm/60*360*Time.deltaTime,0,0);
	}
	void checkByte(string sensorPot, string sensorPedal)
	{
		int sensorPotInt = int.Parse(sensorPot);//potenciometro
		float sensorPedalFloat = float.Parse(sensorPedal);
		
		float velocidade = (float)(sensorPedalFloat / (float) 400);
		Debug.Log("Velocidade normalizado: "+velocidade.ToString()+" / pedal: "+sensorPedalFloat.ToString());
		
		//Debug.Log("Teste torque "+wheelRR.motorTorque.ToString()+ " / "+wheelRL.motorTorque.ToString());
		
		if (velocidade == 0) {
			wheelRR.brakeTorque = (float)0.4;
			wheelRL.brakeTorque = (float)0.4;
		} else {
			wheelRR.brakeTorque = 0;
			wheelRL.brakeTorque = 0;
			wheelRR.motorTorque = maxTorque * velocidade;
			wheelRL.motorTorque = maxTorque * velocidade;
			
			float anguloNormalizado = (float)((float)sensorPotInt / (float)511.5) - 1.0f;
			Debug.Log("angulo normalizado: "+anguloNormalizado.ToString());
			wheelFL.steerAngle = 10 * anguloNormalizado;
			wheelFR.steerAngle = 10 * anguloNormalizado;
		}
		//Debug.Log("BRAKou??? "+wheelRR.brakeTorque.ToString());
		
		//VOLANTE
		//float anguloNormalizado = (float)((float)sensorPotInt / (float)511.5) - 1.0f;
		//Debug.Log("angulo normalizado: "+anguloNormalizado.ToString());
		//Debug.Log("Angulo normalizado: "+anguloNormalizado.ToString());
		//wheelFL.steerAngle = 10 * anguloNormalizado;
		//wheelFR.steerAngle = 10 * anguloNormalizado;
	}
}
