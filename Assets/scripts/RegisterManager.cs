using UnityEngine;
using TMPro;
using System.IO; //eklenmesi gerekir
using SQLite;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    private SQLiteConnection db;

    void Start()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, "users.db");
        db = new SQLiteConnection(dbPath);

        // Tablo yoksa oluşturur
        db.CreateTable<User>(); //db tablosu oromatik oluşturulacak manuel oluşturmaycağız
    }

    public void RegisterUser()
    {
        string email = emailInput.text.Trim();
        string username = usernameInput.text.Trim();
        string password = passwordInput.text.Trim();

        if (email == "" || username == "" || password == "")
        {
            Debug.Log("Boş alan var ❌");
            return;
        }

        User newUser = new User
        {
            Email = email,
            Username = username,
            Password = password
        };

        db.Insert(newUser);

        Debug.Log("Kullanıcı veritabanına kaydedildi ✅");

        // İstersen inputları temizle
        emailInput.text = "";
        usernameInput.text = "";
        passwordInput.text = "";
        SceneManager.LoadScene("LogınScene");
    }
}


public class User // kullanıcı bilgielri get ve set edilecek
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
