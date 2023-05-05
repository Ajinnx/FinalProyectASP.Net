using System.Security.Cryptography;
using System.Text;

namespace FinalProject.Security;

public static class Encriptacion
{
    /// <summary>
    /// Transforma la contraseña pasada como argumento a una versión encriptada de ésta.
    /// <br/>Se usan métodos de RNG, salt y SHA256.
    /// </summary>
    public static string EncriptarContrasena(string contrasena)
    {
        var bytesSal = new byte[32];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytesSal);
        var valorSal = Convert.ToBase64String(bytesSal);
        var bytesContrasenaConSal = Encoding.UTF8.GetBytes(contrasena + valorSal);
        var bytesHash = SHA256.HashData(bytesContrasenaConSal);
        var hashContrasenaConSal = Convert.ToBase64String(bytesHash);

        return hashContrasenaConSal + ":" + valorSal;
    }

    /// <summary>
    /// Desencripta y compara la contraseña introducida con
    /// la contraseña guardada en la base de datos. (<paramref name="contrasenaEncriptada"/>)
    /// </summary>
    public static bool ValidarContrasena(string contrasenaIntroducida, string contrasenaEncriptada)
    {
        var contrasena = contrasenaEncriptada.Split(':')[0];
        var valorSal = Convert.FromBase64String(contrasenaEncriptada.Split(':')[1]);
        var contrasenaIntroducidaConSal = contrasenaIntroducida + Convert.ToBase64String(valorSal);
        var bytesContrasenaIntroducidaConSal = Encoding.UTF8.GetBytes(contrasenaIntroducidaConSal);
        byte[] enteredHashedBytes;
        enteredHashedBytes = SHA256.HashData(bytesContrasenaIntroducidaConSal);

        return Convert.ToBase64String(enteredHashedBytes).Equals(contrasena);
    }
}