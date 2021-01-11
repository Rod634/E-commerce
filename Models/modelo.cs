using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
