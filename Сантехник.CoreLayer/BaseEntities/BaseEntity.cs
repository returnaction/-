using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntities;

namespace Сантехник.CoreLayer.BaseEntity
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdateDate { get; set; }
        
        public virtual byte[] RowVersion { get; set; } = null!;
    }
}
