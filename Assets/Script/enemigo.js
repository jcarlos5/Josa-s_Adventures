#pragma strict

// Aplicar a "enemigo" que contenga:
	// Rigidbody
	// Collider (de preferencia usar Capsule o Cube)
// En Rigidbody palomear los constrains de Freeze Rotation en X y en Z


var Player: Transform;  //Asignar el personaje al que seguirán
var MoveSpeed:float = 4; //Establecer velocidad de persecución
var MaxDist:float = 20; //Establecer distancia máxima a la que lo seguirá
var MinDist:float = 1;//Establecer distancia mínima a la que lo seguirá

var idle:AnimationClip; //Animación en estado de reposo
var run:AnimationClip; //Animación de correr o perseguir


function Start () {

}

function Update () {
    var EnemyPos = transform.position;
    var PlayerPos = Player.position;
    var distancia = Vector3.Distance(EnemyPos,PlayerPos);

    if(  distancia >= MinDist && distancia <= MaxDist  ){
       var targetPos = new Vector3( Player.position.x, 
                                       this.transform.position.y, 
                                       Player.position.z);
    		transform.LookAt(targetPos);
    		transform.position += transform.forward*MoveSpeed*Time.deltaTime;
       		animation.CrossFade(run.name,1); 
		for (var state : AnimationState in animation) {
			state.speed = 2;
		}
   } else {
   		animation.CrossFade(idle.name,1); 
   		for (var state : AnimationState in animation) {
			state.speed = 1;
		}
   }
}