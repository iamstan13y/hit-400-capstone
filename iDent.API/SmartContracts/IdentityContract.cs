using Neo.SmartContract.Framework;
using System.Text;
using Neo.SmartContract.Framework.Services;
using iDent.ModelLibrary.Models.Data;
using Neo.SmartContract.Framework.Attributes;

namespace iDent.API.SmartContracts
{
    [ManifestExtra("Author", "Keith Charedzera")]
    [ManifestExtra("Email", "keithcharedzera@gmail.com")]
    [ManifestExtra("Description", "Smart Contract for my final year (HIT400) Blockchain-based Digital Identity System")]
    public class IdentityContract : SmartContract
    {
        public static void Main(string operation, Identity identity)
        {
            if (operation == "CreateIdentity")
            {
                CreateIdentity(identity);
            }

            if (operation == "GetIdentity")
            {
                string? id = identity.IdentityNumber;

                GetIdentity(id!);
            }

            if (operation == "UpdateIdentity")
            {
                UpdateIdentity(identity);
            }

            if (operation == "DeleteIdentity")
            {
                DeleteStudent(identity.IdentityNumber!);
            }
        }

        public static void CreateIdentity(Identity identity)
        {
            string serializedData = SerializeIdentityData(identity);
            Storage.Put(Storage.CurrentContext, identity.IdentityNumber, serializedData);
        }

        public static Identity GetIdentity(string id)
        {
            string serializedData = Storage.Get(Storage.CurrentContext, id);

            if (serializedData.Length == 0)
            {
                return null;
            }

            return DeserializeIdentityData(serializedData);
        }

        public static void UpdateIdentity(Identity identity)
        {
            string serializedData = SerializeIdentityData(identity);
            Storage.Put(Storage.CurrentContext, identity.IdentityNumber, serializedData);
        }

        public static void DeleteStudent(string id)
        {
            Storage.Delete(Storage.CurrentContext, id);
        }

        private static string SerializeIdentityData(Identity identity)
        {
            StringBuilder sb = new();
            sb.Append(identity.IdentityNumber);
            sb.Append(',');
            sb.Append(identity.FirstNames);
            sb.Append(',');
            sb.Append(identity.LastName);
            sb.Append(',');
            sb.Append(identity.Email);
            sb.Append(',');
            sb.Append(identity.MobileNumber);
            sb.Append(',');
            sb.Append(identity.DOB);
            sb.Append(',');
            sb.Append(identity.Address);
            sb.Append(',');
            sb.Append(identity.Status);
            sb.Append(',');
            sb.Append(identity.DateCreated);
            return sb.ToString();
        }

        private static Identity DeserializeIdentityData(string serializedData)
        {
            string[] data = serializedData.Split(',');

            return new Identity
            {
                IdentityNumber = data[0],
                FirstNames = data[1],
                LastName = data[2],
                Email = data[3],
                MobileNumber = data[4],
                DOB = Convert.ToDateTime(data[5]),
                Address = data[6],
                Status = Convert.ToInt32(data[7]),
                DateCreated = Convert.ToDateTime(data[8]),
            };
        }
    }
}