using UnityEngine;


namespace SecondAttempt
{
    public abstract class BaseObjectInScene : MonoBehaviour
    {
        #region FIELDS

        private GameObject _objectInScene;
        private int _layer;
        private Ray _ray;
        private Color _color;
        private bool _isVisible;
        private GameObject _previusObject;

        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public Transform Transform;

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

        public int Layer
        {
            get => _layer;
            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }

        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                AskColor(transform, _color);
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                RendererSetActive(transform);
                if (transform.childCount <= 0) return; //В середине кода?
                foreach (Transform t in transform)
                    RendererSetActive(t);
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
            obj.gameObject.layer = layer;
            if (obj.childCount <= 0) return;

            foreach (Transform child in obj)
            {
                AskLayer(child, layer);
            }
        }

        private void AskColor(Transform obj, Color color)
        {
            foreach (var curMaterial in obj.GetComponent<Renderer>().materials)
            {
                curMaterial.color = color;
            }
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
                AskColor(d, color);
        }

        public void DisableRigidbody()  //  А как же SOLID  ???
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
                rb.isKinematic = true;
        }

        public void EnableRigidbody(float force)
        {
            EnableRigidbody();
            Rigidbody.AddForce(transform.forward * force);
        }

        public void EnableRigidbody()
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
                rb.isKinematic = false;
        }

        private void RendererSetActive(Transform renderer)
        {
            if (renderer.gameObject.TryGetComponent<Renderer>(out var component))
            {
                component.enabled = _isVisible;
            }
        }

        public void SetActive(bool value)
        {
            IsVisible = value;
            if (TryGetComponent<Collider>(out var component))
                component.enabled = value;
        }

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

        public void RigidbodyConstraints(RigidbodyConstraints rigidbodyConstraints)
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
                rb.constraints = rigidbodyConstraints;
        }

        #endregion
    }
}