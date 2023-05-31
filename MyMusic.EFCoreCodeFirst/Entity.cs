using System;
using System.Collections;

namespace MyMusic.EFCoreCodeFirst
{
    public abstract class Entity
    {
        public virtual long Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
    }
}
