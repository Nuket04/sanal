using UnityEngine;
using TMPro;
using SQLite;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorText;

    private SQLiteConnection db;

    void Start()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, "users.db");
        db = new SQLiteConnection(dbPath);

        // 🔥 BAŞTA KAPALI
        errorText.gameObject.SetActive(false);
        errorText.text = "";
    }

    public void LoginUser()
    {
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();

        if (email == "" || password == "")
        {
            ShowError("E-posta ve şifre boş olamaz");
            return;
        }

        var user = db.Table<User>()
                     .FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user == null)
        {
            ShowError("");
        }
        else
        {
            Debug.Log("Giriş başarılı ✅");

            // Hata varsa kapat (temizlik)
            errorText.gameObject.SetActive(false);

            SceneManager.LoadScene("MainMenu");
        }
    }

    void ShowError(string message)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = message;
    }
}
