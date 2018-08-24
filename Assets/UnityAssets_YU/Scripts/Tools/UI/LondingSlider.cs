
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Globe
{
    public static string nextSceneName = "01";
}
public class LondingSlider : MonoBehaviour
{
    public Slider loadingSlider;
    private Image image;
    public Text loadingText;
    private float loadingSpeed = 1;
    private float targetValue;
    private AsyncOperation operation;
    // Use this for initialization
    void Start()
    {
        image = UnityTool.FindGameObject(gameObject, "SliderImage").GetComponent<Image>();
        loadingText = UnityTool.FindGameObject(gameObject, "num").GetComponent<Text>();

        image.fillAmount = 0.0f;
        if (SceneManager.GetActiveScene().name == "main")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }
    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(1);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;
        yield return operation;
    }

    // Update is called once per frame
    void Update()
    {
        targetValue = operation.progress;
        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9
            targetValue = 1.0f;
        }
        if (targetValue != image.fillAmount)
        {
            //插值运算
            image.fillAmount = Mathf.Lerp(image.fillAmount, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(image.fillAmount - targetValue) < 0.01f)
            {
                image.fillAmount = targetValue;
            }
        }
        loadingText.text = ((int)(image.fillAmount * 100)).ToString() + "%";

        if ((int)(image.fillAmount * 100) == 100)
        {
            //允许异步加载完毕后自动切换场景
            operation.allowSceneActivation = true;
        }
    }
}