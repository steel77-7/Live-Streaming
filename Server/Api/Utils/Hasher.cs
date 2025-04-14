using System.Security.Cryptography;

namespace Server.Api.Utils;

public class Hasher
{
    private int saltLen = 16;
    private int hashLen = 20;

    public string Hash(string pass)
    {
        Console.WriteLine("hello"); 
        //creating the salt here
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltLen]);
        Console.WriteLine(2);

        //creating the hash here
        var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(hashLen);
        byte[] hashByte = new byte[saltLen + hashLen];
        Console.WriteLine(3); 

        //copying the hash and the salt to the same set of bytes
        Array.Copy(salt, 0, hashByte, 0, saltLen);
        Array.Copy(hash, 0, hashByte, saltLen, hashLen);
        Console.WriteLine(4);

        //converting to string
        string savePass = Convert.ToBase64String(hashByte);
        return savePass;
    }

    public bool Verify(string pass, string savedPass)
    {
        Console.WriteLine("ooo");
        byte[] hashBytes = Convert.FromBase64String(savedPass);
        byte[] salt = new byte[saltLen];
        Console.WriteLine("ooo : "+savedPass);

        Array.Copy(hashBytes, 0, salt, 0, saltLen);

        var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(hashLen);
        for (int i = 0; i < 20; i++)
        {
        Console.WriteLine("ooo : sdfhsdhsdgh"+i);
            if (hash[i] != hashBytes[i + saltLen])
                return false;
        }
        return true;
    }
}
