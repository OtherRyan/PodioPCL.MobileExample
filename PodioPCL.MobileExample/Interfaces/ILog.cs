using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.Interfaces
{
	/// <summary>
	/// Interface ILog. Used to log natively on each platform.
	/// </summary>
	public interface ILog
	{
		/// <summary>
		/// Writes the line.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void WriteLine(string message, params object[] args);
	}
}
