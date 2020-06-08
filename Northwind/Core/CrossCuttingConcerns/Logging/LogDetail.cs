using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    /// <summary>
    /// This class keeps method namespace,class and method name
    /// </summary>
    public class LogDetail
    {
        /// <summary>
        /// this is for keeping method namespace with class name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// this is for keeping which method in current class
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// this property keeps invoked method all parameters.
        /// </summary>
        public List<LogParameter> Parameters { get; set; }

    }
}
