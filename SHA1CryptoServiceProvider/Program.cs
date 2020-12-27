using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            var personNames = File.ReadAllLines(@"..\..\..\PresonNames.txt");
            var hashAlogorithm =  SHA512.Create();

            var tablesDictionary = new OneToManyDictionary<string, string>();

            foreach (var personName in personNames)
            {
                var hashByes = hashAlogorithm.ComputeHash(Encoding.UTF8.GetBytes(personName));
                var value = BitConverter.ToInt32(hashByes);
                var machineId = Math.Abs(value % 5);
                tablesDictionary.Add(machineId.ToString(), personName);
            }

            foreach (var machine in tablesDictionary.OrderBy(k => k.Key))
            {
                Console.WriteLine($"Machine: {machine.Key}\tCount: {tablesDictionary[machine.Key].Count}");
            }

            foreach (var personName in personNames)
            {
                var hashByes = hashAlogorithm.ComputeHash(Encoding.UTF8.GetBytes(personName));
                var value = BitConverter.ToInt32(hashByes);
                var machineId = Math.Abs(value % 5);

                tablesDictionary[machineId.ToString()].Contains(personName);
            }
        }

        private static string GetHashValue(byte[] hashBytes)
        {
            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}



































////private static HashAlgorithm GetHashAlgorithm()
////{
////    return SHA1.Create();
////}

////private static string GetHashCode(HashAlgorithm hashAlgorithm, string input)
////{
////    var buffer = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
////    var stringBuilder = new StringBuilder();
////    for (int i = 0; i < buffer.Length; i++)
////    {
////        stringBuilder.Append(buffer[i].ToString("x2"));
////    }

////    return stringBuilder.ToString();
////}

