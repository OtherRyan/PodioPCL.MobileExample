using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.Interfaces
{
	public interface ILog
	{
		void WriteLine(string message, params object[] args);
	}
}
