using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Esta variable controla el �ngulo total de la visi�n 
    /// </summary>
    [SerializeField] float fov;
    /// <summary>
    /// Controla el �ngulo desde el cual se crea el rayo (se genera en sentido horario
    /// </summary>
    [SerializeField] float angle;
    /// <summary>
    /// Punto de origen del mesh
    /// </summary>
    private Vector3 origin;
    private Vector3 raySource;
    /// <summary>
    /// Rango m�ximo al que puede ver el enemigo
    /// </summary>
    [SerializeField] float viewDistance;

    //Aunque en algunos pone serializeField, los valores van a ser dependientes de los enemigos.
    //Para ello, simplemente habr�a que quitar el serialize field y acceder a estos valores desde el script
    //del enemigo usando los m�todos Set de m�s abajo.

    /// <summary>
    /// Cuantos rayos se usan para crear la textura. Cu�ntos m�s halla, m�s refinada es la textura pero m�s tarda 
    /// en renderizar. Recomiendo entre 50 y 100, dependiendo de la cantidad de enemigos que vayan a tener
    /// que hacer los raycast en ese momento.
    /// </summary>
    [SerializeField] int rayCount;
    /// <summary>
    /// Variable para calcular la variaci�n del �ngulo. Declarada en el Start. Usada en el bucle para colocar v�rtices.
    /// </summary>
    private float angleIncrease;
    #endregion

    #region references 
    /// <summary>
    /// Referencia al propio mapa mesh.
    /// </summary>
    private Mesh _myMesh;
    /// <summary>
    /// Referencia a la Mask que activa colisiones (p. ej., colisiona con las paredes pero no con el jugador
    /// u otros enemigos)
    /// </summary>
    [SerializeField] LayerMask _myLayerMask;
    #endregion

    #region methods
    /// <summary>
    /// M�todo matem�tico para sacar un vector normalizado desde un �ngulo en grados
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    private Vector3 GetVectorFromAngle(float angle)
    {
        float angRadians = (angle * Mathf.PI) / 180;
        return new Vector3(Mathf.Cos(angRadians), Mathf.Sin(angRadians)).normalized;
    }

    /// <summary>
    /// M�todo matem�tico para sacar un �ngulo en grados desde un vector cualquiera
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private float GetAngleFromVector(Vector3 vector)
    {
        vector = vector.normalized;
        float k = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        k = k + 90;
        if (k < 0)
        {
            k += 360;
        }

        return k;
    }

    //Los siguientes m�todos son p�blicos porque son los Set. SetOrigin y SetAim se deber�n llamar en el update
    //de cada enemigo, mientras que SetFov y SetDistance solo durante el Start.

    /// <summary>
    /// Establece el v�rtice de origen del �ngulo
    /// </summary>
    /// <param name="origin"></param>
    public void SetOrigin(Vector3 origin)
    {
        this.raySource = origin;
    }

    /// <summary>
    /// Toma una direcci�n a la que apuntar y establece el �ngulo de origen necesario para que esta est� en la mitad del FOV
    /// </summary>
    /// <param name="aimDirection"></param>
    public void SetAim(Vector3 aimDirection)
    {
        angle = GetAngleFromVector(aimDirection) - fov / 2;
    }

    /// <summary>
    /// Establece el tama�o del �ngulo que ocupar� el FOV
    /// </summary>
    /// <param name="fov"></param>
    public void SetFov(float fov)
    {
        this.fov = fov;
    }

    /// <summary>
    /// Establece la distancia m�xima a la que puede ver un enemigo
    /// </summary>
    /// <param name="viewDistance"></param>
    public void SetDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myMesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = _myMesh;
        origin = Vector3.zero;
    }

    // Update is called once per frame
    // He desplazado esto a LateUpdate ya que nos queremos asegurar de que lo renderiza despu�s de haber recibido 
    // los datos necesarios de la posici�n y direcci�n del enemigo.
    void LateUpdate()
    {
        //Establece los valores de origin a zero (borrar una vez implementado SetOrigin) y calcula cu�nto
        //tendr� que variar su �ngulo tras cada iteraci�n.
        angleIncrease = fov / rayCount;
        //origin = Vector3.zero;

        //Establece arrays para los v�rtices, los uv (renderizado de texturas) y los tri�ngulos.
        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[rayCount + 2];
        int[] triangles = new int[rayCount * 3];

        //Esto siempre va a ser as� puesto que el v�rtice 0 siempre es el origen
        vertices[0] = origin;
        uv[0] = origin.normalized;

        //Variables auxiliares que se usan en el bucle.
        int vertexIndex = 1, triangleIndex = 0;

        //Si el bucle es muy complicado de entender (no creo), voy a dejar una explicaci�n detallada
        //en el mismo README en el que explico como poner el script en escena en Unity
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycast = Physics2D.Raycast(raySource, GetVectorFromAngle(angle), viewDistance, _myLayerMask);

            if (raycast.collider == null)
            {
                vertex = GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = GetVectorFromAngle(angle) * raycast.distance;
            }

            vertices[vertexIndex] = vertex;
            uv[vertexIndex] = vertex.normalized;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        //Recupera el �ngulo incicial. Esto lo hice para que no me diese vueltas a la pantalla, pero para cuando
        //el �ngulo sea estipulado por el SetAim en cada update, se podr� borrar
        angle += fov + angleIncrease;

        //Se asignan los arrays al mesh
        _myMesh.vertices = vertices;
        _myMesh.uv = uv;
        _myMesh.triangles = triangles;
    }
}
