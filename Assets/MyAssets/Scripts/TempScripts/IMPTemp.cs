public class IMPTemp
{
    /*
        bullet movement code bulletcontroller code

        public void Movement()
        {
           extra // rigidbody.AddForce(bulletView.transform.forward * bulletModel.bulletForce, ForceMode.Impulse);

            Vector3 move = bulletView.transform.position;
            move += bulletView.transform.forward * bulletModel.bulletForce * Time.fixedDeltaTime;

            rigidbody.MovePosition(move);
        }


        destroying bullet view bulletservise code

        public void DestroyingBullet()
        {
            void OnTriggerEnter(Collider other)
            {

                BullectDestroyVFX.transform.parent = null;
                BullectDestroyVFX.Play();

                Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
                Destroy(gameObject);
            }
        }

        camera controller code 

        [SerializeField] private Transform target;
            private Vector3 offset;
            public void SetTarget(Transform target)
            {
                this.target = target;
            }
            void Start()
            {
                offset = transform.position - target.position;
            }

        void LateUpdate()
        {
            transform.position = target.position + offset;
        }







        //singleton code


            private static T instance;
            public static T Instance { get { return instance; } }
            protected virtual void Awake()
            {
                if (instance == null)
                {
                    instance = (T)this;
                }
                else
                {
                    Debug.LogError(Instance + "is Tring to create another instance");
                    Destroy(this);
                }
            }
        }



    generic monosingleton

    public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static object m_lock = new Object();

        public static T GetInstance()
        {
            lock (m_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        GameObject obj = new GameObject();

                        obj.name = typeof(T).ToString();

                        instance = obj.AddComponent<T>();

                        DontDestroyOnLoad(obj);
                    }
                }
            }

            return instance;
        }
    }

    }



    //enemy service tank 
        void SpwanWaiting()
        {
            SpawningEnemy();
            // yield return new WaitForSeconds(spwanTime);
            // if (count >= 3)
            // {
            //     // StopCoroutine(SpwanWaiting());
            // }
            // else
            // {
            //     // StartCoroutine(SpwanWaiting());
            // }
            // count++;
        }

        IEnumerator SpwanWaiting()
        {
            SpawningEnemy();
            yield return new WaitForSeconds(spwanTime);
            if (count >= 3)
            {
                StopCoroutine(SpwanWaiting());
            }
            else
            {
                StartCoroutine(SpwanWaiting());
            }
            count++;
        }

        public void DestroyEnemyTank(EnemyController enemyController)
        {
            enemyController.DestroyEnemyController();
            for (int i = 0; i < enemyTanksList.Count; i++)
            {
                if (enemyTanksList[i] != enemyController)
                {
                    Debug.Log("1 ch vela bhau     " + enemyController);
                    // enemyTanksList[i] = null;
                    // enemyTanksList.Remove(enemyController);

                    enemyTanksList[i].enemyView.gameObject.SetActive(false);
                }
            }
        }


                public void DestroyEnemyTank(EnemyController enemyController)
        {

            enemyController.DestroyEnemyController();
            // for (int i = 0; i < enemyTanksList.Count; i++)
            // {

            //     if (enemyTanksList[i] == enemyController)
            //     {

            //         // enemyTanksList[i].enemyView.gameObject.SetActive(false);
            //         // enemyController.enemyModel = null;
            //         // Debug.Log(tank);
            //         enemyTanksList[i] = null;
            //         enemyTanksList.Remove(enemyController);
            //     }
            // }
        }




        

public List<Transform> enemyPos;
public EnemyTankScriptableObject enemyTankScriptableObject;
// void GetEnemyList(EnemyTankScriptableObject enemySO)
// {
//     enemyPos = enemySO.enemyPos;
// }

void Start()
{
    creatNewEnemy();
}

private EnemyControlller creatNewEnemy()
{
    // int enemyNum = Random.Range(0, enemyPos.Count);
    EnemyView enemyView = enemyTankScriptableObject.enemyView;
    EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
    EnemyControlller enemy = new EnemyControlller(enemyModel, enemyView);//, enemyPos[enemyNum]);
    return enemy;
}



//tank view



//     private float rotation;
//     private float movement;
//     // private Rigidbody rigidbody;

//     private TankController tankController;
//     void Start()
//     {

//         // rigidbody = gameObject.GetComponent<Rigidbody>();
//     }

//     public void SetTankController(TankController _tankController)
//     {
//         tankController = _tankController;
//     }

//     private void Update()
//     {
//         Movement();
//     }

//     private void Movement()
//     {
//         // rotation = Input.GetAxis("Horizontal");
//         // movement = Input.GetAxis("Vertical");


//     }

//     private void FixedUpdate()
//     {
//         if (movement != 0)
//         {
//             Debug.Log("move");
//             Move(20, 20);
//         }
//         if (rotation != 0)
//         {
//             Debug.Log("rotate");
//             Rotate(20, 20);
//         }
//     }



//     public void Move(float movement, float movementSpeed)
//     {
//         Vector3 move = transform.position;
//         move += transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
//         // move += transform.forward * 20 * Time.fixedDeltaTime;

//         // rigidbody.MovePosition(move);
//     }

//     public void Rotate(float rotation, float rotateSpeed)
//     {
//         Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//         Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//         // rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
//     }






// private TankController tankController;
// public TankType TankType { get; private set; }
// public float movementSpeed { get; private set; }
// public float roatationSpeed { get; private set; }
// public float Health { get; private set; }


//Tankmode temp:

// public TankModel(TankScriptableObjects tankScriptableObjects)
// {
//     TankType = tankScriptableObjects.tankType;
//     movementSpeed = tankScriptableObjects.movementSpeed;
//     roatationSpeed = tankScriptableObjects.rotationSpeed;
//     Health = tankScriptableObjects.health;

// }

// public void SetTankController(TankController _tankController)
// {
//     tankController = _tankController;
// }

// public TankModel(float movSpeed, float rotSpeed, float health)
// {
//     movementSpeed = movSpeed;
//     roatationSpeed = rotSpeed;
//     Health = health;
// }





    */

}
