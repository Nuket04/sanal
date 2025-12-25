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

            // 🔹 EKLE: boş giriş telemetrisi
            TelemetryManager.Instance.SendEvent(
                "LoginFailed",
                email == "" ? "empty_email" : email,
                "empty_fields"
            );

            return;
        }

        var user = db.Table<User>()
                     .FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user == null)
        {
            ShowError("");

            // 🔹 EKLE: hatalı giriş telemetrisi
            TelemetryManager.Instance.SendEvent(
                "LoginFailed",
                email,
                "wrong_email_or_password"
            );
        }
        else
        {
            Debug.Log("Giriş başarılı ✅");

            // 🔹 EKLE: session'a kullanıcıyı yaz
            SessionManager.CurrentUserEmail = email;

            // 🔹 EKLE: başarılı login telemetrisi
            TelemetryManager.Instance.SendEvent(
                "LoginSuccess",
                email
            );

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
