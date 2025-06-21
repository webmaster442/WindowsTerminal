using System.Security.Cryptography;
using System.Text;

namespace Webmaster442.WindowsTerminal.Internals;

internal static class GuidGenerator
{
    private static readonly Guid CustomprofileFragmentNamespace = new("f65ddb7e-706b-4499-8a50-40313caf510a");

    public static Guid GenerateByName(string name)
    {
        byte[] utf16leBytes = Encoding.Unicode.GetBytes(name);
        return GenerateUuidV5(CustomprofileFragmentNamespace, utf16leBytes);
    }

    public static Guid GenerateUuidV5(Guid namespaceId, byte[] nameBytes)
    {
        // Convert namespace GUID to big-endian byte array (RFC-compliant order)
        byte[] namespaceBytes = namespaceId.ToByteArray();
        SwapGuidByteOrder(namespaceBytes);

        // Concatenate namespace and name
        byte[] data = new byte[namespaceBytes.Length + nameBytes.Length];
        Buffer.BlockCopy(namespaceBytes, 0, data, 0, namespaceBytes.Length);
        Buffer.BlockCopy(nameBytes, 0, data, namespaceBytes.Length, nameBytes.Length);

        // Compute SHA-1 hash
        byte[] hash = SHA1.HashData(data);

        // Build UUID from first 16 bytes of hash
        byte[] newGuid = new byte[16];
        Array.Copy(hash, 0, newGuid, 0, 16);

        // Set UUID version to 5
        newGuid[6] = (byte)((newGuid[6] & 0x0F) | (5 << 4));

        // Set variant to RFC 4122
        newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80);

        // Convert back to little-endian format for .NET's Guid constructor
        SwapGuidByteOrder(newGuid);

        return new Guid(newGuid);
    }

    private static void SwapGuidByteOrder(byte[] guid)
    {
        Array.Reverse(guid, 0, 4);  // time_low
        Array.Reverse(guid, 4, 2);  // time_mid
        Array.Reverse(guid, 6, 2);  // time_hi_and_version
        // Remaining 8 bytes are fine
    }
}
