using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class ExecuteContext
    {
        public static string EntryAssemblyDirectory
        {
            get
            {
                if (entryAssemblyDirectory == null)
                {
                    Assembly assembly = Assembly.GetEntryAssembly();
                    entryAssemblyDirectory = Path.GetDirectoryName(assembly.Location);
                }
                return entryAssemblyDirectory;
            }
        }
        private static string entryAssemblyDirectory;

        public static string ExecutingAssemblyDirectory
        {
            get
            {
                if (executingAssemblyDirectory == null)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    executingAssemblyDirectory = Path.GetDirectoryName(assembly.Location);
                }
                return executingAssemblyDirectory;
            }
        }
        private static string executingAssemblyDirectory;

        public static string Directory
        {
            get { return directory; }
            private set { directory = value; }
        }
        private static string directory;

        public static ExecuteDirectoryType ExecuteDirectoryType
        {
            get { return executeDirectory; }
            private set { executeDirectory = value; }
        }
        private static ExecuteDirectoryType executeDirectory;

        static ExecuteContext()
        {
            InitEntry();
        }

        public static void InitDefine(string directory)
        {
            ExecuteDirectoryType = ExecuteDirectoryType.Define;
            Directory = directory;
        }

        public static void InitEntry()
        {
            ExecuteDirectoryType = ExecuteDirectoryType.EntryAssembly;
            Directory = EntryAssemblyDirectory;
        }

        public static void InitExecuting()
        {
            ExecuteDirectoryType = ExecuteDirectoryType.ExecutingAssembly;
            Directory = ExecutingAssemblyDirectory;
        }
    }
}
