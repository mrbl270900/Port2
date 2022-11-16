
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

public class Hashing
{
    protected const int saltbitsize = 64;
    protected const byte saltbytesize = saltbitsize / 8;
    protected const int hashbitsize = 256;
    protected const int hashbytesize = hashbitsize / 8;

    private HashAlgorithm sha256 = SHA256.Create();
    protected RandomNumberGenerator rand = RandomNumberGenerator.Create();

    public (string hash, string salt) hash(string password)
    {
        byte[] salt = new byte[saltbytesize];
        rand.GetBytes(salt);
        string saltstring = Convert.ToHexString(salt);
        string hash = hashSHA256(password, saltstring);
        return (hash, saltstring);
    }


    public bool Verify(string loginPassword, string hashedRegisteredPassword, string saltString)
    {
        string hashed_login_password = hashSHA256(loginPassword, saltString);
        if (hashedRegisteredPassword.Equals(hashed_login_password)) return true;
        else return false;
    }


    private string hashSHA256(string password, string saltstring)
    {
        byte[] hashinput = Encoding.UTF8.GetBytes(saltstring + password); 
        byte[] hashoutput = sha256.ComputeHash(hashinput);
        return Convert.ToHexString(hashoutput);
    }


    public void hash_measurement()
    {
        int count = 250000;
        byte[] hashinput = { 0, 0, 0, 0, 0, 0, 0, 0 };
        Console.WriteLine("Doing " + count + " hash computations");
        for (int i = 0; i < count; i++)
        {
            hashinput = sha256.ComputeHash(hashinput);
        }
    }

    public void pbkdf2_measurement()
    {
        int iterations = 1000000;
        Console.WriteLine("Doing " + iterations + " in function Pbkdf2");
        string password = "admindnc";
        byte[] salt = { 0, 0, 0, 0, 0, 0, 0, 0 };
        KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, iterations, hashbytesize);
    }

}