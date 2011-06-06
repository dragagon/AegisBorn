using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;

public interface IReceivableObject
{
    bool FromSFSObject(ISFSObject data);
}
