using System.Security.Cryptography;
using System.Text;
using SPV.Models;
namespace SPV.Utils
{
    public class PasswordManagement
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public void HashPasword(User user)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            user.Salt = Convert.ToHexString(salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(user.Password), salt, iterations, hashAlgorithm, keySize);
            user.Password = Convert.ToHexString(hash);
            
        }
        public bool VerifyPassword(string password, User user)
        {
            if(user.Salt== null || user.Password == null) { return false; }
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(user.Salt), iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(user.Password));
        }


    }
}
