using UnityEngine;

//enum to get what axis we want to work with
public enum AxisType
{
    X,
    Y,
    Z
}

//Dan Florescu
//Mp1
//10/3/17
public class MovementController : MonoBehaviour
{
    [SerializeField]
    private AxisType _axis;
    [SerializeField]
    private float _linearSpeed = 1.0f;
    [SerializeField]
    private float _angularSpeed = 0.0f;
    [SerializeField]
    private float _maxDistance = 5.0f;
    [SerializeField]
    private float _positionalOffset = 0.0f;
    [SerializeField]
    private float _direction = 1;
    [SerializeField]
    private Vector3 _originalPosition;
    [SerializeField]
    private Vector3 _originalRotation;
    [SerializeField]
    private int _returnColorR;
    [SerializeField]
    private int _returnColorG;
    [SerializeField]
    private int _returnColorB;

    // Use this for initialization
    void Start()
    {
        this._originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this._positionalOffset += this._direction * this._linearSpeed * Time.deltaTime;

        if (this._positionalOffset > this._maxDistance)
        {
            this._positionalOffset = this._maxDistance;
            this._direction *= -1;
        }

        if (this._positionalOffset < 0)
        {
            this._positionalOffset = 0;
            this._direction *= -1;
        }

        //set the defualt color to white going positive, in the negative direction have a custom rgb color
        if (this._direction > 0)
        {
            this.transform.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
        else
        {
            this.transform.GetComponent<Renderer>().material.color = new Color(this._returnColorR, this._returnColorG, this._returnColorB);
        }

        //switch between the axises on how the object will move depending on the object selected from the drop down menu
        switch(this._axis)
        {
            case AxisType.X:
                this.transform.position = new Vector3(this._originalPosition.x + this._positionalOffset, this._originalPosition.y, this._originalPosition.z);
                break;
            case AxisType.Y:
                this.transform.position = new Vector3(this._originalPosition.x, this._originalPosition.y + this._positionalOffset, this._originalPosition.z);
                break;
            case AxisType.Z:
                this.transform.position = new Vector3(this._originalPosition.x, this._originalPosition.y, this._originalPosition.z + this._positionalOffset);
                break;
        }
        //rotate object in the y axis
        this.transform.Rotate(new Vector3(0, this._angularSpeed * Time.deltaTime, 0));
    }
}