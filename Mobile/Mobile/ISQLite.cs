﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
