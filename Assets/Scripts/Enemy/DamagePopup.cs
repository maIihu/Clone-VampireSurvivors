using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    private TextMeshPro textMeshPro;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMeshPro = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMeshPro.SetText(damageAmount.ToString());
        textColor = textMeshPro.color;
        disappearTimer = 1f; // Thời gian hiển thị sát thương
        moveVector = new Vector3(0, 1) * 2f; // Di chuyển lên trên
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * (8f * Time.deltaTime);

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMeshPro.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}