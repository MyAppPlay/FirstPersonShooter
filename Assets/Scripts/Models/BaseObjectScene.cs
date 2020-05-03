using UnityEngine;


namespace SecondAttempt
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        #region FIELDS

        private GameObject _objectInScene;
        private int _layer;
        private Ray _ray;
        private GameObject _previusObject;

        #endregion


        #region PROPERTIES

        public GameObject ObjectInScene
        {
            get
            {
                return _objectInScene;
            }
            set
            {
                _objectInScene = value;
            }
        }

        public Rigidbody Rigidbody { get; private set; }

        public Transform Transform { get; private set; }

        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }

        #endregion


        #region UNITY_METODS

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();
        }

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ViewNameObject();
        }

        #endregion


        #region METODS

        private void AskLayer(Transform obj, int layer)
        {
            gameObject.layer = layer;
            if (obj.childCount <= 0) return;

            foreach (Transform child in obj)
            {
                AskLayer(child, layer);
            }
        }

        #endregion


        #region METODS

        private void ViewNameObject()
        {
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit, 1000.0f))
            {
                GameObject rayCastedGO = hit.collider.gameObject;
                _previusObject = ObjectInScene;
                ObjectInScene = rayCastedGO;
                AddLightComponent();
                print(ObjectInScene.name);
                if (ObjectInScene.GetComponentInChildren<Light>() != null)
                    ObjectInScene.GetComponentInChildren<Light>().color = Color.red;
            }
            if (_previusObject != ObjectInScene)
                if (_previusObject != null && _previusObject.GetComponentInChildren<Light>() != null)
                    _previusObject.GetComponentInChildren<Light>().color = default;

        }

        private void AddLightComponent()
        {
            if (ObjectInScene != null && ObjectInScene.GetComponent<Light>() == null)
            {
                ObjectInScene.AddComponent<Light>().type = LightType.Point;
                ObjectInScene.GetComponent<Light>().intensity = 5;
            }
        }

        #endregion
    }
}