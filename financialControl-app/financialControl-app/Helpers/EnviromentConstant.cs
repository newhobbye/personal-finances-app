﻿using System;
using System.IO;

namespace financialControlapp.Helpers
{
    internal static class EnviromentConstant
    {
        public const string DatabaseFilename = "Finance.db3";

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
