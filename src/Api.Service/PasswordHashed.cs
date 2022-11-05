using System.Security.Cryptography;
using System;

namespace Api.Service
{
    public class PasswordHashed
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);

            var passwordHash = Convert.ToBase64String(dst);

            return passwordHash;
        }

        public static bool VerifyHashedPassword(string HashedPassword, string password)
        {
            byte[] buffer4;

            if (HashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] src = Convert.FromBase64String(HashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }

            return ByteArraysEqual(buffer3, buffer4);
        }

        // unsafe static bool ByteArraysEqual(byte[] b1, byte[] b2)
        // {
        //     if (b1 == b2) return true;
        //     if (b1 == null || b2 == null) return false;
        //     if (b1.Length != b2.Length) return false;
        //     int len = b1.Length;
        //     fixed (byte* p1 = b1, p2 = b2)
        //     {
        //         int* i1 = (int*)p1;
        //         int* i2 = (int*)p2;
        //         while (len >= 4)
        //         {
        //             if (*i1 != *i2) return false;
        //             i1++;
        //             i2++;
        //             len -= 4;
        //         }
        //         byte* c1 = (byte*)i1;
        //         byte* c2 = (byte*)i2;
        //         while (len > 0)
        //         {
        //             if (*c1 != *c2) return false;
        //             c1++;
        //             c2++;
        //             len--;
        //         }
        //     }
        //     return true;
        // }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null || a.Length != b.Length) return false;
            var areSame = true;
            for (var i = 0; i < a.Length; i++) { areSame &= (a[i] == b[i]); }
            return areSame;
        }
    }
}