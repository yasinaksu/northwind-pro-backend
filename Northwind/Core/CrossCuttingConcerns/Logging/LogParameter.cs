using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    /// <summary>
    /// This class keep Method to log parameter detail.
    /// </summary>
    public class LogParameter
    {
        /// <summary>
        /// Method parameter name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Method parameter type.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Method parameter value.
        /// </summary>
        public object Value { get; set; }


    }
}
